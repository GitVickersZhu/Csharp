using System.Collections.Generic;

namespace Functions
{
    interface IFunction
    {
        IEnumerable<double> Positions(double from, double to, uint n);
        double Evaluate(double at);
    }
}
