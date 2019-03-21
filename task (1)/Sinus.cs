using System;
using System.Collections.Generic;

namespace Functions
{
    class Sinus : IFunction
    {
        private double phase;
        private double amplitude;
        private double frequency;

        public Sinus( double amplitude, double phase, double frequency) {
            this.phase = phase;
            this.amplitude = amplitude;
            this.frequency = frequency;

        }


        public double Evaluate(double at)
        {
            return amplitude * Math.Sin(frequency * at + phase);
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
