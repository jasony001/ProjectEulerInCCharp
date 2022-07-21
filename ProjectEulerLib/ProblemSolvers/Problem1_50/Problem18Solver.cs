using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem18Solver : ProblemSolver
    {
        const long HALF_MAX = long.MaxValue / 2;

        public Problem18Solver() : base()
        {
            Problem.Id = 18;
            Problem.UpperBound = 1000;
            Problem.Title = "Maximum path sum I";
            Problem.Description = @"


By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

3
7 4
2 4 6
8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom of the triangle below:

75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. However, Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 18,
                Description = "In the thread, lot of people explained 'bottom up' strategy, I only understood maher's description :)",
                Version = 1,
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 18,
            //     Description = "put number in a list, each item is 1 digit. use junior school math multiplication carry digit. Perform carry when any of the item is over long.Maxvalue / 2.",
            //     Version = 2,
            // });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 18,
            //     Description = "Rever the number, save number 1234 in a list<int> {4, 3, 2, 1}. When perform carry, use List.Add instead of List.Insert.  Turned out that List.add costs same amount of time as List.Insert.",
            //     Version = 3,
            // });
        }

        public override string solution1()
        {
            List<List<int>> numberTriangle = new List<List<int>>
            {
                new List<int>{75},
                new List<int>{95,64},
                new List<int>{17,47,82},
                new List<int>{18,35,87,10},
                new List<int>{20,04,82,47,65},
                new List<int>{19,01,23,75,03,34},
                new List<int>{88,02,77,73,07,63,67},
                new List<int>{99,65,04,28,06,16,70,92},
                new List<int>{41,41,26,56,83,40,80,70,33},
                new List<int>{41,48,72,33,47,32,37,16,94,29},
                new List<int>{53,71,44,65,25,43,91,52,97,51,14},
                new List<int>{70,11,33,28,77,73,17,78,39,68,17,57},
                new List<int>{91,71,52,38,17,14,91,43,58,50,27,29,48},
                new List<int>{63,66,04,68,89,53,67,30,73,16,69,87,40,31},
                new List<int>{04,62,98,27,23,09,70,98,73,93,38,53,60,04,23},
            };

            for(int lineIndex = 14; lineIndex > 0; lineIndex --)
            {
                List<int> numbersInCurrentLine = numberTriangle[lineIndex];
                List<int> numbersInPreviuosLine = numberTriangle[lineIndex - 1];
                for(int index = 0; index < numbersInCurrentLine.Count -1; index ++)
                {
                    numbersInPreviuosLine[index] += Math.Max(numbersInCurrentLine[index], numbersInCurrentLine[index + 1]);
                }
            }

            return numberTriangle[0][0].ToString();
        }
    }
}