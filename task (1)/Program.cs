using System;

namespace Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in function integrator.");
            // First, some functions tests:

            var p = new Sinus(1, 0, 1);
            var dt = 0.01;
            bool bad = false;
            for (uint step = 0; step < 100; step++)
            {
                if (p.Evaluate(step * dt) != Math.Sin(step * dt))
                {
                    bad = true;
                }
            }
            if (bad)
            {
                Console.WriteLine("Bad values of evaluated sinus");
            }

            // użycie operatorów:
            var polyEx = (Polynomial)12.0;
            var polyEx2 = (Polynomial)(12.0, 1.0);
            var polyEx3 = (Polynomial)(1.0, 3.0, 1.0);

            var sin1 = new Sinus(2, Math.PI / 4, 3);
            var poly1 = new Polynomial(0, 0, 2);
            var sum = new FunctionSum(sin1, poly1);


            // sin^2+cos^2 - should be one.
            var trigIdentity = new FunctionSum(new FunctionProduct(new Sinus(1, 0, 1), new Sinus(1, 0, 1)), new FunctionProduct(new Sinus(1,Math.PI/2,1), new Sinus(1,Math.PI/2,1)));
            var integratedValue = RectangleIntegrator.Integrate(trigIdentity, 0, 10, 100);
            Console.WriteLine("Integrated trigonometric function: {0}, real value: 10", integratedValue);

            // sin-sin - should be zero.
            var flat = new FunctionSum(new FunctionProduct(new Sinus(1, 0, 1), new Polynomial(0, 0, -1)), new Sinus(1, 0, 1));
            integratedValue = RectangleIntegrator.Integrate(flat, 0, 3, 100);
            Console.WriteLine("Integrated for flat: {0}, real value: 0", integratedValue);
            Console.WriteLine();

            // integration accuracy
            var normalSin = new Sinus(2, 0, 1);
            var from = 0;
            var to = Math.PI;

            var notAccurate = RectangleIntegrator.Integrate(normalSin, from, to, 4);
            var mildlyAccurate = RectangleIntegrator.Integrate(normalSin, from, to, 12);
            var ratherAccurate = RectangleIntegrator.Integrate(normalSin, from, to, 60);
            var veryAccurate = RectangleIntegrator.Integrate(normalSin, from, to, 1000);

            Console.WriteLine("2*Sinus from 0 to Pi (real value: 4):");
            Console.WriteLine("4: {0}", notAccurate);
            Console.WriteLine("12: {0}", mildlyAccurate);
            Console.WriteLine("60: {0}", ratherAccurate);
            Console.WriteLine("1000: {0}", veryAccurate);

        }
    }
}
