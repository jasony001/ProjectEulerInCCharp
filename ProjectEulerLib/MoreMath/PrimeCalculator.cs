using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerLib.MoreMath
{
    public class PrimeCalculator
    {
        public long [] SeiveOfEratosthenes(long n)
        {
            long sqrtOfN = (long)(System.Math.Sqrt(n));
            bool [] bArray = (new bool [n + 1]).Select(b => true).ToArray();
            bArray[0] = false; bArray[1] = false;

            for(long i = 2; i <= sqrtOfN; i ++)
            {
                if (bArray[i])
                {
                    for(long j = 2 * i; j <= n; j +=i)
                    {
                        bArray[j] = false;
                    }
                }
            }

            List<long> list = new List<long>();
            for(int i = 0; i <= n; i ++)
            {
                if (bArray[i]) list.Add(i);
            }

            return list.ToArray();
        }

        public long [] SeiveOfEratosthenes(long [] knownPrimes, long n)
        {
            long sqrtOfN = (long)(System.Math.Sqrt(n));
            bool [] bArray = new bool [n + 1];
            foreach(long p in knownPrimes)
            {
                bArray[p] = true;
            }
            
            long newLowerBound = knownPrimes[knownPrimes.Length - 1] + 1;

            for(long x = newLowerBound; x <= n; x ++)
            {
                bArray[x] = true;
            }

            for(long i = 2; i <= sqrtOfN; i ++)
            {
                if (bArray[i])
                {
                    long start = (newLowerBound % i > 0) ? (newLowerBound - newLowerBound % i + i) : newLowerBound;
                    if (newLowerBound < i) start = i * 2;
                    
                    for(long j = start; j <= n; j +=i)
                    {
                        bArray[j] = false;
                    }
                }
            }

            List<long> list = new List<long>();
            for(int i = 0; i <= n; i ++)
            {
                if (bArray[i]) list.Add(i);
            }

            return list.ToArray();
        }
    }
}

