using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab10_en
{
    public class WrongArrayDimensions : Exception
    {
        public int SizeN { get; set; }
        public int SizeM { get; set; }
        public WrongArrayDimensions(string message) : base(message)
        {

        }
    }
    public class MultiplicationArgs : EventArgs
    {
        public double A { get; set; }
        public double B { get; set; }

        public MultiplicationArgs(double a, double b)
        {
            A = a;
            B = b;
        }
    }
    public delegate void MultiplicationHandler(object sender, MultiplicationArgs e);
    public class Matrix
    {
        public event MultiplicationHandler OnMultiplicationFinished;

        private double[,] M;
        private int sizeN, sizeM;
        public Matrix(int n, int m)
        {
            if (n <= 0 || m <= 0)
                throw new WrongArrayDimensions("Wrong size!") { SizeN = n, SizeM = m };
            M = new double[n, m];
            sizeN = n;
            sizeM = m;
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    M[i, j] = r.Next(-20, 20);
                }
            }
        }
        public void GetDimmensions(out int n, out int m)
        {
            n = sizeN;
            m = sizeM;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {
                    sb.AppendFormat("{0,7}", M[i, j]);
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public double this[int i, int j]
        {
            get
            {
                if (!CheckIfIndicesAreInRange(i, j))
                    throw new WrongArrayDimensions("given indices are outside of range") { SizeN = i, SizeM = j };
                return M[i, j];
            }
            set
            {
                if (!CheckIfIndicesAreInRange(i, j))
                    throw new WrongArrayDimensions("given indices are outside of range") { SizeN = i, SizeM = j };
                M[i, j] = value;
            }
        }

        public async Task<Matrix> MultiplyWise(Matrix other)
        {
            other.GetDimmensions(out int otherN, out int otherM);
            if (sizeN != otherN || sizeM != otherM)
            {
                throw new WrongArrayDimensions("Other matrix dimmensions are wrong") { SizeN = otherN, SizeM = otherM };
            }
            Matrix m = new Matrix(sizeN, sizeM);

            List<Task<double>> matrixResults = new List<Task<double>>();

            for (int i = 0; i < sizeN; i++)
                for (int j = 0; j < sizeM; j++)
                    matrixResults.Add(PerformExpensiveMultiplicationAsync(this[i, j], other[i, j]));

            await Task.WhenAll(matrixResults);

            int k = 0;
            for (int i = 0; i < sizeN; i++)
                for (int j = 0; j < sizeM; j++)
                    m[i, j] = matrixResults[k++].Result;
            return m;
        }

        private async Task<double> PerformExpensiveMultiplicationAsync(double a, double b)
        {
            return await Task.Run(() => PerformMultiplication(a, b));
        }

        private double PerformMultiplication(double a, double b)
        {
            Random r = new Random((int)(a + b));
            Thread.Sleep(r.Next(500, 1000));
            if (OnMultiplicationFinished != null)
                OnMultiplicationFinished.Invoke(this, new MultiplicationArgs(a, b));
            return a * b;
        }

        private bool CheckIfIndicesAreInRange(int i, int j)
        {
            return i >= 0 && i < sizeN && j >= 0 && j < sizeM;
        }

    }
}