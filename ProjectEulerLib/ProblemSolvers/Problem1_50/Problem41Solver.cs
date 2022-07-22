using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem41Solver : ProblemSolver
    {
        public Problem41Solver() : base()
        {
            Problem.Id = 41;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 41,
                Description = 
@"2, 3, 5, 6, 8, 9 digits, 10 digits pandigital numbers are all divisible by 3.
Get primes under 10000000,
check 1 digit 4 digits and 7 digits primes. pandigital numbers. 
",
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
            MoreMath.SpecialNumberCalculator specialNumberCalculator = new MoreMath.SpecialNumberCalculator();

            bool [] primes = primeCalculator.GetPrimeFlagArray(10000000);
            List<long> pandigitalPrimes = new List<long>();
            int[] possibleDigits = new int[]{1, 4, 7};
            long largestPP = 0;
            foreach(int digits in possibleDigits)
            {
                for(long n = (long)(Math.Pow(10, digits - 1)); n < (long)(Math.Pow(10, digits)); n ++)
                {
                    if (primes[n] && specialNumberCalculator.IsPandigitalNumber(n, digits))
                    largestPP = Math.Max(largestPP, n);
                }
            }
            
            return largestPP.ToString();
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
