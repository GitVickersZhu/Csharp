using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    public class ExpandingArray<T> where T: IComparable<T>
    {
        T[] data;
        public ExpandingArray()
        {
            data = new T[4];
            Length = 4;
        }
        public int Length { get; private set; }
        public T this[int i]
        {
            get
            {
                return data[i];
            }
            set
            {
                if(i >= data.Length)
                {
                    int oldlen = data.Length;
                    int newlen = Math.Max(i + 1, oldlen * 2);
                    T[] newdata = new T[newlen];

                    for (int j = 0; j < oldlen; j++)
                        newdata[j] = data[j];
                    data = newdata;
                    Length = newlen;
                }
                data[i] = value;
            }

        }
        public T GetMaxElement()
        {
            T max = data[0];
            for (int i = 0; i < data.Length; i++)
                if (max.CompareTo(data[i]) < 0)
                    max = data[i];
            return max;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i] + " ");
            return "Element are: " + sb.ToString();
        }

    }
}
