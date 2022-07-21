using ProjectEulerDataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerLib
{
    public class Problem3Solver : ProblemSolver
    {

        public Problem3Solver() : base()
        {
            Problem.Id = 3;
            Problem.UpperBound = 600851475143 ;
           
            Problem.Title = "Largest prime factor";
            Problem.Description =
                "The prime factors of 13195 are 5, 7, 13 and 29.\n"
                    + "\n"
                    + "What is the largest prime factor of the number 600851475143 ?\n";


            Problem.Solutions.Add(new Solution
            {
                ProblemId = 3,
                Description = "Find primes under sqrt(600851475143), exautively devide each prime, return the remainer.",
                Version = 1,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 2,
                Description = "Don't need to build prime list. Just go from 2, as each number is completed devided out, the remainder will not be devided by any even number.",
                Version = 2,
            });
        }

        public override string solution1()
        {
            long [] primes = new ProjectEulerLib.MoreMath.PrimeCalculator().SeiveOfEratosthenes((long)(Math.Sqrt(Problem.UpperBound.Value)));
            long n = Problem.UpperBound.Value;

            long p = 0;
            long maxP = 0;
            for(int i = primes.Count() - 1; i >= 0; i--)            
            {
                while (n % primes[i] == 0)
                {
                    p = primes[i];
                    n /= p;

                    maxP = Math.Max(maxP, p);
                }
            }

            return Math.Max(maxP, n).ToString();
        }

        public override string solution2()
        {
            long n = Problem.UpperBound.Value;

            long p = 0;
            long maxP = 0;
            for(int i = 2; i < Math.Sqrt(n); i++)            
            {
                while (n % i == 0)
                {
                    p = i;
                    n /= p;

                    maxP = Math.Max(maxP, p);
                }
            }

            return Math.Max(maxP, n).ToString();
        }
    }
}