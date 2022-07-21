using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem23Solver : ProblemSolver
    {


        public Problem23Solver() : base()
        {
            Problem.Id = 23;
            Problem.UpperBound = 28123;
            Problem.IsClosedOnRight = false;
            Problem.Title = "Non-abundant sums";
            Problem.Description =
@"A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 23,
                Description = "",
                Version = 1,
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "Flatten the grid, build rowLists, columnLists, ForwardDiagonalLists, backDiagonalLists. Then loop to find the max product of 4.",
            //     Version = 2,
            // });
        }

        MoreMath.FactorCalculator _factorCalculator;
        MoreMath.FactorCalculator FactorCalculator
        {
            get
            {
                if (_factorCalculator == null) _factorCalculator = new MoreMath.FactorCalculator();
                return _factorCalculator;
            }
        }

        MoreMath.CombinationCalculator _combinationCalculator;
        MoreMath.CombinationCalculator CombinationCalculator
        {
            get
            {
                if (_combinationCalculator == null)
                {
                    _combinationCalculator = new MoreMath.CombinationCalculator();
                }

                return _combinationCalculator;
            }
        }

        public bool IsAbundantNumber(long n)
        {
            List<long> factors = FactorCalculator.GetFactors(n);
            factors.Remove(n);
            long sum = factors.Sum(f => f);

            return (sum > n);
        }


        public List<long> GetAbundantNumbers(long upperBound)
        {
            List<long> abundantNumbers = new List<long>();
            for (long i = 2; i < upperBound; i++)
            {
                try
                {
                    if (IsAbundantNumber(i))
                    {
                        abundantNumbers.Add(i);
                    }
                }
                catch 
                {
                    
                }
            }
            return abundantNumbers;
        }

        public override string solution1()
        {
            List<long> abundantNumbers = GetAbundantNumbers(Problem.UpperBound.Value);
            bool[] abundantNumberFlagList = new bool[Problem.UpperBound.Value];

            foreach (long i in abundantNumbers)
            {
                foreach (long j in abundantNumbers)
                {
                    if (i + j >= Problem.UpperBound) continue;
                    abundantNumberFlagList[i + j] = true;
                }
            }

            long sum = 0;
            for (int i = 0; i < Problem.UpperBound; i++)
            {
                if (!abundantNumberFlagList[i]) sum += i;
            }

            return sum.ToString();
        }

        public override string solution2()
        {
            return "";
        }
    }
}
