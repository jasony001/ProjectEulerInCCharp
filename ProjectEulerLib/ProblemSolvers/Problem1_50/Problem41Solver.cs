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
            Problem.Title = "Pandigital prime";
            Problem.Description =
@"We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.

What is the largest n-digit pandigital prime that exists?
";

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
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 0,
                Description = "",
                Version = 2,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 0,
                Description = "try each 4 digits and 7 digits pandigital numbers, if it's prime",
                Version = 3,
            });
        }

        public override string solution1()
        {
            MoreMath.PrimeCalculator primeCalculator = new MoreMath.PrimeCalculator();
            MoreMath.SpecialNumberCalculator specialNumberCalculator = new MoreMath.SpecialNumberCalculator();

            bool[] primes = primeCalculator.GetPrimeFlagArray(10000000);
            List<long> pandigitalPrimes = new List<long>();
            int[] possibleDigits = new int[] { 1, 4, 7 };
            long largestPP = 0;
            foreach (int digits in possibleDigits)
            {
                long lowerBound = (long)(Math.Pow(10, digits - 1));
                long UpperBound = (long)(Math.Pow(10, digits));
                for (long n = lowerBound; n < UpperBound; n++)
                {
                    if (primes[n] && specialNumberCalculator.IsPandigitalNumber(n, digits))
                        largestPP = Math.Max(largestPP, n);
                }
            }

            return largestPP.ToString();
        }

        public override string solution2()
        {
            MoreMath.PrimeCalculator primeCalculator = new MoreMath.PrimeCalculator();
            MoreMath.SpecialNumberCalculator specialNumberCalculator = new MoreMath.SpecialNumberCalculator();

            long[] primes = primeCalculator.GetPrimesUnderN(10000000);
            List<long> pandigitalPrimes = new List<long>();
            int[] possibleDigits = new int[] { 1, 4, 7 };
            long largestPP = 0;
            foreach (int digits in possibleDigits)
            {
                long lowerBound = (long)(Math.Pow(10, digits - 1));
                long upperBound = (long)(Math.Pow(10, digits));
                long[] primesInRange = primes.Where(p => p >= lowerBound && p < upperBound).ToArray();
                foreach (long n in primesInRange)
                {
                    if (specialNumberCalculator.IsPandigitalNumber(n, digits))
                        largestPP = Math.Max(largestPP, n);
                }
            }

            return largestPP.ToString();
        }

        public override string solution3()
        {
            long largestPP = 0;
            // MoreMath.PrimeCalculator primeCalculator = new MoreMath.PrimeCalculator();
            // bool[] primeFlags = primeCalculator.GetPrimeFlagArray(10000000);

            foreach (int d1 in new int[] { 1, 2, 3, 4 })
                foreach (int d2 in new int[] { 1, 2, 3, 4 }.Where(d => d != d1))
                    foreach (int d3 in new int[] { 1, 2, 3, 4 }.Where(d => d != d1 && d != d2))
                        foreach (int d4 in new int[] { 1, 2, 3, 4 }.Where(d => d != d1 && d != d2 && d != d3))
                                    {
                                        int n = d4 + d3 * 10 + d2 * 100 + d1 * 1000;
                                        if (IsPrime(n) && largestPP < n) largestPP = n;
                                    }

            foreach (int d1 in new int[] { 1, 2, 3, 4, 5, 6, 7 })
                foreach (int d2 in new int[] { 1, 2, 3, 4, 5, 6, 7 }.Where(d => d != d1))
                    foreach (int d3 in new int[] { 1, 2, 3, 4, 5, 6, 7 }.Where(d => d != d1 && d != d2))
                        foreach (int d4 in new int[] { 1, 2, 3, 4, 5, 6, 7 }.Where(d => d != d1 && d != d2 && d != d3))
                            foreach (int d5 in new int[] { 1, 2, 3, 4, 5, 6, 7 }.Where(d => d != d1 && d != d2 && d != d3 && d != d4))
                                foreach (int d6 in new int[] { 1, 2, 3, 4, 5, 6, 7 }.Where(d => d != d1 && d != d2 && d != d3 && d != d4 && d != d5))
                                    foreach (int d7 in new int[] { 1, 2, 3, 4, 5, 6, 7 }.Where(d => d != d1 && d != d2 && d != d3 && d != d4 && d != d5 && d != d6))
                                    {
                                        int n = d7 + d6 * 10 + d5 * 100 + d4 * 1000 + d3 * 10000 + d2 * 100000 + d1 * 1000000;
                                        if (IsPrime(n) && largestPP < n) largestPP = n;
                                    }

            return largestPP.ToString();
        }

        bool IsPrime(long n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;

            return true;
        }

    }

}
