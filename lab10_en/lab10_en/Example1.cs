//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace lab10_en
//{
//    class Example1
//    {
//        static void throwExceptionExample()
//        {
//            throw new NotImplementedException();
//        }

//        //More realistic example...
//        public static double division(int num1, int num2)
//        {
//            double result = 0;
//            try
//            {
//                result = num1 / num2;
//            }
//            catch (DivideByZeroException e)
//            {
//                Console.WriteLine("Exception caught: {0}", e);
//                return double.NaN;
//            }
//            finally
//            {
//                Console.WriteLine("Result: {0}", result);
//            }
//            return result;
//        }

//        static void Main(string[] args)
//        {
//            //Basic examples
//            //System.IO.IOException
//            //Handles I / O errors.

//            //System.IndexOutOfRangeException
//            //Handles errors generated when a method refers to an array index out of range.

//            //System.ArrayTypeMismatchException
//            //Handles errors generated when type is mismatched with the array type.

//            //System.NullReferenceException
//            //Handles errors generated from referencing a null object.

//            //System.DivideByZeroException
//            //Handles errors generated from dividing a dividend with zero.

//            //System.InvalidCastException
//            //Handles errors generated during typecasting.

//            //System.OutOfMemoryException
//            //Handles errors generated from insufficient free memory.

//            //REMEMBER: FINALLY IS ALWAYS EXECUTED
//            try
//            {
//                throwExceptionExample();
//            }
//            catch (NotImplementedException exception)
//            {
//                Console.WriteLine("Caught: " + exception.GetType());
//                //return;
//            }
//            finally
//            {
//                Console.WriteLine("Finally");
//            }
//            Console.WriteLine(division(5, 2));
//            Console.WriteLine(division(5, 0));
//            Console.WriteLine("Rest of main");
//        }
//    }
//}
