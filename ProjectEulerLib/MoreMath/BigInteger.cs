using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerLib.MoreMath
{
    public class BigInteger
    {
        // PerformDigitsCarrying is called in ToString().
        // So it is called when debugging.
        // sbyte byte short int will be implicitly converted to long, no need to define overloads for those types
        #region properties
        int _sign;

        bool _isFlattened { get; set; }

        List<long> _digits;

        public bool AutoCarrying { get; set; }

        public long DigitCount
        {
            get
            {
                return _digits.Count;
            }
        }
        #endregion

        #region constructors - long, string, BigInteger (clone)
        public BigInteger(long n)
        {
            _sign = 1;
            AutoCarrying = true;
            _isFlattened = false;

            if (n == 0)
            {
                _digits = new List<long> { 0 };
                return;
            }

            if (n == long.MinValue)
            {
                // problem with long.MinValue : -1 * long.MinValue > long.MaxValue
                // long.MaxValue is OK
                _sign = -1;
                _digits = new List<long>();
                string s = n.ToString().Substring(1);

                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (s[i] > '9' || s[i] < '0') throw new System.IO.InvalidDataException("string contains non-numeric character");
                    _digits.Insert(0, s[i] - '0');
                }

                return;
            }

            _digits = new List<long>();
            if (n < 0)
            {
                _sign = -1;
                n *= -1;
            }

            while (n > 0)
            {
                _digits.Insert(0, n % 10);
                n /= 10;
            }
        }

        public BigInteger(BigInteger a)
        {
            // access control works on per-class basis, not on per-object basis.
            // so the private properties of {a} can be accessed here.
            _sign = a._sign;
            AutoCarrying = a.AutoCarrying;
            _isFlattened = a._isFlattened;
            _digits = a._digits.Select(n => n).ToList();
        }

        public BigInteger(string s)
        {
            _sign = 1;
            AutoCarrying = true;
            _isFlattened = false;

            if (s.Length > 0 && s[0] == '-')
            {
                _sign = -1;
                s = s.Substring(1);
            }

            _digits = new List<long>();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] > '9' || s[i] < '0') throw new System.IO.InvalidDataException("string contains non-numeric character");
                _digits.Insert(0, s[i] - '0');
            }
        }
        #endregion

        #region CompareTo(BigInteger / long)
        public int CompareTo(BigInteger b)
        {
            if (_sign == -1 && b._sign == 1) return -1;
            if (_sign == 1 && b._sign == -1) return 1;

            if (!_isFlattened) PerformDigitsCarrying();
            if (!b._isFlattened) b.PerformDigitsCarrying();

            // from here, two bigintetgers have same sign
            if (_digits.Count() > b._digits.Count()) return _sign;
            if (_digits.Count() < b._digits.Count()) return -1 * _sign;

            for (int i = 0; i < _digits.Count(); i++)
            {
                if (_digits[i] > b._digits[i]) return _sign;
                if (_digits[i] < b._digits[i]) return -1 * _sign;
            }

            return 0;
        }

        public int CompareTo(long b)
        {
            return this.CompareTo(new BigInteger(b));
        }
        #endregion

        #region override object methods - Equals, GetHashCode, ToString, added a ToListedString returns a string in the format of "[1, 2, 3, 4...]"
        public override bool Equals(object obj)
        {
            if (obj is BigInteger)
                return this.CompareTo((BigInteger)obj) == 0;

            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public string ToListedString()
        {
            // if (!_isFlattened) PerformDigitsCarrying();

            string s = "";
            if (_digits.Count == 0)
            {
                s = "[]";
            }
            else
            {
                s = $"[{_digits[0]}";
                for (int i = 1; i < _digits.Count; i++)
                    s = s + $", {_digits[i]}";
                s = s + "]";
            }
            if (_sign < 0) s = "-" + s;

            return s;
        }

        public override string ToString()
        {
            // if (!_isFlattened) PerformDigitsCarrying();

            string s = "";
            for (int i = 0; i < _digits.Count; i++)
            {
                s = s + _digits[i].ToString();
            }

            if (_sign < 0) s = "-" + s;

            return s;
        }
        #endregion

        public long ToLong()
        {
            if (!_isFlattened) PerformDigitsCarrying();
            if (_digits.Count > 18) throw new Exception("Cannot be converted to long. Exceeded max value of long.");
            long powerOf10 = 1;
            long result = 0;
            for (int i = _digits.Count - 1; i >= 0; i--)
            {
                result += _digits[i] * powerOf10;
                powerOf10 *= 10;
            }

            return result * _sign;
        }

        #region > < operators 
        public static bool operator >(BigInteger a, BigInteger b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <(BigInteger a, BigInteger b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >(BigInteger a, long b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <(BigInteger a, long b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >(long b, BigInteger a)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator <(long b, BigInteger a)
        {
            return a.CompareTo(b) > 0;
        }
        #endregion

        #region >= <= operators 
        public static bool operator >=(BigInteger a, BigInteger b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator <=(BigInteger a, BigInteger b)
        {
            return a.CompareTo(b) <= 0;
        }


        public static bool operator >=(BigInteger a, long b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator <=(BigInteger a, long b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator >=(long b, BigInteger a)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator <=(long b, BigInteger a)
        {
            return a.CompareTo(b) >= 0;
        }
        #endregion

        #region == != operators 
        public static bool operator ==(BigInteger a, BigInteger b)
        {
            return a.CompareTo(b) == 0;
        }

        public static bool operator !=(BigInteger a, BigInteger b)
        {
            return a.CompareTo(b) != 0;
        }

        public static bool operator ==(BigInteger a, long b)
        {
            return a.CompareTo(b) == 0;
        }

        public static bool operator !=(BigInteger a, long b)
        {
            return a.CompareTo(b) != 0;
        }

        public static bool operator ==(long b, BigInteger a)
        {
            return a.CompareTo(b) == 0;
        }

        public static bool operator !=(long b, BigInteger a)
        {
            return a.CompareTo(b) != 0;
        }
        #endregion

        #region Max, Min. Returns a new BigInteger
        public static BigInteger Max(BigInteger a, BigInteger b)
        {
            return (a > b) ? a : new BigInteger(b);
        }

        public static BigInteger Max(BigInteger a, long b)
        {

            return (a > b) ? a : new BigInteger(b);
        }

        public static BigInteger Max(long b, BigInteger a)
        {
            return (a > b) ? a : new BigInteger(b);
        }

        public static BigInteger Min(BigInteger a, BigInteger b)
        {
            return (a < b) ? a : new BigInteger(b);
        }

        public static BigInteger Min(BigInteger a, long b)
        {

            return (a < b) ? a : new BigInteger(b);
        }

        public static BigInteger Min(long b, BigInteger a)
        {
            return (a < b) ? a : new BigInteger(b);
        }

        #endregion

        #region private AddPositiveNumbers functions, SubstractSmallNumberFromBigNumber functions

        static BigInteger AddTwoPositiveNumbers(BigInteger a, BigInteger b)
        {
            if (a < 0 || b < 0) 
                throw new Exception("private function 'AddTwoPositiveNumbers' only handles calculation when a >= 0 && b >= 0");

            BigInteger smallNumber = BigInteger.Min(a, b);
            BigInteger largeNumber = BigInteger.Max(a, b);

            BigInteger result = new BigInteger(largeNumber);
            for(int i = 0; i < smallNumber._digits.Count; i ++)
                result._digits[result._digits.Count - 1 -i] = result._digits[result._digits.Count - 1 -i] + smallNumber._digits[smallNumber._digits.Count -1 - i];

            result.PerformDigitsCarrying();

            return result;
        }

        static BigInteger AddTwoPositiveNumbers(BigInteger a, long b)
        {
            if (a < 0 || b < 0) 
                throw new Exception("private function 'AddTwoPositiveNumbers' only handles calculation when a >= 0 && b >= 0");

            long extra = 0;
            if (b > long.MaxValue - 100) 
            {
                b = long.MaxValue - 100;
                extra = 100;
            }

            BigInteger r = new BigInteger(a);
            r._digits[r._digits.Count - 1] = a._digits[a._digits.Count - 1] + b;
            r.PerformDigitsCarrying();
            r._digits[r._digits.Count - 1] = r._digits[r._digits.Count - 1] + extra;
            r.PerformDigitsCarrying();

            return r;            
        }

        static BigInteger AddTwoPositiveNumbers(long b, BigInteger a)
        {
            return AddTwoPositiveNumbers(a, b);
        }

        static BigInteger SubstractSmallNumberFromBigNumber(BigInteger a, BigInteger b)
        {
            if (a < 0 || b < 0 || a < b) 
                throw new Exception("private function 'SubstractSmallNumberFromBigNumber' only handles calculation when a > b && a >= 0 && b >= 0");

            BigInteger result = new BigInteger(a);
            for(int i = 0; i < b._digits.Count; i ++)
                result._digits[result._digits.Count - 1 -i] = result._digits[result._digits.Count - 1 -i] - b._digits[b._digits.Count -1 - i];

            result.PerformDigitsCarrying();

            return result;
        }

        static BigInteger SubstractSmallNumberFromBigNumber(BigInteger a, long b)
        {
            if (a < b || a < 0 || b < 0) throw new Exception("private function 'SubstractSmallNumberFromBigNumber' only handles calculation when a > b && a >= 0 && b >= 0");

            BigInteger result = new BigInteger(a);
            result._digits[result._digits.Count - 1] = result._digits[result._digits.Count - 1] - b;
            Console.WriteLine(result._digits[result._digits.Count - 1]);
            result.PerformDigitsCarrying();

            return result;
        }

        static BigInteger SubstractSmallNumberFromBigNumber(long a, BigInteger b)
        {
            if (a < b || a < 0 || b < 0) throw new Exception("private function 'SubstractSmallNumberFromBigNumber' only handles calculation when a > b && a >= 0 && b >= 0");

            return SubstractSmallNumberFromBigNumber(new BigInteger(a), b);
        }

        static BigInteger MultiplyTwoNonNegativeNumbers(BigInteger a, BigInteger b)
        {
            if (a < 0 || b < 0) throw new Exception("Private function MultiplyTwoNonNegativeNumbers can only handle multiplication of two non-negative numbers");

            int longMaxValueDigitCountMinus2 = 17;
            int times = 0;
            BigInteger result = new BigInteger(0);
            BigInteger partOfB = new BigInteger(b);

            do
            {
                BigInteger t = new BigInteger(a);
                
                int pick = Math.Min(longMaxValueDigitCountMinus2, partOfB._digits.Count);
                BigInteger n = new BigInteger(0);
                n._digits = partOfB._digits.GetRange(partOfB._digits.Count - pick, pick);
                long number = n.ToLong();

                for(int i = 0; i < t._digits.Count; i ++) t._digits[i] *= number;
                t.PerformDigitsCarrying();

                for(int i = 0; i < longMaxValueDigitCountMinus2 * times; i ++) t._digits.Add(0);
                result = AddTwoPositiveNumbers(result, t);

                for(int i = 0; i < pick; i ++)
                    partOfB._digits.RemoveAt(partOfB._digits.Count - 1);

                times ++;
            }while (partOfB._digits.Count > 0);

            return result;
        }

        static BigInteger MultiplyTwoNonNegativeNumbers(BigInteger a, long b)
        {
            if (a < 0 || b < 0) throw new Exception("Private function MultiplyTwoNonNegativeNumbers can only handle multiplication of two non-negative numbers");

            return MultiplyTwoNonNegativeNumbers(a, new BigInteger(b));
        }

        static BigInteger MultiplyTwoNonNegativeNumbers(long b, BigInteger a)
        {
            if (a < 0 || b < 0) throw new Exception("Private function MultiplyTwoNonNegativeNumbers can only handle multiplication of two non-negative numbers");

            return MultiplyTwoNonNegativeNumbers(a, b);
        }
        
        public static BigInteger DevideNonNegativeNumberByPositiveNumber(BigInteger a, long b, ref long mod)
        {
            if (a < 0 || b < 0) throw new Exception("Private function DevideNonNegativeNumberByPositiveNumber can only handle positive numbers");
            if (b == 0) throw new Exception("Devided by 0");

            if (a < b) { mod = a.ToLong(); return new BigInteger(0);}
            if (a == b) { mod = 0; return new BigInteger(1);}

            BigInteger nominator = new BigInteger(a);
            BigInteger demoninator = new BigInteger(b);

            BigInteger f = new BigInteger(0);
            int notProcessedIndex = demoninator._digits.Count;

            f._digits = a._digits.GetRange(0, notProcessedIndex);

            BigInteger result = new BigInteger(0);
            result._digits = new List<long>();

            while (notProcessedIndex < nominator._digits.Count)
            {
                result._digits.Add(f.ToLong() / b);
                long r = f.ToLong() % b;
                f = new BigInteger(r);
                f._digits.Add(nominator._digits[notProcessedIndex]);
                while(f._digits.Count > 0 && f._digits[0] == 0) f._digits.RemoveAt(0);
                notProcessedIndex ++;
            }

            result._digits.Add(f.ToLong() / b);
            mod = f.ToLong() % b;
            result.PerformDigitsCarrying();            

            return result;
        }
        #endregion

        #region operator +, returns a new BigInteger
        public static BigInteger operator +(BigInteger a, BigInteger b)
        {
            BigInteger negativeA = null;
            BigInteger negativeB = null;

            if (a._sign == -1)
            {
                negativeA = new BigInteger(a);
                negativeA._sign = 1;
            }
            
            if (b._sign == -1)
            {
                negativeB = new BigInteger(b);
                negativeB._sign = 1;
            }

            BigInteger result = null;
            if (a._sign == -1 && b._sign == -1)
            {
                result = AddTwoPositiveNumbers(negativeA, negativeB);
                result._sign = -1;
            } else if (a._sign == -1 && b._sign == 1)
            {
                // b - negativeA
                if (negativeA <= b)
                {
                    result = SubstractSmallNumberFromBigNumber(b, negativeA);
                }
                else
                {
                    result = SubstractSmallNumberFromBigNumber(negativeA, b);
                    result._sign = -1;
                }
            } else if (a._sign == 1 && b._sign == -1)
            {
                if (a < negativeB)
                {
                    result = SubstractSmallNumberFromBigNumber(negativeB, a);
                    result._sign = -1;
                }
                else
                {
                    result = SubstractSmallNumberFromBigNumber(a, negativeB);
                }
            }
            else
            {
                result = AddTwoPositiveNumbers(a, b);
            }

            return result;
        }

        public static BigInteger operator +(BigInteger a, long b)
        {
            return a + new BigInteger(b);
        }

        public static BigInteger operator +(long b, BigInteger a)
        {
            return a + new BigInteger(b);
        }
        #endregion

        #region operator *, returns a new BigInteger
        public static BigInteger operator *(BigInteger a, BigInteger b)
        {
            BigInteger positiveA = new BigInteger(a);
            BigInteger positiveB = new BigInteger(b);
            positiveA._sign = 1;
            positiveB._sign = 1;

            if (a < 0 && b < 0 || a >= 0 && b >= 0) return MultiplyTwoNonNegativeNumbers(positiveA, positiveB);

            BigInteger result = MultiplyTwoNonNegativeNumbers(positiveA, positiveB);
            result._sign = -1;
            return result;
        }

        public static BigInteger operator *(BigInteger a, long b)
        {
            return a * new BigInteger(b);
        }

         public static BigInteger operator *(long b, BigInteger a)
        {
            return a * b;
        }


        #endregion
        
        #region operator ^, returns a new integer
        public static BigInteger operator ^(BigInteger a, long p)
        {
            if (p < 0) throw new Exception("BigInteger does not support negative power");
            if (p == 0) return new BigInteger(1);
            BigInteger b = new BigInteger(1);

            for (int i = 0; i < p; i++) b = b * a;

            return b;
        }
        #endregion

        #region operator -, returns a new integer
        public static BigInteger operator -(BigInteger a, BigInteger b)
        {
            BigInteger negativeA = null;
            BigInteger negativeB = null;

            if (a._sign == -1)
            {
                negativeA = new BigInteger(a);
                negativeA._sign = 1;
            }
            
            if (b._sign == -1)
            {
                negativeB = new BigInteger(b);
                negativeB._sign = 1;
            }

            BigInteger result = null;
            if (a._sign == -1 && b._sign == -1)
            {
                // negativeB - negativeA
                if (negativeA >= negativeB)
                {
                    result = SubstractSmallNumberFromBigNumber(negativeA, negativeB);
                    result._sign = -1;
                }
                else
                {
                    result = SubstractSmallNumberFromBigNumber(negativeB, negativeA);
                }
            } else if (a._sign == -1 && b._sign == 1)
            {
                // -(negativeA + b)
                result = AddTwoPositiveNumbers(negativeA, b);
                result._sign = -1;
            } else if (a._sign == 1 && b._sign == -1)
            {
                // a + negativeB
                result = AddTwoPositiveNumbers(a, negativeB);
            }
            else
            {
                if (a >= b)
                    result = SubstractSmallNumberFromBigNumber(a, b);
                else
                {
                    result = SubstractSmallNumberFromBigNumber(b, a);
                    result._sign = -1;
                }
            }

            return result;
        }

        public static BigInteger operator -(BigInteger a, long b)
        {
            return a - new BigInteger(b);
        }
        
        public static BigInteger operator -(long a, BigInteger b)
        {
            return new BigInteger(a) - b;
        }
        
        #endregion

        #region operator /, returns a new integer
        public static BigInteger operator /(BigInteger a, long b)
        {
            if (b == 0) throw new Exception("devided by zero");
            BigInteger positiveA = new BigInteger(a);
            positiveA._sign = 1;
            long positiveB = b > 0 ? b : (-1 * b);

            long mod = 0;
            if (a < 0 && b < 0 || a >= 0 && b > 0) return DevideNonNegativeNumberByPositiveNumber(positiveA, positiveB, ref mod);

            BigInteger result = DevideNonNegativeNumberByPositiveNumber(positiveA, positiveB, ref mod);
            if (result != 0) result._sign = -1;

            return result;
        }

        #endregion

        #region operator %, returns a new integer
        public static long operator %(BigInteger a, long b)
        {
            if (b == 0) throw new Exception("devided by zero");
            BigInteger positiveA = new BigInteger(a);
            positiveA._sign = 1;
            long positiveB = b > 0 ? b : (-1 * b);

            long mod = 0;
            DevideNonNegativeNumberByPositiveNumber(positiveA, positiveB, ref mod);

// 51 % 7 = 2
// 51 % -7 = 2
// -51 % 7 = -2
// -51 % -7 = -2

            return a.CompareTo(0) * mod;

        }        
        #endregion

        // Make it public, so that the use can set AutoCarrying to false and call this manually

        public void PerformDigitsCarrying()
        {
            // the result is always non-negative
            long c = 0;
            for(int i = 0; i < _digits.Count; i ++)
            {
                long value = c + _digits[_digits.Count - 1 - i];
                long r = value % 10;
                if (r < 0)
                {
                    _digits[_digits.Count - 1 - i] = 10 + r;
                    c = value / 10 -1;
                }
                else
                {
                    _digits[_digits.Count - 1 - i] = r;
                    c = value / 10;
                }
            }

            while(c != 0)
            {
                long value = c;
                long r = value % 10;
                if (r < 0)
                {
                    _digits.Insert(0, 10 - r);
                    c = value / 10 -1;
                }
                else
                {
                    _digits.Insert(0, r);
                    c = value / 10;
                }
            }

            while(_digits.Count > 0 && _digits[0] == 0) _digits.RemoveAt(0);

            if (_digits.Count == 0) _digits.Add(0);
        }
    }
}
