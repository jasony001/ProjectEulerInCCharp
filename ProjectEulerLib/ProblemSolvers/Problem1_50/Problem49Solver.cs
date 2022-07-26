using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem49Solver : ProblemSolver
    {
        public Problem49Solver() : base()
        {
            Problem.Id = 49;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Prime permutations";
            Problem.Description = 
@"The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: (i) each of the three terms are prime, and, (ii) each of the 4-digit numbers are permutations of one another.

There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.

What 12-digit number do you form by concatenating the three terms in this sequence?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 49,
                Description = "Go through all 4-digit primes, find permutation numbers, form a list of the prime number in these numbers, remove all these primes from the main prime list. Find an increasing sequence. ",
                Version = 1,
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "",
            //     Version = 2,
            // });
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
            MoreMath.CombinationCalculator combinationCalculator = new MoreMath.CombinationCalculator();
            List<long> primes = primeCalculator.GetPrimesUnderN(10000).Where(p => p> 1000).ToList();

            while(primes.Count > 0)
            {
                List<int> digits = new List<int>();
                long x = primes[0];

                while(x > 0)
                {
                    digits.Insert(0, (int)x % 10);
                    x /= 10;
                }
                List<List<int>> permutations = combinationCalculator.ListPermutations(digits);
                List<int> permunatedPrimes = new List<int>();
                foreach(List<int> permutation in permutations)
                {
                    if (permutation[0] == 0) continue;
                    int y = 0;
                    int powerOf10 = 1;
                    for(int i = permutation.Count - 1; i >= 0; i --)
                    {
                        y += permutation[i] * powerOf10;
                        powerOf10 *= 10;
                    }
                    if (!primes.Contains(y)) continue;

                    primes.Remove(y);
                    permunatedPrimes.Add(y);
                }
                if (permunatedPrimes.Count < 3) continue;
                permunatedPrimes.Sort();

                for(int i = 0; i < permunatedPrimes.Count - 2; i ++)
                {
                    if ((permunatedPrimes[i] + permunatedPrimes[i + 1] + permunatedPrimes[i + 2]) / 3 == permunatedPrimes[i + 1])
                        return permunatedPrimes[i].ToString() + permunatedPrimes[i + 1].ToString() + permunatedPrimes[i + 2].ToString();
                }
            }

            return "no solution found";
        }

        public override string solution2()
        {
            return "";
        }

        public override string solution3()
        {
            return "";
        }
    }
}
