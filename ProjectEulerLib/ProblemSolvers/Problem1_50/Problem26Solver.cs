using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem26Solver : ProblemSolver
    {


        public Problem26Solver() : base()
        {
            Problem.Id = 26;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Reciprocal cycles";
            Problem.Description = @"A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

    1/2	= 	0.5
    1/3	= 	0.(3)
    1/4	= 	0.25
    1/5	= 	0.2
    1/6	= 	0.1(6)
    1/7	= 	0.(142857)
    1/8	= 	0.125
    1/9	= 	0.(1)
    1/10	= 	0.1 

Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 26,
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

        public override string solution1()
        {
            int maxL = 0;
            int maxN = 0;
            foreach (int n in new MoreMath.PrimeCalculator().GetPrimesUnderN(1000))
            {
                int powOf10 = 1;
                while (powOf10 * 10 < n) powOf10 *= 10;

                int r = powOf10;
                int l = 0;
                while (r > 1)
                {
                    while (r < n) r *= 10;
                    r = r % n;
                    l++;
                }

                if (r == 1 && l > maxL)
                {
                    maxL = l;
                    maxN = n;
                }
            }

            return maxN.ToString();
        }

        public override string solution2()
        {
            return "";
        }
    }
}
