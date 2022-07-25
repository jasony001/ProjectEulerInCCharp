using System;
using System.Linq;

namespace ProjectEulerLib.MoreMath
{
    public class SpecialNumberCalculator
    {
        public bool IsPandigitalNumber(long n, int digitsCount)
        {
            if (digitsCount > 10 || digitsCount < 1) return false;

            string s = n.ToString();
            if (s.Length != digitsCount) return false;
            if (s.ToArray().Distinct().Count() != digitsCount) return false;
            if (digitsCount == 10) return true;
            if (s.ToArray().Any(c => c > ('0' + digitsCount))) return false;

            return true;
        }

        public bool IsTriangleNumber(long x)
        {
            // ignore negative numbers
            double n = (Math.Sqrt(x * 8 + 1) - 1) / 2;

            return (Math.Abs(value: n - (long) n) < Math.Pow(0.1, 8));
        }


        public long ReverseTriangleNumber(long x)
        {
            // ignore negative numbers
            double n = (Math.Sqrt(x * 8 + 1) - 1) / 2;

            if (Math.Abs(value: n - (long) n) < Math.Pow(0.1, 8))
            {
                return (long)n;
            }

            return -1;
        }

        public long NthTriangleNumber(long n)
        {
            return n * (n + 1) / 2;
        }


        public long GetNthPentagonNumber(long n)
        {
            return n * (3 * n - 1) / 2;
        }

        public bool IsPentagonNumber(long n)
        {
            // ignore negative
            double x = (1 + Math.Sqrt(1 + 24 * n)) / 6;
            return (Math.Abs(x - (long)x)) < Math.Pow(0.1, 8);
        }

        public long ReversePentagonNumber(long n)
        {
            // ignore negative
            double x = (1 + Math.Sqrt(1 + 24 * n)) / 6;
            if ((Math.Abs(x - (long)x)) < Math.Pow(0.1, 8))
            {
                return (long) x;
            }

            return -1;
        }

        public long NthHexagonalNumber(long n)
        {
            return n* (3 * n - 1) / 2;
        }

        public bool IsHexagonalNumber(long x)
        {
            double n = (1 + Math.Sqrt(1 + 8 * x)) / 4;

            return (Math.Abs(value: n - (long) n) < Math.Pow(0.1, 8));
        }

        public long ReverseHexagonalNumber(long x)
        {
            double n = (1 + Math.Sqrt(1 + 8 * x)) / 4;

            if (Math.Abs(value: n - (long) n) < Math.Pow(0.1, 8))
            {
                return (long)n;
            }

            return -1;
        }

    }
}
