//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace lab10_en
//{
//    class Program
//    {
//        static void Main()
//        {
//            //try
//            //{
//            //    Matrix m = new Matrix(-1, 0);
//            //}
//            //catch (WrongArrayDimensions ex)
//            //{
//            //    Console.WriteLine($"{ex.Message}: {ex.SizeN}, {ex.SizeM}");
//            //}

//            //Matrix m1 = new Matrix(10, 10);
//            //Console.WriteLine(m1.ToString());

//            //try
//            //{
//            //    m1[-1, 2] = 5;
//            //}
//            //catch (WrongArrayDimensions ex)
//            //{
//            //    Console.WriteLine($"{ex.Message}: {ex.SizeN}, {ex.SizeM}");
//            //}

//            //try
//            //{
//            //    double d = m1[-1, 2];
//            //}
//            //catch (WrongArrayDimensions ex)
//            //{
//            //    Console.WriteLine($"{ex.Message}: {ex.SizeN}, {ex.SizeM}");
//            //}

//            //try
//            //{
//            //    double d = m1[-1, 200];
//            //}
//            //catch (WrongArrayDimensions ex)
//            //{
//            //    Console.WriteLine($"{ex.Message}: {ex.SizeN}, {ex.SizeM}");
//            //}

//            //Matrix m2 = new Matrix(5, 5);
//            //Task<Matrix> result = m1.MultiplyWise(m2);
//            //try
//            //{
//            //    Task.WaitAll(result);
//            //}
//            //catch (AggregateException x)
//            //{
//            //    foreach (var ex in x.InnerExceptions)
//            //        Console.WriteLine($"{ex.Message}");
//            //}
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Matrix m3 = new Matrix(10, 10);
//            //Console.WriteLine(m1.ToString());
//            //Console.WriteLine(m3.ToString());

//            //m1.OnMultiplicationFinished += OnMatrixFinishedMultiplication;

//            //result = m1.MultiplyWise(m3);
//            //try
//            //{
//            //    Task.WaitAll(result);
//            //    Console.WriteLine(result.Result.ToString());
//            //}
//            //catch (AggregateException x)
//            //{
//            //    foreach (var ex in x.InnerExceptions)
//            //        Console.WriteLine($"{ex.Message}");
//            //}
//        }

//        //private static void OnMatrixFinishedMultiplication(object sender, MultiplicationArgs e)
//        //{
//        //    Console.WriteLine($"Finished: {e.A}*{e.B}");
//        //}
//    }
//}
