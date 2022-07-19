using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem21Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {

            },
            new List<string>{

            }
        };

        public Problem21Solver() : base()
        {
            Problem.Id = 21;
            Problem.UpperBound = 10000;
            Problem.IsClosedOnRight = false;
            Problem.Title = "Amicable numbers";
            Problem.Description =
@"Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 21,
                Description = "",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "Flatten the grid, build rowLists, columnLists, ForwardDiagonalLists, backDiagonalLists. Then loop to find the max product of 4.",
            //     Version = 2,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            // });
        }


        long GetSumOfFactors(long n)
        {
            if (n <= 1) return 0;
            long sum = 0;
            List<long> factors = new MoreMath.FactorCalculator().GetFactors(n);
            factors.Remove(n);
            foreach (long f in factors) sum += f;

            return sum;
        }

        public override string solution1()
        {
            List<long> factorsSumList = new List<long>(){0, 0};
            for (long i = 2; i <= Problem.CalculatedIncludedUpperBound; i++)
            {
                factorsSumList.Add(GetSumOfFactors(i));
            }

            long sum = 0;
            string s = " 0 ";
            for (int i = 2; i <= Problem.CalculatedIncludedUpperBound; i++)
            {
                if (factorsSumList[i] <= Problem.CalculatedIncludedUpperBound && factorsSumList[i] != i && factorsSumList[(int)factorsSumList[i]] == i)
                {
                    sum += i;
                    s = s + " + " + i.ToString();
                }
            }

            return s + " = " + sum.ToString();
        }

        public override string solution2()
        {
            return "";
        }
    }
}
