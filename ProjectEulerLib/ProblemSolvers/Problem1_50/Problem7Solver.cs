using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem7Solver : ProblemSolver
    {

        public Problem7Solver() : base()
        {
            Problem.Id = 7;
            Problem.Title = "10001st prime";
            Problem.UpperBound = 10001;
            Problem.IsClosedOnRight = false;
            Problem.Description =
                "By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.\n"
                    + "\n"
                    + "What is the 10 001st prime number?\n";


            Problem.Solutions.Add(new Solution
            {
                ProblemId = 7,
                Description = "Incremental SeiveOfEratosthenes. Starts from 20000, increment of 20000.",
                Version = 1,
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 2,
            //     Description = "Build factor list, foreach number add dividen remainder",
            //     Version = 2,
            // });
        }

        public override string solution1()
        {
            ProjectEulerLib.MoreMath.PrimeCalculator primeCalculator = new ProjectEulerLib.MoreMath.PrimeCalculator();
            long upperBound = Problem.CalculatedIncludedUpperBound * 2;
            long increment = Problem.CalculatedIncludedUpperBound * 2;
            long[] primes = primeCalculator.GetPrimesUnderN(upperBound);
            while (primes.Length < Problem.CalculatedIncludedUpperBound + 1)
            {
                upperBound += increment;
                primes = primeCalculator.GetPrimesUnderN(primes, upperBound);
            }

            return primes[Problem.CalculatedIncludedUpperBound].ToString();
        }

    }
}
