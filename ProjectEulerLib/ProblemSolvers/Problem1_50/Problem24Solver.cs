using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem24Solver : ProblemSolver
    {


        public Problem24Solver() : base()
        {
            Problem.Id = 24;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Lexicographic permutations";
            Problem.Description = 
@"A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
012   021   102   120   201   210
What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 24,
                Description = "By hand, how many 9! left, how many 8! left, etc..",
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
            MoreMath.CombinationCalculator worker = new MoreMath.CombinationCalculator();
            long n = 999999;
            int digit = 10;
            long answer = 0;
            List<int> availableNumbers = new List<int>{0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            while (digit > 0)
            {
                long p = worker.NumberOfPermutaions(digit - 1);
                long d = n / p;
                n = n % p;
                d = availableNumbers[(int)d];
                answer += d * (long)Math.Pow(10, digit -1);
                availableNumbers.Remove((int)d);
                digit --;
            }


            return answer.ToString();
        }

        public override string solution2()
        {
            return "";
        }
    }
}
