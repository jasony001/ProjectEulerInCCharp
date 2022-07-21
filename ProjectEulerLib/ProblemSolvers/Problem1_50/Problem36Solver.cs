using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem36Solver : ProblemSolver
    {
        public Problem36Solver() : base()
        {
            Problem.Id = 36;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Double-base palindromes";
            Problem.Description = 
@"The decimal number, 585 = 1001001001 (binary), is palindromic in both bases.

Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

(Please note that the palindromic number, in either base, may not include leading zeros.)";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 36,
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
            return "";
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
