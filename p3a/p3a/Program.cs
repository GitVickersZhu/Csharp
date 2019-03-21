using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace p3a
{
    class Program
    {

        static void Main(string[] args)
        {
            Encyclopedia encyclopedia = new Encyclopedia();

            #region TUTORIAL
            //=== TextBuilder examples ===
            //encyclopedia.GenerateText();
            //encyclopedia.GenerateTextStringBuilder();

            //=== Files, serialization examples ===
            List<Country> countries = encyclopedia.LoadCountries();

            Country poland = countries.Where(x => x.name == "Poland").First();
            string fileName = "Poland.xml";
            encyclopedia.SerializeCountryXml(poland, fileName);
            Country deserializedCountry = encyclopedia.DeserializeCountryXml(fileName);

            Directory.CreateDirectory("test"); //creating new directory
            if (!File.Exists(@"test/myfile.txt")) //checking if file exists
            {
                StreamWriter w = File.CreateText(@"test/myfile.txt"); //creating new file
                w.WriteLine("exampleText"); //writing text to file
                w.Close();
            }
            File.Copy(@"test/myfile.txt", @"test/myfileCopy.txt"); //copying file
            File.Move(@"test/myfile.txt", @"test/myfile2.txt"); //change file localization or renaming file
            string[] files = Directory.GetFiles("test", "*.txt", SearchOption.AllDirectories); //get all txt files in given directory and all subdirectories recursively
            Path.GetDirectoryName(files[0]); //file directory name - returns "test"
            Path.GetFileNameWithoutExtension(files[0]); //extracting only file name from full file path - returns "myfile"
            Directory.Delete("test", true); //deleting directory recursively

            //=== LINQ examples ===
            //-- 1 -- Countries in Europe
            //var countriesInEurope = countries.Where(x => x.continent == "Europe");
            var countriesInEurope = countries.Where(x => x.continent == "Europe");

            countriesInEurope =
                    from c in countries
                     where c.continent == "Europe"
                     select c;

            Console.WriteLine("Number of countries in Europe: " + countriesInEurope.Count());

            //-- 2 -- Country with the greatest area
            var countryArea = countries.OrderByDescending(x => x.area).FirstOrDefault();

            countryArea =
                (from c in countries
                 orderby c.area descending
                 select c).FirstOrDefault();

            Console.WriteLine("Lergest country is " + countryArea.name + " with area " + countryArea.area);

            //-- 3 -- Names of 5 countries with the greatest population
            var names = countries.OrderByDescending(x => x.population).Select(x => x.name).Take(5);

            Console.Write("5 countries with the greatest population: ");
            foreach (string name in names)
                Console.Write(name + " ");
            Console.WriteLine();

            //-- 4 -- Names of countries which codes are different from first two letters of country name
            var names2 =
                from c in countries
                let twoltters = c.name.Substring(0, 2).ToUpper()
                where c.code != twoltters
                select c.name;

            Console.WriteLine("Number of countries which codes are different from first two letters of country name: " + names2.Count());

            //-- 5 -- Find pairs of all countries with the same area
            var theSameArea =
                from c1 in countries
                join c2 in countries on c1.area equals c2.area
                where c1.name != c2.name //to avoid pairs with the same country
                select new { country1=c1, country2=c2 };

            Console.Write("Pairs of countries with the same area: ");
            foreach (var pair in theSameArea)
                Console.Write("(" + pair.country1.name + ", " + pair.country2.name + ") ");
            Console.WriteLine();

            //-- 6 -- List all countries in all continents
            var continents = countries.Select(x => x.continent).Distinct();
            var countriesInContinens =
                from continent in continents
                join country in countries on continent equals country.continent
                into countryGroup
                select countryGroup;

            for (int i = 0; i < continents.Count(); i++)
                Console.WriteLine("Number of countries in " + continents.Skip(i).First() + " is " + countriesInContinens.Skip(i).First().Count());

            #endregion

            #region STUDENT

            //--write binary serialization of Country class
            string fileName2 = "Poland.bin";
            encyclopedia.SerializeCountryBinary(poland,fileName2);
            Country deserializedCountry2 = encyclopedia.DeserializeCountryBinary(fileName2);

            //--for each continent create directory and serialize to it all countries from this continent
            encyclopedia.GroupCountriesIntoContinents(countries);

            //--get all countries which currencies starts with D letter
            var countriesDCurrency = countries.Where(x => x.currency.Length>0&&x.currency[0]=='D');

            Console.WriteLine("Number of countries which currencies starts with D: "+countriesDCurrency.Count());

            //--get continent with country with the greatest population
            var continentPopulation = countries.OrderByDescending(x => x.population).Select(x => x.continent).First();

            Console.WriteLine("Continent with country with the greatest population is "+continentPopulation);

            //--get all pairs of countries with the same first word of their names
            var countriesTheSameWord =
               from c1 in countries
               join c2 in countries on c1.name.Split(' ')[0] equals c2.name.Split(' ')[0]
               where c1.name!=c2.name
               select new { country1 = c1,country2 = c2 };

            Console.Write("Pairs of countries with the same first word of their names: ");
            foreach ( var pair in countriesTheSameWord )
                Console.Write("("+pair.country1.name+", "+pair.country2.name+") ");
            Console.WriteLine();

            //--get name of 5 countries in Europe with the lowest population density (population/area) [be careful - one country has area = 0]
            var countriesDensity = countries.Where(x => x.continent=="Europe"&&x.area!=0)
                .OrderBy(x => x.population/x.area).Select(x => x.name).Take(5);

            Console.Write("Countries in Europe with the lowest population density: ");
            foreach ( var c in countriesDensity )
                Console.Write(c+", ");
            Console.WriteLine();

            #endregion

            }
    }
}
