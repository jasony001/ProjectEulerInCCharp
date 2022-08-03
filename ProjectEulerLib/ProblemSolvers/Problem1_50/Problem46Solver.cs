using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem46Solver : ProblemSolver
    {
        public Problem46Solver() : base()
        {
            Problem.Id = 46;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Goldbach's other conjecture";
            Problem.Description = 
@"

It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.

9 = 7 + 2×1^2
15 = 7 + 2×2^2
21 = 3 + 2×3^2
25 = 7 + 2×3^2
27 = 19 + 2×2^2
33 = 31 + 2×1^2

It turns out that the conjecture was false.

What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 46,
                Description = "",
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
            for(int i = 0; i < primeFlags.Length; i ++)
            {
                if (primeFlags[i]) primes.Add(i);
            }

            long n = 1;

            while(true)
            {
                 n += 2;
                 if (primeFlags[n]) continue;
                 var primeCandidates = primes.Where(p => p <= n - 2 && p !=2);

                 bool goldbach = false;
                 foreach(long pc in primeCandidates)
                 {
                    double d = Math.Sqrt((n - pc) / 2);
                    if (Math.Abs(d - (long)d) < Math.Pow(0.1, 9))
                        goldbach = true;
                 }

                 if (!goldbach)
                    return n.ToString();
            }
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
