using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem28Solver : ProblemSolver
    {

        public Problem28Solver() : base()
        {
            Problem.Id = 28;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Number spiral diagonals";
            Problem.Description = 
@"

Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

21 22 23 24 25
20  7  8  9 10
19  6  1  2 11
18  5  4  3 12
17 16 15 14 13

It can be verified that the sum of the numbers on the diagonals is 101.

What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 28,
                Description = "When the size is s, the 4 corners are s^2, s^2 - (s - 1), s^2 - 2(s - 1), s^2 - 3(s - 1)",
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
            long sum = 1;
            int l = 3;
            while(l <= 1001)
            {
                sum += 4 * l * l - 6 * l + 6;
                l +=2;
            }

            return sum.ToString();
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
