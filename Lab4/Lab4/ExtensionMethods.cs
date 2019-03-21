using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8En_tutorial
{
    public static class ExtensionMethods 
    {
        public static string DuplicateCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
                sb.Append(str[i], 2);
            return sb.ToString();
        }
        public static bool IsGreaterThan(this int value, int valueToCompareWith)
        {
            return value > valueToCompareWith;
        }

        public static T GetMinValue<T>(this ExpandingArray<T> array) where T : IComparable<T>
        {
            T min = array[0];
            for(int i = 0; i < array.Length; i++)   
                if (min.CompareTo(array[i]) > 0) min = array[i];           
            return min;

        }
        public static string ConcatenateArrat(this ExpandingArray<string> array)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
                sb.Append(array[i]);
            return sb.ToString();
        }
    }
}
