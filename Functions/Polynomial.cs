using System;
using System.Collections.Generic;

namespace Functions
{
    class Polynomial : IFunction
    {
        private double a;
        private double b;
        private double c;

        public Polynomial( double a, double b, double c) {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double Evaluate(double time)
        {
            // prosty horner
            return c + time * (b + time * a);
        }

        public IEnumerable<double> Positions(double from, double to, uint n)
        {
            double step = (to - from) / n;

            for (var s = 0; s < n; s++)
            {
                yield return Evaluate(from + s * step);
            }
        }

        public static explicit operator Polynomial(double c)
        {
            return new Polynomial(0, 0, c);
        }

        public static explicit operator Polynomial(ValueTuple<double, double> vals)
        {
            return new Polynomial(0, vals.Item1, vals.Item2);
        }
        public static explicit operator Polynomial(ValueTuple<double, double, double> vals)
        {
            return new Polynomial(vals.Item1, vals.Item2, vals.Item3);
        }
    }
}
