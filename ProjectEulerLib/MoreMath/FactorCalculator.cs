
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerLib.MoreMath
{
    public class FactorCalculator
    {
        public FactorCalculator()
        {
            PrimesUpperBound = 30000;
            Primes = new PrimeCalculator().SeiveOfEratosthenes(PrimesUpperBound);
        }
        
        long [] Primes 
        {
            get; set;
        }

        long PrimesUpperBound{
            get; set;
        }

        const long PrimeCalcuatorIncrement = 2000000;

        public long GetNumberOfFactors(long n)
        {
            return GetFactors(n).Count;
            
        }

        public Dictionary<long, int> GetPrimeFactorsDict(long n)
        {
            long o = n;
            Dictionary<long, int> primeFactorsDict = new Dictionary<long, int>();
            List<long> primeList = Primes.Where( x => x <= Math.Sqrt(o)).ToList();
            foreach (long p in primeList)
            {
                int pow = 0;
                while (n % p == 0)
                {
                    pow++;
                    n /= p;
                }
                if (pow > 0) primeFactorsDict.Add(p, pow);
            }

            if (n < o && n > 1) primeFactorsDict.Add(n, 1);

            return primeFactorsDict;
        }



        public List<long> GetFactors(long n)
        {
            List<long> factors = new List<long>();

            Dictionary<long, int> primeFactorsDict = GetPrimeFactorsDict(n);
            List<long> keys = primeFactorsDict.Keys.ToList();
            if (keys.Count == 0) return new List<long>{1};

            List<int> limits = primeFactorsDict.Values.ToList();
            List<int> powerList = new List<int>();
            for(int i = 0; i < limits.Count; i ++) powerList.Add(0);

            while(powerList[0] <= limits[0])
            {
                long product = 1;
                for(int i = 0; i < limits.Count; i ++)
                {
                    long p = keys[i];
                    product *= (long)Math.Pow(p, powerList[i]); // cache Math.Pow results
                }
                factors.Add(product);

                powerList[powerList.Count -1] ++;
                int position = powerList.Count - 1;   
                while(powerList[position] > limits[position] && position > 0)    
                {
                    powerList[position] = 0;
                    powerList[position -1] ++;
                    position --;
                }
            }

            return factors;
        }
    }
}