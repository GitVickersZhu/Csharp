
//using System;
//using System.Linq;

//class LinqTest
//{

//    public static void Main()
//    {
//        double w;
//        double[] tab1 = { 3.0, 4.0, -8.0, 1.5, 3.0, -2.0, 6.0, -4.0 };

//        // wybieranie co drugiego elementu sekwencji (niestandardowe Where)
//        Console.WriteLine();
//        var seq1 = tab1.Where((x, i) => i % 2 == 0);
//        foreach (var e in seq1)
//            Console.Write("  {0}", e);

//        // uwzglednianie w projekcji numeru indeksu elementu w sekwencji (niestandardowe Select)
//        Console.WriteLine();
//        var seq2 = tab1.Select((x, i) => new { x, i });
//        foreach (var e in seq2)
//            Console.WriteLine("  {0}  {1}", e.i, e.x);

//        // znajdywanie maksymalnego elementu w sekwencji (Max)
//        Console.WriteLine();
//        w = tab1.Max();
//        Console.WriteLine(w);

//        // znajdywanie maksymalnego kwadratu elementu w sekwencji (Max)
//        Console.WriteLine();
//        w = tab1.Max(x => x * x);
//        Console.WriteLine(w);

//        // obliczanie sumy kwadratow elementow sekwencji (Sum)
//        Console.WriteLine();
//        w = tab1.Sum(x => x * x);
//        Console.WriteLine(w);

//        // obliczanie pierwiastka z sumy kwadratow elementow sekwencji (Aggregate)
//        Console.WriteLine();
//        w = tab1.Aggregate(0.0, (x, y) => x + y * y, Math.Sqrt);
//        Console.WriteLine(w);

//        // znajdywanie pierwszego elementu wiekszego od 10 (FirstOrDefault)
//        Console.WriteLine();
//        w = tab1.FirstOrDefault(x => x > 10);
//        Console.WriteLine(w);

//        // pobieranie elementu spod indeksu 10 (ElementAtOrDefault)
//        Console.WriteLine();
//        w = tab1.ElementAtOrDefault(10);
//        Console.WriteLine(w);

//        // pozostawianie w sekwencji jedynie unikalnych elementow (Distinct)
//        Console.WriteLine();
//        var seq3 = tab1.Distinct();
//        foreach (var e in seq3)
//            Console.Write("  {0}", e);

//        Console.WriteLine();
//        Console.ReadLine();
//    }

//}