using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem47Solver : ProblemSolver
    {
        public Problem47Solver() : base()
        {
            Problem.Id = 47;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 47,
                Description = "brutal force, find distinct factor for number 2 to 1000000. find 4 consectutive numbers with 4 distinct prime factors. 2000 milliseconds",
                Version = 1,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 0,
                Description = 
@"An implementation for [rayfil]'s algorithm: define an int array dfc[] of 1000000, each item contain 0. 
loop through primes under 1000 (sqrt of 1000000), add 1 to the array item for each multiple of the prime.
find the consecutive 4 numbers that dfc[n] = 4. 
7 milliseconds.
Some people are smarter than others :)
It's much more helpful to explain the algorithm than posting a one liner code in the forum.",
                Version = 2,
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "",
            //     Version = 3,
            // });
        }

        public override string solution1()
        {
            MoreMath.PrimeCalculator primeCalculator = new MoreMath.PrimeCalculator();
            MoreMath.FactorCalculator factorCalculator = new MoreMath.FactorCalculator();
            
            int n = 647;
            bool found = false;
            while (!found)
            {
                Dictionary<long, int> dictN = factorCalculator.GetPrimeFactorsDict(n);
                if (dictN.Keys.Count != 4) { n ++; continue;}
                
                Dictionary<long, int> dictN1 = factorCalculator.GetPrimeFactorsDict(n + 1);
                if (dictN1.Keys.Count != 4) { n += 2; continue;}
                
                Dictionary<long, int> dictN2 = factorCalculator.GetPrimeFactorsDict(n + 2);
                if (dictN2.Keys.Count != 4) { n += 3; continue;}
                
                Dictionary<long, int> dictN3 = factorCalculator.GetPrimeFactorsDict(n + 3);
                if (dictN3.Keys.Count != 4) { n += 4; continue;}
                
                found = true;
            }

            return n.ToString();
        }

        public override string solution2()
        {
            MoreMath.PrimeCalculator primeCalculator = new MoreMath.PrimeCalculator();
            long [] primes = primeCalculator.GetPrimesUnderN(1000);
            int [] distinctFactorCounts = new int [1000001];
            foreach(long p in primes)
            {
                for(long j = p * 2; j <= 1000000; j +=p)
                {
                    distinctFactorCounts[j] ++;
                }
            }

            int n = 2;
            for(; n <=1000000; n ++)
            {
                if (distinctFactorCounts[n] != 4) continue;
                if (distinctFactorCounts[n + 1] != 4) {n ++; continue;}
                if (distinctFactorCounts[n + 2] != 4) {n +=2; continue;}
                if (distinctFactorCounts[n + 3] != 4) {n +=3; continue;}
                break;
            }

            return n.ToString();
        }

        public override string solution3()
        {
            return "";
        }
    }
}
