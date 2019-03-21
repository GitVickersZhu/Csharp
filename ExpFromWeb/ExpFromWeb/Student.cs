
//using System;
//using System.Linq;
//using System.Collections.Generic;

//struct Student
//{
//    public readonly string Nazwisko;
//    public readonly string Imie;
//    public readonly string Grupa;
//    public Student(string naz, string im, string gr) { Nazwisko = naz; Imie = im; Grupa = gr; }
//}

//struct Grupa
//{
//    public readonly string Opis;
//    public readonly string Symbol;
//    public Grupa(string op, string sym) { Opis = op; Symbol = sym; }
//}

//class LinqTest
//{

//    public static void Main()
//    {

//        List<Grupa> grupy = new List<Grupa>
//            {
//            new Grupa("Trzeci rok,   grupa 1","A1"),
//            new Grupa("Trzeci rok,   grupa 2","A2"),
//            new Grupa("Drugi rok,    grupa 1","B1"),
//            new Grupa("Drugi rok,    grupa 2","B2"),
//            new Grupa("Pierwszy rok, grupa 1","C1"),
//            new Grupa("Pierwszy rok, grupa 2","C2"),
//            };

//        List<Student> studenci = new List<Student>
//            {
//            new Student("Abacki","Adam","A1"),
//            new Student("Babacka","Barbara","B2"),
//            new Student("Cacacka","Cecylia","C2"),
//            new Student("Dadacki","Dariusz","A2"),
//            new Student("Ebacka","Ewa","A1"),
//            new Student("Fafacki","Feliks","C1"),
//            new Student("Gagacki","Grzegorz","A1"),
//            new Student("Iksinski","Ksawery","B2"),
//            new Student("Kowalski","Jan","A1"),
//            new Student("Major","Major","C1"),
//            };

//        Console.WriteLine();
//        Console.WriteLine("Przyklad 0  -  wprowadzajacy");
//        Console.WriteLine();

//        foreach (var e in studenci)
//            Console.WriteLine("  {0,-10} {1,-15} {2}", e.Imie, e.Nazwisko, e.Grupa);


//        Console.WriteLine();
//        Console.WriteLine("Przyklad 1  -  klauzula join");
//        Console.WriteLine();

//        var res1 = from gr in grupy
//                   join st in studenci on gr.Symbol equals st.Grupa
//                   select new { st.Imie, st.Nazwisko, gr.Opis };

//        foreach (var e in res1)
//            Console.WriteLine("  {0,-10} {1,-15} {2,-20}", e.Imie, e.Nazwisko, e.Opis);


//        Console.WriteLine();
//        Console.WriteLine("Przyklad 2  -  klauzula join...into");
//        Console.WriteLine();

//        var res2 = from gr in grupy
//                   join st in studenci on gr.Symbol equals st.Grupa into lista
//                   select new { gr.Opis, lista };

//        foreach (var e in res2)
//        {
//            Console.WriteLine("{0}", e.Opis);
//            foreach (var ee in e.lista)
//                Console.WriteLine("  {0,-10} {1,-15}", ee.Imie, ee.Nazwisko);
//            Console.WriteLine();
//        }


//        Console.WriteLine();
//        Console.WriteLine("Przyklad 3  -  klauzula group");
//        Console.WriteLine();

//        var res3 = from gr in grupy
//                   join st in studenci on gr.Symbol equals st.Grupa
//                   group new { st.Imie, st.Nazwisko } by gr.Opis;

//        foreach (var e in res3)
//        {
//            Console.WriteLine("{0}", e.Key);
//            foreach (var ee in e)
//                Console.WriteLine("  {0,-10} {1,-15}", ee.Imie, ee.Nazwisko);
//            Console.WriteLine();
//        }


//        Console.WriteLine();
//        Console.ReadLine();
//    }

//}
