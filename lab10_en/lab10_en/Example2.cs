//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace lab10_en
//{

//    public class TempIsZeroException : Exception
//    {
//        public string AdditionalMessage { get; set; }
//        public TempIsZeroException(string message) : base(message)
//        {
//        }
//    }
//    public class Temperature
//    {
//        int temperature = 0;
//        public void showTemp()
//        {
//            if (temperature == 0)
//            {
//                throw new TempIsZeroException("Zero Temperature found") { AdditionalMessage = "It is reaaaly cold" };
//            }
//            else
//            {
//                Console.WriteLine("Temperature: {0}", temperature);
//            }
//        }
//    }
//    class Example2
//    {
//        static void Main(string[] args)
//        {
//            Temperature temp = new Temperature();
//            try
//            {
//                temp.showTemp();
//            }
//            catch (TempIsZeroException e)
//            {
//                Console.WriteLine("TempIsZeroException: {0}\n{1}", e.Message,e.AdditionalMessage);
//            }
//        }
//    }
//}
