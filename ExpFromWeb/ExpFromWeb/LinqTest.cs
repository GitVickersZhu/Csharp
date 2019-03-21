
//using System;
//using System.Linq;

//class LinqTest
//{

//    public static void Main()
//    {

//        Console.WriteLine();
//        Console.WriteLine("  Przyklad 1  -  tabliczka mnozenia");

//        var res1 = from n1 in Enumerable.Range(1, 5)
//                   join n2 in Enumerable.Range(1, 5) on 1 equals 1
//                   select new { n1, n2, w = n1 * n2 };

//        var res1k = Enumerable.Range(1, 5).Join(Enumerable.Range(1, 5), n1 => 1, n2 => 1, (n1, n2) => new { n1, n2, w = n1 * n2 });

//        foreach (var e in res1k)
//            Console.WriteLine("  {0} * {1} = {2}", e.n1, e.n2, e.w);


//        Console.WriteLine();
//        Console.WriteLine("  Przyklad 2  -  podzielniki wieksze od 1");

//        var res2 = from n1 in Enumerable.Range(0, 10)
//                   join n2 in Enumerable.Range(0, 10) on 1 equals 1
//                   where n2 > 1 && n1 % n2 == 0
//                   select new { n1, n2 };

//        var res2k = Enumerable.Range(0, 10).Join(Enumerable.Range(0, 10), n1 => 1, n2 => 1, (n1, n2) => new { n1, n2 }).Where(z => z.n2 > 1 && z.n1 % z.n2 == 0);

//        foreach (var e in res2)
//            Console.WriteLine("  {0}  {1}", e.n1, e.n2);


//        Console.WriteLine();
//        Console.WriteLine("  Przyklad 3  -  druga tabliczka mnozenia");

//        var res3 = from n1 in Enumerable.Range(1, 5)
//                   join n2 in Enumerable.Range(1, 5) on 1 equals 1 into res
//                   select new { n1, res };

//        var res3k = Enumerable.Range(1, 5).GroupJoin(Enumerable.Range(1, 5), n1 => 1, n2 => 1, (n1, res) => new { n1, res });

//        foreach (var e in res3)
//        {
//            Console.WriteLine();
//            foreach (var ee in e.res)
//                Console.WriteLine("  {0} * {1} = {2,2}", e.n1, ee, e.n1 * ee);
//        }

//        Console.WriteLine();
//        Console.WriteLine("  Przyklad 4  -  trzecia (czesciowa) tabliczka mnozenia");

//        var res4 = from n1 in Enumerable.Range(1, 5)
//                   from n2 in Enumerable.Range(n1, 6 - n1)
//                   select new { n1, n2, w = n1 * n2 };

//        var res4k = Enumerable.Range(1, 5).SelectMany(n1 => Enumerable.Range(n1, 5 - n1), (n1, n2) => new { n1, n2, w = n1 * n2 });

//        foreach (var e in res4)
//            Console.WriteLine("  {0} * {1} = {2,2}", e.n1, e.n2, e.w);

//        Console.WriteLine();
//        Console.WriteLine("  Przyklad 5  -  grupowanie (liczb n wedlug wartosci n*n%5)");

//        var res5 = from n in Enumerable.Range(0, 20)
//                   group n by (n * n) % 5;

//        var res5k = Enumerable.Range(0, 20).GroupBy(n => (n * n) % 5);

//        foreach (var e in res5)
//        {
//            Console.WriteLine(e.Key);
//            foreach (var ee in e)
//                Console.WriteLine("  {0}", ee);
//        }

//        Console.WriteLine();
//        Console.WriteLine("  Przyklad 6  -  grupowanie i kontynuacje");

//        var res6 = from n in Enumerable.Range(0, 20)
//                   group n by (n * n) % 5
//                   into sekw
//                   select new { sekw.Key, Count = sekw.Count() };

//        var res6k = Enumerable.Range(0, 20).GroupBy(n => (n * n) % 5).Select(e => new { e.Key, Count = e.Count() });

//        foreach (var e in res6)
//            Console.WriteLine("{0}  {1}", e.Key, e.Count);

//        Console.WriteLine();
//        Console.ReadLine();
//    }

//}