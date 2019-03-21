//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace lab10_en
//{
//    class Example5
//    {
//        public static void Main()
//        {
//            double computation1, computation2, computation3;
//            Stopwatch stopwatch = new Stopwatch();

//            stopwatch.Start();
//            Console.WriteLine("Starting long computations SYNCHRONOUSLY");
//            computation1 = PerformLongComputation(1);
//            computation2 = PerformLongComputation(2);
//            computation3 = PerformLongComputation(3);
//            Console.WriteLine("Computations have finished");
//            stopwatch.Stop();

//            Console.WriteLine("Results are:  {0}, {1}, {2}", computation1, computation2, computation3);
//            Console.WriteLine("Total time of computing:  {0}", stopwatch.ElapsedMilliseconds / 1000.0);
//            Console.WriteLine();

//            Console.WriteLine("Now let's see how to do it ASYNCHRONOUSLY...");
//            Task<double> resultAsync1, resultAsync2, resultAsync3;

//            stopwatch.Reset();
//            stopwatch.Start();
//            Console.WriteLine("Starting long computations ASYNCHRONOUSLY");
//            resultAsync1 = PerformLongComputationAsync(1);
//            resultAsync2 = PerformLongComputationAsync(2);
//            resultAsync3 = PerformLongComputationAsync(3);
//            Task.WaitAll(resultAsync1, resultAsync2, resultAsync3);

//            Console.WriteLine("Computations have finished");
//            stopwatch.Stop();

//            Console.WriteLine("Results are:  {0}, {1}, {2}", resultAsync1.Result, resultAsync2.Result, resultAsync3.Result);   // zmiana
//            Console.WriteLine("Total time of computing:  {0}", stopwatch.ElapsedMilliseconds / 1000.0);
//            Console.WriteLine();
//            Console.ReadKey();

//        }

//        private static double PerformLongComputation(int numberOfOperation)
//        {
//            Console.WriteLine("Working: {0}", numberOfOperation);
//            for (int i = 0; i < 10; ++i)
//            {
//                System.Threading.Thread.Sleep(500);
//                Console.Write(numberOfOperation);
//            }
//            Console.WriteLine("\nWork done: {0}", numberOfOperation);
//            return numberOfOperation * 5;
//        }
//        private static async Task<double> PerformLongComputationAsync(int numberOfOperation)   // nowa funkcja
//        {
//            Console.WriteLine("Long computation {0} has started ASYNCHRONOUSLY", numberOfOperation);
//            double result = await Task.Run(() => PerformLongComputation(numberOfOperation));
//            Console.WriteLine("Long computation {0} has ended ASYNCHRONOUSLY", numberOfOperation);
//            return result;
//        }
//    }
//}
