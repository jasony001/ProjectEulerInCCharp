using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem6Solver : ProblemSolver
    {


        public Problem6Solver() : base()
        {
            Problem.Id = 6;
            Problem.UpperBound = 100;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Sum square difference";
            Problem.Description =
                "The sum of the squares of the first ten natural numbers is,\n"
                + "1^2 + 2^2 + ... + 10^2 = 385\n"
                + "The square of the sum of the first ten natural numbers is,\n"
                + "(1 + 2 + ... + 10)^2 = 3025\n"
                + "Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640\n"
                + "Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.\n";


            Problem.Solutions.Add(new Solution
            {
                ProblemId = 6,
                Description = "Given f(n) = (1+...+n)^2 - 1^2 - ... - n^2\n"
                    + "f(n-1) = (1 + ... + n -1)^2 - 1^2 - ... - (n-1)^2\n"
                    + "f(n) = f(n-1) + n^3 - n^2\n"
                    + "f(1) = 0, loop through 2 to 100, find f(2), then f(3), ... f(100)",
                Version = 1,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 2,
                Description = "Brutal force",
                Version = 2,
            });
        }

        public override string solution1()
        {
            long n = 1;
            long r = 0;

            while (n < Problem.CalculatedIncludedUpperBound)
            {
                n ++;
                r = r + (long)(Math.Pow(n, 3)) - (long)(Math.Pow(n, 2));
            }

            return r.ToString();
        }

        public override string solution2()
        {
            long rb = (long)Math.Pow(Problem.CalculatedIncludedUpperBound * (Problem.CalculatedIncludedUpperBound + 1) / 2, 2);
            long rs = 0;
            for(int i = 1; i <= Problem.CalculatedIncludedUpperBound; i ++)
            {
                rs += i * i;
            }

            return (rb - rs).ToString();
        }
    }
}