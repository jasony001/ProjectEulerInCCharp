using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem50Solver : ProblemSolver
    {
        public Problem50Solver() : base()
        {
            Problem.Id = 50;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Consecutive prime sum";
            Problem.Description = 
@"The prime 41, can be written as the sum of six consecutive primes:
41 = 2 + 3 + 5 + 7 + 11 + 13

This is the longest sum of consecutive primes that adds to a prime below one-hundred.

The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

Which prime, below one-million, can be written as the sum of the most consecutive primes?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 50,
                Description = "Look for [rayfil]'s solution in the thread. Brilliant.",
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
            bool [] primeFlags = primeCalculator.GetPrimeFlagArray(1000000);
            List<long> primes = new List<long>();
            long sum = 0;
            for(int i = 0; i < 1000000; i ++)
                if (primeFlags[i]) {
                    if (sum + i > 1000000) break;
                    
                    primes.Add(i);
                    sum += i;
                }
            if (primeFlags[sum]) return sum.ToString();

            for(int removeCount = 1; removeCount < primes.Count; removeCount ++)
            {
                for(int L = 0; L <= removeCount; L ++)
                {
                    long total = sum; // this is the start of next try. reset total
                    int H = removeCount - L;

                    for(int i = 0; i < L; i ++) total -= primes[i];
                    for(int i = 0; i < H; i ++) total -= primes[primes.Count - 1 - H];

                    if (primeFlags[total]) return total.ToString();
                }
            }
            

            return "no solution found.";
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
