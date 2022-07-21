using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem15Solver : ProblemSolver
    {
        const long HALF_MAX = long.MaxValue / 2;

        public Problem15Solver() : base()
        {
            Problem.Id = 15;
            Problem.UpperBound = 1000;
            Problem.Title = "Lattice paths";
            Problem.Description =
                "Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.\n" +
                "How many such routes are there through a 20×20 grid?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 15,
                Description = "All credits go to RudyPenteado. Brilliant solution. "
                +@"Each movement in the horizontal is a zero.
Each movement in the vertical is a one.

1st binary# in this series:
0000000000000000000011111111111111111111
last:
1111111111111111111100000000000000000000
For the numbers in between, the amount of
 zeros should be the same as ones. In other
 words, the ones and zeros have to be rearranged.

The total is: 40!/(20!)(20!)"
                ,
                Version = 1,
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 15,
            //     Description = "put number in a list, each item is 1 digit. use junior school math multiplication carry digit. Perform carry when any of the item is over long.Maxvalue / 2.",
            //     Version = 2,
            // });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 15,
            //     Description = "Rever the number, save number 1234 in a list<int> {4, 3, 2, 1}. When perform carry, use List.Add instead of List.Insert.  Turned out that List.add costs same amount of time as List.Insert.",
            //     Version = 3,
            // });
        }

        public override string solution1()
        {
            double f1 = 1.0;
            double f2 = 1;      // long is not long enough

            for(int i = 1; i <=20; i ++) f1 *= i;
            
            for(int i = 21; i <=40; i ++) f2 *= i;
            

            return (f2 / f1).ToString();
        }
    }
}