//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace lab10_en
//{
//    class Example3
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                Method1();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.StackTrace);
//            }
//            Console.ReadKey();
//        }

//        static void Method1()
//        {
//            try
//            {
//                Method2();
//            }
//            catch (Exception ex)
//            {
//                throw;
//                //throw ex; //what is the difference?
//            }
//        }

//        static void Method2()
//        {
//            string str = null;
//            Console.WriteLine(str[0]);
//        }
//    }
//}
