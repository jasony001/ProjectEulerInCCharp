using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem81Solver : ProblemSolver
    {
        public Problem81Solver() : base()
        {
            Problem.Id = 81;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Path sum: two ways";
            Problem.Description = 
@"In the 5 by 5 matrix below, the minimal path sum from the top left to the bottom right, by only moving to the right and down, is indicated in bold red and is equal to 2427.

131 673 234 103 18
201 96  342 965 150
630 803 746 422 111 
537 699 497 121 956
805 732 524 37  331

Find the minimal path sum from the top left to the bottom right by only moving right and down in matrix.txt (right click and 'Save Link/Target As...'), a 31K text file containing an 80 by 80 matrix.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 81,
                Description = 
@"pivot the matrix in a diamod:

        131 
      201 673
    630 96  342
  531 803 342 103
805 699 746 965 18
  732 497 422 150
    524 121 111
      37 956
       331

starting the 2nd last row, for each number, pick the minimum connected number from the next row. sum it up and overwrite the number.
repeat to the first row.
the end result of the top number is the answer.
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
            int [][] rawNumbers = ReadRawNumbers();
            List<int>[] matrix = BuildMatrix(rawNumbers);
            int minSum = FindMinimalSum(matrix);

            return minSum.ToString();
        }

        private int FindMinimalSum(List<int>[] matrix)
        {
            
            for(int i = matrix.Length - 1; i > 0; i --)
            {
                if (matrix[i].Count < matrix[i - 1].Count)
                {
                    matrix[i-1][0] += matrix[i][0];
                    matrix[i-1][matrix[i-1].Count - 1] += matrix[i][matrix[i].Count - 1];

                    for(int j = 1; j < matrix[i - 1].Count - 1; j ++)
                    {
                        matrix[i - 1][j] += Math.Min(matrix[i][j -1], matrix[i][j]);
                    }
                }
                else
                {
                    for(int j = 0; j < matrix[i - 1].Count; j ++)
                    {
                        matrix[i - 1][j] += Math.Min(matrix[i][j], matrix[i][j + 1]);
                    }
                }
            }

            return matrix[0][0];
        }

        private List<int>[] BuildMatrix(int[][] rawNumbers)
        {
            
            List<int>[] matrix = new List<int>[159];
            for(int i = 0; i < 80; i ++)
            {
                matrix[i] = new List<int>();
                int x = 0;
                int y = i;
                while(x >=0 && y >= 0)
                {
                    matrix[i].Add(rawNumbers[x][y]);
                    x ++;
                    y --;
                }
            }

            for(int i = 80; i < 159; i ++)
            {
                matrix[i] = new List<int>();
                int x = i - 80 + 1;
                int y = 79;
                while(x < 80 && y < 80)
                {
                    matrix[i].Add(rawNumbers[x][y]);
                    x ++;
                    y --;
                }
            }

            return matrix;
        }

        private int[][] ReadRawNumbers()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader("p081_matrix.txt");
            string line = "";
            int [][] rawNumbers = new int[80][];
            int i = 0;
            while ((line = sr.ReadLine())!=null)
            {
                rawNumbers[i] = new int[80];
                string[] numberStrings = line.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
                for(int j = 0; j < 80; j ++)
                rawNumbers[i][j] = Convert.ToInt32(numberStrings[j]);
                i ++;
            }
            sr.Close();

            return rawNumbers;
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
