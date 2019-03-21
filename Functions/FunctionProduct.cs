using System.Collections.Generic;

namespace Functions
{
    class FunctionProduct : IFunction
    {
        private IFunction one;
        private IFunction two;

        public FunctionProduct(IFunction one, IFunction two)
        {
            this.one = one;
            this.two = two;
        }
        public double Evaluate(double at)
        {
            return one.Evaluate(at) * two.Evaluate(at);
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
