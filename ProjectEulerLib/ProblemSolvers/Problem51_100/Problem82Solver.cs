using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem82Solver : ProblemSolver
    {
        public Problem82Solver() : base()
        {
            Problem.Id = 82;
            Problem.UpperBound = 80;
            Problem.IsClosedOnRight = false;
            Problem.Title = "Path sum: three ways";
            Problem.Description = 
@"NOTE: This problem is a more challenging version of Problem 81.

The minimal path sum in the 5 by 5 matrix below, by starting in any cell in the left column and finishing in any cell in the right column, and only moving up, down, and right, is indicated in red and bold; the sum is equal to 994.

        { 131, 201, 630, 537, 805 },
        { 673, 96,  803, 699, 732},
        { 234, 342, 746, 497, 524},
        { 103, 965, 422, 121, 37},
        { 18,  150, 111, 956, 331}


Find the minimal path sum from the left column to the right column in matrix.txt (right click and 'Save Link/Target As...'), a 31K text file containing an 80 by 80 matrix.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 82,
                Description = 
@"starting from the 2nd last column, for each number, calculate the minimum sum from that number to the next column (top number to bottom number),
for example, in the 5 X 5 matrix, the minimum sum from 121 (the 4th number in the 2nd last column) to the last column is 121+422+111
overwrite the 2nd last column with the calculated minimum sums,
continue to 3rd last column, ..., first column",
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
            int[][] matrix = ReadRawNumbers();

            for(int c0Index = (int)Problem.UpperBound - 2; c0Index >= 0; c0Index --)
            {
                int [][] tempMatrix = new int[(int)Problem.UpperBound][];
                for(int i = 0; i < (int)Problem.UpperBound; i ++)
                {
                    tempMatrix[i] = new int[(int)Problem.UpperBound];
                    for(int j = 0; j < (int)Problem.UpperBound; j ++)
                        tempMatrix[i][j] = matrix[i][j];
                }

                int[] c0 = tempMatrix[c0Index];
                int[] c1 = tempMatrix[c0Index + 1];

                for(int y0 = 0; y0 < (int)Problem.UpperBound; y0 ++)
                {
                    int minSum = int.MaxValue;
                    for(int y1 = 0; y1 < (int)Problem.UpperBound; y1 ++)
                    {
                        minSum = Math.Min(minSum, MinSum(tempMatrix, c0Index, c0Index + 1, y0, y1));
                    }
                    matrix[c0Index][y0] = minSum;
                }
            }

            int min = int.MaxValue;
            for(int i = 0; i < (int)Problem.UpperBound; i ++)
            min = Math.Min(min, matrix[0][i]);

            return min.ToString();
        }

        int MinSum(int[][] matrix, int x0, int x1, int y0, int y1)
        {
            if (x0 + 1 != x1) throw new Exception("Invalid path");

            int[] c0 = matrix[x0];
            int[] c1 = matrix[x1];

            if (y0 == y1) return c0[y0] + c1[y0];

            int min = int.MaxValue;

            if (y0 < y1)
            {
                for(int turn = y0; turn <=y1; turn ++)
                {
                    int sum = 0;
                    for(int step1 = y0; step1 <= turn; step1 ++)
                    {
                        sum += c0[step1];
                    }
                    for(int step2 = turn; step2 <= y1; step2 ++)
                    {
                        sum += c1[step2];
                    }

                    min = Math.Min(min, sum);
                }
            }
            else
            {
                for(int turn = y0; turn >= y1; turn --)
                {
                    int sum = 0;
                    for(int step1 = y0; step1 >= turn; step1 --)
                    {
                        sum += c0[step1];
                    }
                    for(int step2 = turn; step2 >= y1; step2 --)
                    {
                        sum += c1[step2];
                    }

                    min = Math.Min(min, sum);
                }
            }

            return min;
        }

        private int[][] ReadRawNumbers()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader("p082_matrix.txt");
            string line = "";
            int [][] rawNumbers = new int[(int)Problem.UpperBound][];
            for(int c = 0; c < (int)Problem.UpperBound; c ++)
            {
                rawNumbers[c] = new int[(int)Problem.UpperBound];
            }

            int i = 0;
            while ((line = sr.ReadLine())!=null)
            {
                string[] numberStrings = line.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
                for(int j = 0; j < (int)Problem.UpperBound; j ++)
                    rawNumbers[j][i] = Convert.ToInt32(numberStrings[j]);
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
