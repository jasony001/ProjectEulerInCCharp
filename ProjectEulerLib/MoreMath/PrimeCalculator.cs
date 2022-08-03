using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerLib.MoreMath
{
    public class PrimeCalculator
    {
        public long[] GetPrimesUnderN(long n)
        {
            long sqrtOfN = (long)(System.Math.Sqrt(n));
            bool[] bArray = (new bool[n + 1]).Select(b => true).ToArray();
            bArray[0] = false; bArray[1] = false;

            for (long i = 2; i <= sqrtOfN; i++)
            {
                if (bArray[i])
                {
                    for (long j = 2 * i; j <= n; j += i)
                    {
                        bArray[j] = false;
                    }
                }
            }

            List<long> list = new List<long>();
            for (int i = 0; i <= n; i++)
            {
                if (bArray[i]) list.Add(i);
            }

            return list.ToArray();
        }

        public long[] GetPrimesUnderN(long[] knownPrimes, long newUpperBound)
        {
            long sqrtOfN = (long)(System.Math.Sqrt(newUpperBound));
            bool[] bArray = new bool[newUpperBound + 1];
            foreach (long p in knownPrimes)
            {
                bArray[p] = true;
            }

            long newLowerBound = knownPrimes[knownPrimes.Length - 1] + 1;

            for (long x = newLowerBound; x <= newUpperBound; x++)
            {
                bArray[x] = true;
            }

            for (long i = 2; i <= sqrtOfN; i++)
            {
                if (bArray[i])
                {
                    long start = (newLowerBound % i > 0) ? (newLowerBound - newLowerBound % i + i) : newLowerBound;
                    if (newLowerBound < i) start = i * 2;

                    for (long j = start; j <= newUpperBound; j += i)
                    {
                        bArray[j] = false;
                    }
                }
            }

            List<long> list = new List<long>();
            for (int i = 0; i <= newUpperBound; i++)
            {
                if (bArray[i]) list.Add(i);
            }

            return list.ToArray();
        }

        public bool[] GetPrimeFlagArray(long n)
        {
            long sqrtOfN = (long)(System.Math.Sqrt(n));
            bool[] bArray = (new bool[n + 1]).Select(b => true).ToArray();
            bArray[0] = false; bArray[1] = false;

            for (long i = 2; i <= sqrtOfN; i++)
            {
                if (bArray[i])
                {
                    for (long j = 2 * i; j <= n; j += i)
                    {
                        bArray[j] = false;
                    }
                }
            }

            return bArray;
        }

        public bool[] GetPrimeFlagArray(bool[] knownPrimes, long newUpperBound)
        {
            long sqrtOfN = (long)(System.Math.Sqrt(newUpperBound));
            bool[] bArray = new bool[newUpperBound + 1];
            for(int i = 0; i < knownPrimes.Length; i ++)
                bArray[i] = knownPrimes[i];

            long newLowerBound = knownPrimes.Length;

            for (long x = newLowerBound; x <= newUpperBound; x++)
                bArray[x] = true;

            for (long i = 2; i <= sqrtOfN; i++)
            {
                if (bArray[i])
                {
                    long start = (newLowerBound % i > 0) ? (newLowerBound - newLowerBound % i + i) : newLowerBound;
                    if (newLowerBound < i) start = i * 2;

                    for (long j = start; j <= newUpperBound; j += i)
                        bArray[j] = false;
                }
            }

            return bArray;
        }

        public bool IsPrime(long n)
        {
            if (n < 2) return false;
            if (n % 2 == 0) return false;
            for(int i = 3; i <= Math.Sqrt(n); i +=2)
            {
                if (n % i == 0) return false;
            }

            return true;
        }
    }
}

