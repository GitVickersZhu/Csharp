using System;

namespace DebugInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare a class instance box1:
            Box box1 = new Box(30.0f, 20.0f);

            // Declare an instance of the English units interface:
            IEnglishDimensions eDimensions = box1;

            // Declare an instance of the metric units interface:
            IMetricDimensions mDimensions = box1;

            // Print dimensions in English units:
            System.Console.WriteLine("Length(in): {0}", eDimensions.Length());
            System.Console.WriteLine("Width (in): {0}", eDimensions.Width());

            // Print dimensions in metric units:
            System.Console.WriteLine("Length(cm): {0}", mDimensions.Length());
            System.Console.WriteLine("Width (cm): {0}", mDimensions.Width());
            while (true) { }
        }

    }
}
