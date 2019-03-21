using System.Collections.Generic;

namespace Functions
{
    class RectangleIntegrator
    {
        public static double Integrate(IFunction function, double from, double to, uint n)
        {
            double value = 0;
            double step = (to - from) / n;
            foreach (var pos in function.Positions(from, to, n))
            {
                value += step * pos;
            }
            return value;

        }

        public static IEnumerable<double> ContinuousIntegrate(IFunction function, double from, double to, uint n)
        {
            double value = 0;
            double step = (to - from) / n;
            foreach (var pos in function.Positions(from, to, n))
            {
                value += step * pos;
                yield return value;
            }

        }
    }
}
