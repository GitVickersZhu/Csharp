//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace Learning1
//{
//    class Program
//    {
//        static void Main()
//        {
//            //int a = 1;
//            //D d = new D();
//            //d.fun(a);
//            //while (true) { }

//            //var city = result.Item1;
//            //var pop = result.Item2;
//            //var size = result.Item3;
//            //string city = "Raleigh";
//            //int population = 458880;
//            //double area = 144.8;
//            //(city, population, area) = QueryCityData("New York City");
//            //Console.WriteLine((city, population, area));

//            //Person p = new Person("John", "Quincy", "Adams", "Boston", "MA");
//            //var (fName, lName, city, state) = p;
//            //Console.WriteLine($"Hello {fName} {lName} of {city}, {state}!");
//            //var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);
//            //Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");

//            //double x = 1234.7;
//            //int a;
//            //a = (int)x;
//            //System.Console.WriteLine(a);
//            //List<object> mixedList = new List<object>();
//            //mixedList.Add("First Group");
//            //for(int j = 1; j < 5; j++)
//            //{
//            //    mixedList.Add(j);
//            //}
//            //mixedList.Add("Second Group");
//            //for(int j = 5; j < 10; j++)
//            //{
//            //    mixedList.Add(j);
//            //}
//            //foreach (var item in mixedList)
//            //{
//        //    //    Console.WriteLine(item);
//        //}
//        //Interfaces inter1 = new Interfaces(32, 21);
//        //System.Console.WriteLine(inter1.lengthInches);

//        //    IEnglishDimensions eDimensions = inter1;
//        //IMetricDimensions iDimensions = inter1;

//        //System.Console.WriteLine("Length(cm):", eDimensions.Length());
//        //    System.Console.WriteLine("Length(cm):");


//            while (true) { }
//        }
//    //private static (string, int, double)QueryCityData(string name)
//    //{
//    //    if (name == "New York City")
//    //        return (name, 8175133, 468.48);
//    //    return ("", 0, 0);
//    //}
//    private static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
//    {
//        int population1 = 0, population2 = 0;
//        double area = 0;
//        if (name == "New York City")
//        {
//            area = 468.48;
//            if (year1 == 1960)
//            {
//                population1 = 123123123;
//            }
//            if (year2 == 2010)
//            {
//                population2 = 321321321;
//            }
//            return (name, area, year1, population1, year2, population2);
//        }
//        return ("", 0, 0, 0, 0, 0);
//    }
//}
//}
