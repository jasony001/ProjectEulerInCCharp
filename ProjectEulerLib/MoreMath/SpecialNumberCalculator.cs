

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
    }
}
