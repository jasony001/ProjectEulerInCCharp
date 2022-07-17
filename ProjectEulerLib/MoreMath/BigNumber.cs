using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerLib.MoreMath
{
    public class BigNumber
    {

        public int sign { get; set; }

        public bool IsFlattened { get;set;}

        // reverse: number 1234 is saved as {4, 3, 2, 1}
        // each digits stores a 'long', it could be greaer than 9
        // PerformDigitsCarrying() flattens the BigNumber
        List<long> Digits { get; set; }

        public BigNumber(sbyte n)
        {
            BigNumber a = new BigNumber((long)n);
            sign = a.sign;
            Digits = a.Digits.Select(d => d).ToList();
        }

        public BigNumber(short n)
        {
            BigNumber a = new BigNumber((long)n);
            sign = a.sign;
            Digits = a.Digits.Select(d => d).ToList();
        }

        public BigNumber(int n)
        {
            BigNumber a = new BigNumber((long)n);
            sign = a.sign;
            Digits = a.Digits.Select(d => d).ToList();
        }

        public BigNumber(long n)
        {
            sign = 1;
            Digits = new List<long>();
            if (n < 0) { sign = -1; n *= -1; }
            if (n == 0) { Digits.Add(0); return; }

            while (n > 0)
            {
                Digits.Add(n % 10);
                n /= 10;
            }
        }

        public BigNumber(BigNumber a)
        {
            sign = a.sign;
            Digits = a.Digits.Select(n => n).ToList();
        }

        public BigNumber(string s)
        {
            sign = 1;
            if (s.Length > 0 && s[0] == '-')
            {
                sign = -1;
                s = s.Substring(1);
            }

            Digits = new List<long>();

            for(int i = s.Length - 1; i >= 0; i --)
            {
                if (s[i] > '9' || s[i] < '0') throw new System.IO.InvalidDataException("string contains non-numeric character");
                Digits.Add(s[i] - '0');
            }
        }

        public int CompareTo(BigNumber b)
        {
            BigNumber a = new BigNumber(this);

            if (a.Digits.Count() > b.Digits.Count()) return 1;
            if (a.Digits.Count() < b.Digits.Count()) return -1;

            for (int i = 0; i < a.Digits.Count(); i++)
            {
                if (a.Digits[i] > b.Digits[i]) return 1;
                if (a.Digits[i] < b.Digits[i]) return -1;
            }

            return 0;
        }

        public static bool operator >(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >=(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator <=(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator ==(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) == 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is BigNumber)
                return this.CompareTo((BigNumber)obj) == 0;

            return false;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator !=(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) != 0;
        }

        public static BigNumber Max(BigNumber a, BigNumber b)
        {
            return (a > b) ? a : b;
        }

        public static BigNumber Min(BigNumber a, BigNumber b)
        {
            return (a < b) ? a : b;
        }

        public static BigNumber operator +(BigNumber a, BigNumber b)
        {


            BigNumber c = new BigNumber(0);
            int index = 0;

            BigNumber bn = a.Digits.Count() >= b.Digits.Count() ? a : b;
            BigNumber sn = a.Digits.Count() < b.Digits.Count() ? a : b;

            while (index < sn.Digits.Count)
            {
                c.Digits.Add(bn.Digits[index] + sn.Digits[index]);
                index++;
            }

            while (index < bn.Digits.Count)
            {
                c.Digits.Add(bn.Digits[index]);
                index++;
            }

            c.IsFlattened = false;

            return c;
        }

        public static BigNumber operator *(BigNumber a, long x)
        {
            BigNumber c = new BigNumber(a);
            c.Digits = c.Digits.Select(d => d * x).ToList();
            c.IsFlattened = false;

            return c;
        }

        public void PerformDigitsCarrying()
        {
            long carry = 0;
            List<long> result = Digits.Select(d => d).ToList();
            Digits = new List<long>();

            for (int i = 0; i < result.Count() - 1; i++)
            {
                long d = (carry + result[i]) % 10;
                Digits.Add(d);
                carry = (carry + result[i]) / 10;
            }

            long f = carry + result[result.Count() - 1];
            while (f > 0)
            {
                Digits.Add(f % 10);
                f /= 10;
            }

            IsFlattened = true;
        }

        public override string ToString()
        {
            // if (!IsFlattened) PerformDigitsCarrying();

            string s = "";
            for(int i = Digits.Count - 1; i >= 0; i --)
            {
                s = s + Digits[i].ToString();
            }

            return s;
        }

    }
}
