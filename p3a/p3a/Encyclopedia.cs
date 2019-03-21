using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace p3a
{
    class Encyclopedia
    {

        #region TUTORIAL
        public void GenerateText()
        {
            string s = "";
            DateTime t1 = DateTime.Now;
            for (int i = 0; i < 100000; ++i) // 100 tys
                s += "abc";
            DateTime t2 = DateTime.Now;
            Console.WriteLine("GenerateText (100 tys chars): {0,7:0.000}", (t2 - t1).TotalSeconds);
        }

        public void GenerateTextStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            DateTime t1 = DateTime.Now;
            for (int i = 0; i < 100000000; ++i) // 100 mln
                sb.Append("abc");
            DateTime t2 = DateTime.Now;
            Console.WriteLine("GenerateTextStringBuilder (100 mln chars): {0,7:0.000}", (t2 - t1).TotalSeconds);
        }

        public List<Country> LoadCountries()
        {
            List<Country> countries = new List<Country>();

            string filePath = @"../../countries.csv"; //@ means to interpret the string literally, ../ means parent directory

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File countries.csv doesn't exist in project.");
                return countries;
            }

            //Version 1:
            //string[] lines = File.ReadAllLines(filePath);
            //foreach (string line in lines)
            //{ ... }

            //Version 2:
            StreamReader reader = new StreamReader(filePath);
            string line;
            line = reader.ReadLine(); //skip header line
            while ((line = reader.ReadLine()) != null)
            {
                string[] splittedLine = line.Split(';');
                Country newCountry = new Country();
                newCountry.name = splittedLine[0];
                newCountry.code = splittedLine[1];
                newCountry.continent = splittedLine[2];
                newCountry.population = int.Parse(splittedLine[3]);
                newCountry.area = int.Parse(splittedLine[4]);
                newCountry.coastline = int.Parse(splittedLine[5]);
                newCountry.currency = splittedLine[6];

                countries.Add(newCountry);
            }

            reader.Close();

            //Version 1:
            //File.AppendAllText("log.txt", DateTime.Now.ToShortTimeString() + " LoadCountries completed\n");

            //Version 2:
            StreamWriter writer = new StreamWriter("log.txt", true); //append
            writer.WriteLine(DateTime.Now.ToLongTimeString() + " LoadCountries completed\n");
            writer.Close();

            return countries;
        }

        public void SerializeCountryXml(Country c, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(Country));
            xs.Serialize(fs, c);
            fs.Close();

            File.AppendAllText("log.txt", DateTime.Now.ToLongTimeString() + " SerializeCountryXml completed\n");
        }

        public Country DeserializeCountryXml(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(Country));
            Country result = (Country)xs.Deserialize(fs);
            fs.Close();

            File.AppendAllText("log.txt", DateTime.Now.ToLongTimeString() + " DeserializeCountryXml completed\n");

            return result;
        }

        #endregion

        #region STUDENT
        public void SerializeCountryBinary(Country c, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = File.Create(path))
            {
                formatter.Serialize(stream, c);
            }

            File.AppendAllText("log.txt", DateTime.Now.ToLongTimeString() + " SerializeCountryBinary completed\n");
        }


        public Country DeserializeCountryBinary(string path)
        {
            Country result = null;
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = File.OpenRead(path))
            {
                result = (Country)formatter.Deserialize(stream);
            }

            File.AppendAllText("log.txt", DateTime.Now.ToLongTimeString() + " DeserializeCountryBinary completed\n");

            return result;
        }

        public void GroupCountriesIntoContinents(List<Country> countries)
        {
            List<string> continents = countries.Select(x => x.continent).Distinct().ToList();

            foreach (string continent in continents)
            {
                if (Directory.Exists(continent))
                    Directory.Delete(continent, true);
                Directory.CreateDirectory(continent);
            }

            foreach (Country country in countries)
                SerializeCountryBinary(country, country.continent + @"/" + country.name + ".bin");
        }

        #endregion



    }
}
