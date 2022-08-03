using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem31Solver : ProblemSolver
    {
        public Problem31Solver() : base()
        {
            Problem.Id = 31;
            Problem.UpperBound = 200;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Coin sums";
            Problem.Description = 
@"In the United Kingdom the currency is made up of pound (£) and pence (p). There are eight coins in general circulation:

    1p, 2p, 5p, 10p, 20p, 50p, £1 (100p), and £2 (200p).

It is possible to make £2 in the following way:

    1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p

How many different ways can £2 be made using any number of coins?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 31,
                Description = 
@"Recursive. 
You could translate recursive to loops (the 'count down' solution), but then you have to change the code when the types of coins change.
Fot this problem, the recursive is 6 levels deep at the most.",
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
            if (Problem.CalculatedIncludedUpperBound < 0) return "0";
            return CountArrangement(Problem.CalculatedIncludedUpperBound, new int[]{200, 100, 50, 20, 10, 5, 2, 1}).ToString();
        }

        public int CountArrangement(long total, int[] cTypes)
        {
            if (total == 0) return 1;
            if (cTypes == null || cTypes.Length == 0) return 0;
            if (cTypes.Length == 1) return 1;
            if (cTypes.Length == 2) return (int)(total / cTypes[0] + 1);

            int count = 0;
            for(int i = 0; i <= total / cTypes[0]; i ++) count += CountArrangement(total - i * cTypes[0], cTypes.Where(c => c != cTypes[0]).ToArray());

            return count;
        }

        public override string solution2()
        {
            return "";
        }
    }
}
