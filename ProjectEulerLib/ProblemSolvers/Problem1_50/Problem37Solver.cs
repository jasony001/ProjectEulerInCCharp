using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem37Solver : ProblemSolver
    {
        public Problem37Solver() : base()
        {
            Problem.Id = 37;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Truncatable primes";
            Problem.Description =
@"
The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 37,
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
            long primeArrayIncrement = 100000;
            long primeArrayUpperBound = 100000;
            bool[] primeFlags = primeCalculator.GetPrimeFlagArray(primeArrayIncrement);
            int count = 0;
            long sum = 0;
            long n1 = 13;
            long n2 = 17;

            try{

            
            while (count < 11)
            {
                if (n1 > primeFlags.Length - 1)
                {
                    primeArrayUpperBound += primeArrayIncrement;
                    primeFlags = primeCalculator.GetPrimeFlagArray(primeFlags, primeArrayUpperBound);
                }

                if (IsTruncatablePrime(n1, primeFlags)) { count++; sum += n1; Console.WriteLine(n1);}
                if (IsTruncatablePrime(n2, primeFlags)) { count++; sum += n2; Console.WriteLine(n2); }

                n1 += 10;
                n2 += 10;
            }
            }catch(Exception ex)
            {
                Console.WriteLine($"{n1} {n2} {ex.Message}");
            }

            return sum.ToString();
        }

        private bool IsTruncatablePrime(long n, bool[] primeFlags)
        {
            long powerOf10 = 1;
            while (n > powerOf10 * 10) powerOf10 *= 10;
            long x = n;
            long y = n;
            while (x > 0 && y > 0)
            {
                if (!primeFlags[x] || !primeFlags[y]) return false;
                x = x % powerOf10;
                y /= 10;
                powerOf10 /= 10;
            }

            return true;
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
