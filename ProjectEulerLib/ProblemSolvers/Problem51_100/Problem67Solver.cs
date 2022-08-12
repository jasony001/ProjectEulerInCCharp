using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem67Solver : ProblemSolver
    {
        public Problem67Solver() : base()
        {
            Problem.Id = 67;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Maximum path sum II";
            Problem.Description = 
@"

By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

3
7 4
2 4 6
8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom in triangle.txt (right click and 'Save Link/Target As...'), a 15K text file containing a triangle with one-hundred rows.

NOTE: This is a much more difficult version of Problem 18. It is not possible to try every route to solve this problem, as there are 299 altogether! If you could check one trillion (1012) routes every second it would take over twenty billion years to check them all. There is an efficient algorithm to solve it. ;o)
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 67,
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
            System.IO.StreamReader sr = new System.IO.StreamReader("p067_triangle.txt");
            string line = "";
            List<List<int>> numberLines = new List<List<int>>();

            while((line = sr.ReadLine())!=null)
            {
                string [] numberStrings = line.Split(new char []{' '}, StringSplitOptions.RemoveEmptyEntries);
                List<int> numbers = new List<int>();
                foreach(string ns in numberStrings)
                    numbers.Add(Convert.ToInt32(ns));

                numberLines.Add(numbers);
            }
            sr.Close();

            for(int lineNumber = numberLines.Count - 2; lineNumber >= 0; lineNumber --)
            {
                for(int i = 0; i < numberLines[lineNumber].Count; i ++)
                {
                    numberLines[lineNumber][i] = numberLines[lineNumber][i] + Math.Max(numberLines[lineNumber + 1][i],  numberLines[lineNumber + 1][i + 1]);
                }
            }

            return numberLines[0][0].ToString();
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
