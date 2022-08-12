using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem90Solver : ProblemSolver
    {
        public Problem90Solver() : base()
        {
            Problem.Id = 90;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Cube digit pairs";
            Problem.Description = 
@"

Each of the six faces on a cube has a different digit (0 to 9) written on it; the same is done to a second cube. By placing the two cubes side-by-side in different positions we can form a variety of 2-digit numbers.

For example, the square number 64 could be formed:

In fact, by carefully choosing the digits on both cubes it is possible to display all of the square numbers below one-hundred: 01, 04, 09, 16, 25, 36, 49, 64, and 81.

For example, one way this can be achieved is by placing {0, 5, 6, 7, 8, 9} on one cube and {1, 2, 3, 4, 8, 9} on the other cube.

However, for this problem we shall allow the 6 or 9 to be turned upside-down so that an arrangement like {0, 5, 6, 7, 8, 9} and {1, 2, 3, 4, 6, 7} allows for all nine square numbers to be displayed; otherwise it would be impossible to obtain 09.

In determining a distinct arrangement we are interested in the digits on each cube, not the order.

{1, 2, 3, 4, 5, 6} is equivalent to {3, 6, 4, 1, 2, 5}
{1, 2, 3, 4, 5, 6} is distinct from {1, 2, 3, 4, 5, 9}

But because we are allowing 6 and 9 to be reversed, the two distinct sets in the last example both represent the extended set {1, 2, 3, 4, 5, 6, 9} for the purpose of forming 2-digit numbers.

How many distinct arrangements of the two cubes allow for all of the square numbers to be displayed?
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 90,
                Description = 
@"
two cubes. each cube is a c(10,6) from set of char ('0', '1', '2', '3', '4', '5', '6', '7', '8', '6')
the combination of squares are {['0', '1'], ['0', '4'], ['0', '6'], ['1', '6'], ['2', '5'], ['3', '6'], ['4', '6'], ['6', '4'], ['8', '1']}
foreach combination(10, 6) for cube A
    foreach combination(10, 6 for cube B
        if cubeA & cubeB can compose each square numbers, it is counted

the total count is doubled because of the loops. devide it by 2.
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
            MoreMath.CombinationCalculator combinationCalculator = new MoreMath.CombinationCalculator();
            List<List<char>> c1Combinations = combinationCalculator.ListCombinations<char>(new List<char>{'0', '1', '2', '3', '4', '5', '6', '6', '7', '8'}, 6);
            List<List<char>> c2Combinations = combinationCalculator.ListCombinations<char>(new List<char>{'0', '1', '2', '3', '4', '5', '6', '6', '7', '8'}, 6);
            List<char[]> squares = 
                new List<char[]>{
                    new char[]{'0', '1'},
                    new char[]{'0', '4'},
                    new char[]{'0', '6'},
                    new char[]{'1', '6'},
                    new char[]{'2', '5'},
                    new char[]{'3', '6'},
                    new char[]{'4', '6'},
                    new char[]{'6', '4'},
                    new char[]{'8', '1'},
                };

            int count = 0;
            foreach(List<char> c1 in c1Combinations)
            {
                foreach(List<char> c2 in c2Combinations)
                {
                    bool ok = true;

                    foreach(char[] square in squares)
                    {
                        if (c1.Contains(square[0]) && c2.Contains(square[1]))
                            ok = true;
                        else if (c1.Contains(square[1]) && c2.Contains(square[0]))
                            ok = true;
                        else
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok) 
                    {
                        foreach (char c in c1)
                            Console.Write($"{c} ");
                        Console.Write("; ");
                        foreach (char c in c2)
                            Console.Write($"{c} ");
                        Console.WriteLine();
                        count ++;
                    }
                }
            }

            count /= 2;

            return count.ToString();
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
