using ProjectEulerDataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerLib
{
    public class Problem1Solver : ProblemSolver
    {
        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {
        "        private int sumOfNMultiply(int n)",
        "        {",
        "            if (n <= 0 || upperBound <= 0) return 0;",
        "",
        "            int x = upperBound / n - (!isCloseOnRight && upperBound % n == 0 ? 1 : 0);",
        "",
        "            return n * x * (x + 1) / 2;",
        "        }",
        "",
        "        public override string solution1Description",
        "        {",
        "            get",
        "            {",
        "                return \"n * x * (x + 1) / 2. (sum n = 3) + (sum n = 5) - sum (n = 15_=)\";",
        "            }",
        "        }"
                        },
            new List<string> {
        "        public override int solution2()",
        "        {",
        "            int sum = 0;",
        "            for (int i = 0; i < (isCloseOnRight ? upperBound + 1 : upperBound); i++)",
        "            {",
        "                if (i % 3 == 0 || i % 5 == 0)",
        "                    sum += i;",
        "            }",
        "            return sum;",
        "        }",
                    },
        };

        public Problem1Solver() : base()
        {
            Problem.Id = 1;
            Problem.Title = "Multiples of 3 or 5";
            Problem.Description =
                    "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.\n"
                    + " \n "
                    + "Find the sum of all the multiples of 3 or 5 below 1000.";
            Problem.UpperBound = 1000;
            Problem.IsClosedOnRight = false;

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 1,
                Description = "n * x * (x + 1) / 2. (sum n = 3) + (sum n = 5) - sum (n = 15)",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 1,
                Description = "Brutal Force",
                Version = 2,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            });
        }

        public override string solution1()
        {
            long answer = sumOfNMultiply(3) + sumOfNMultiply(5) - sumOfNMultiply(15);

            return answer.ToString();
        }

        private long sumOfNMultiply(int n)
        {
            if (n <= 0 || Problem.UpperBound <= 0) return 0;

            long x = Problem.CalculatedIncludedUpperBound / n;

            return n * x * (x + 1) / 2;
        }

        public override string solution2()
        {
            int sum = 0;
            for (int i = 1; i <= Problem.CalculatedIncludedUpperBound; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }
            return sum.ToString();
        }


    }
}