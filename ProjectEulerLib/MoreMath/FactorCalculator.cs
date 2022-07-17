
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerLib.MoreMath
{
    public class FactorCalculator
    {
        public FactorCalculator()
        {
            PrimesUpperBound = 4;
            Primes = new long[]{2, 3};
        }
        
        long [] Primes 
        {
            get; set;
        }

        long PrimesUpperBound{
            get; set;
        }

        const long PrimeCalcuatorIncrement = 2000000;

        public Dictionary<long, long> GetPrimeFactorMap(long n)
        {
            long param = n;
            Dictionary<long, long> dict = new Dictionary<long, long>();

            while (Math.Sqrt(n) > PrimesUpperBound) 
            {
                Primes = new PrimeCalculator().SeiveOfEratosthenes(Primes, PrimesUpperBound + PrimeCalcuatorIncrement);
                PrimesUpperBound += PrimeCalcuatorIncrement;
            }

            foreach (var prime  in Primes)
            {
                while (n % prime == 0)
                {
                    if (dict.ContainsKey(prime)) 
                        dict[prime] += 1;
                    else
                        dict.Add(prime, 1);
                    
                    n /= prime;
                }
            }

            if (n > Math.Sqrt(param)) dict.Add(n, 1);

            return dict;
        }

        public long GetNumberOfFactors(long n)
        {
            long numberOfFactors = 1; // 1
            Dictionary<long, long> primeFactorMap = GetPrimeFactorMap(n);
            List<long> numberOfPrimeFactorsList = primeFactorMap.Values.Select(i => i).ToList();
            CombinationCalculator worker = new CombinationCalculator();
            for(int i = 1; i <= numberOfPrimeFactorsList.Count; i ++)
            {
                List<List<long>> combinations = worker.ListCombinations<long>(numberOfPrimeFactorsList, i);
                foreach (var item in combinations)
                {
                    long product = 1;
                    foreach(long l in item)
                    {
                        product *= l;
                    }
                    numberOfFactors += product;
                }
            }

            return numberOfFactors;
        }
    }
}