using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem34Solver : ProblemSolver
    {

        public Problem34Solver() : base()
        {
            Problem.Id = 34;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 34,
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
            List<long> perms = new List<long>{1};
            for(int i = 1; i <=9; i ++)
            {
                perms.Add(perms[perms.Count - 1] * i);
            }

            int upperBoundDigits = 1;
            int powerOf10 = 1;

            while (upperBoundDigits * perms[9] > powerOf10)
            {
                upperBoundDigits ++;
                powerOf10 *= 10;
            }
            upperBoundDigits --;

            MoreMath.CombinationCalculator combinationCalculator = new MoreMath.CombinationCalculator();
            long UpperBound = perms[9] * upperBoundDigits;
            long answer = 0;
            for(long n = 10; n <= UpperBound; n ++)
            {
                long x = n;
                long sum = 0;
                while(x > 0)
                {
                    sum += combinationCalculator.NumberOfPermutaions(x % 10);
                    x /= 10;
                }

                if (n == sum)
                {
                    answer += n;
                    Console.WriteLine(n);
                }
            }

            return answer.ToString();
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
