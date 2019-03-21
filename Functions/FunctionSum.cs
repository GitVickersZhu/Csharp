using System.Collections.Generic;

namespace Functions
{
    class FunctionSum : IFunction
    {
        private IFunction one;
        private IFunction two;

        public FunctionSum(IFunction one, IFunction two)
        {
            this.one = one;
            this.two = two;
        }

        public double Evaluate(double time)
        {
            return one.Evaluate(time) + two.Evaluate(time);
        }

        public IEnumerable<double> Positions(double from, double to, uint n)
        {
            double step = (to - from) / n;

            for (var s = 0; s < n; s++)
            {
                yield return Evaluate(from + s * step);
            }
        }
    }
}
