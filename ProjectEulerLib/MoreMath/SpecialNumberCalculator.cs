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

        public long NthTriangleNumber(long n)
        {
            return n * (n + 1) / 2;
        }

        public long NthPentagonalNumber(long n)
        {
            return n* (3 * n - 1) / 2;
        }

        public bool IsPentagonalNumber(long x)
        {
            double n = (1 + Math.Sqrt(1 + 24 * x)) / 6;

            return (Math.Abs(value: n - (long) n) < Math.Pow(0.1, 8));
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

    }
}
