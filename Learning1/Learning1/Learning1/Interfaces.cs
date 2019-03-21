//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Learning1
//{
//    public class Interfaces:IEnglishDimensions, IMetricDimensions
//    {
//        public float lengthInches;
//        public float widthInches;

//        public Interfaces(float lengthInches, float widthInches)
//        {
//            this.lengthInches = lengthInches;
//            this.widthInches = widthInches;
//            System.Console.WriteLine("Created: ", this.widthInches);
           
//        }

//        float IEnglishDimensions.Length() => lengthInches;

//        float IEnglishDimensions.Width() => widthInches;

//        // Explicitly implement the members of IMetricDimensions:
//        float IMetricDimensions.Length() => lengthInches * 2.54f;

//        float IMetricDimensions.Width() => widthInches * 2.54f;

//        static void Main()
//        {
//            Interfaces inter1 = new Interfaces(30.0f, 20.0f);
//            System.Console.WriteLine(inter1.lengthInches);

//            IEnglishDimensions eDimensions = inter1;
//            IMetricDimensions mDimensions = inter1;

//            System.Console.WriteLine("Length(in): {0}", eDimensions.Length());

//            System.Console.WriteLine("Length(cm):", eDimensions.Length());
//            System.Console.WriteLine("Length(cm):");


//            while (true) { }

//        }
//    }

//    public interface IEnglishDimensions
//    {
//        float Length();
//        float Width();
//    }
//    public interface IMetricDimensions
//    {
//        float Length();
//        float Width();
//    }
//}
