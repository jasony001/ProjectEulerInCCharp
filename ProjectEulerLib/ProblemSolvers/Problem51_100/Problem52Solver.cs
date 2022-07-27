using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem52Solver : ProblemSolver
    {
        public Problem52Solver() : base()
        {
            Problem.Id = 52;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Permuted multiples";
            Problem.Description = 
@"It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.

Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 52,
                Description = 
@"set a upperLimit of how many digits, if a solution is not found under certain digits, return ' no solution found'
    cnArray = (n).ToString().ToArray().OrderBy(c => c).ToArray();
    char[] cmArray = (n * i).ToString().ToArray().OrderBy(c => c).ToArray();
    loop through each number (100 - 333, 1000 - 2500, 10000 - 20000, 100000 - 166667, ...)
    for m from 1 to 6, cn needs to be equal to cm
",

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
            for(int digits = 3; digits <= 6; digits ++)
            {
                long start = (long)Math.Pow(10, digits - 1);
                long end = (long)Math.Pow(10, digits) / digits;
                for(long n = start; n <= end ; n ++)
                {
                    char[] cnArray = (n).ToString().ToArray().OrderBy(c => c).ToArray();
                    bool isValid = true;
                    for(int i = 2; i <= 6; i ++)
                    {
                        char[] cmArray = (n * i).ToString().ToArray().OrderBy(c => c).ToArray();

                        for(int j = 0; j < cmArray.Length; j ++)
                        {
                            if (cnArray[j] != cmArray[j])
                            {
                                isValid = false;
                                break;
                            }
                        }
                        if (!isValid) break;
                    }
                    if (isValid) return n.ToString();
                }
            }

            return "working on it";
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
