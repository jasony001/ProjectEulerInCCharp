using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem11Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {

            },
            new List<string>{
"        public override string solution2()",
"        {",
"            List<int> numbers = GetNumberList();",
"            List<List<int>> allLists = new List<List<int>>();",
"            allLists.AddRange(GetHorizontalLists_2(numbers));",
"            allLists.AddRange(GetVerticalLists_2(numbers));",
"            allLists.AddRange(GetForwardDiagonalLists_2(numbers));",
"            allLists.AddRange(GetBackDiagonalLists_2(numbers));",
"",
"            long maxP = 0;",
"",
"            foreach (List<int> list in allLists)",
"                maxP = Math.Max(maxP, GetMaxProductOf4(list));",
"",
"            return maxP.ToString();",
"        }",
"",
"        List<List<int>> GetForwardDiagonalLists_2(List<int> numbers)",
"        {",
"            List<int> forwardDiagonalStart = new List<int>{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19,",
"                    39, 59, 79, 99, 119, 139, 159, 179, 199, 219, 239, 259, 279, 299, 319, 339, 359, 379, 399};",
"",
"            List<List<int>> forwardDiagonalLists = new List<List<int>>();",
"",
"            foreach (int fs in forwardDiagonalStart)",
"            {",
"                int r = fs / 20;",
"                int c = fs % 20;",
"",
"                List<int> list = new List<int>();",
"                while (r >= 0 && r < 20 && c >= 0 && c < 20)",
"                {",
"                    list.Add(numbers[r * 20 + c]);",
"                    r++;",
"                    c--;",
"                }",
"",
"                forwardDiagonalLists.Add(list);",
"            }",
"",
"            return forwardDiagonalLists;",
"        }",
            }
        };

        int[][] grid = new int[][]
        {
            new int[] {08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
            new int[] {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00},
            new int[] {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
            new int[] {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
            new int[] {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
            new int[] {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
            new int[] {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
            new int[] {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
            new int[] {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
            new int[] {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
            new int[] {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
            new int[] {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
            new int[] {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
            new int[] {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
            new int[] {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
            new int[] {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
            new int[] {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
            new int[] {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
            new int[] {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
            new int[] {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48},
        };

        public Problem11Solver() : base()
        {
            Problem.Id = 11;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Largest product in a grid";
            Problem.Description =
                "In the 20×20 grid below, four numbers along a diagonal line have been marked in red.\n";

            Problem.Description = Problem.Description + "The product of these numbers is 26 × 63 × 78 × 14 = 1788696.\n";
            Problem.Description = Problem.Description + "What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?\n";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 11,
                Description = "no good",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 2,
                Description = "Flatten the grid, build rowLists, columnLists, ForwardDiagonalLists, backDiagonalLists. Then loop to find the max product of 4.",
                Version = 2,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            });
        }

        List<List<int>> GetHorizontalLists_1()
        {
            int i = 0;
            List<List<int>> lists = new List<List<int>>();

            while (i < 20)
            {
                List<int> list = new List<int>();
                int j = 0;
                while (j < 20)
                {
                    list.Add(grid[i][j++]);
                }

                lists.Add(list);
                i++;
            }

            return lists;
        }

        List<List<int>> GetVerticalLists_1()
        {
            int i = 0;
            List<List<int>> lists = new List<List<int>>();

            while (i < 20)
            {
                List<int> list = new List<int>();
                int j = 0;
                while (j < 20)
                {
                    list.Add(grid[j++][i]);
                }
                lists.Add(list);
                i++;
            }

            return lists;
        }

        List<List<int>> GetForwardDiagonalLists_1()
        {
            List<List<int>> fLists = new List<List<int>>();
            for (int s = 0; s < 39; s++)
            {
                List<int> list = new List<int>();
                for (int i = 0; i <= Math.Min(19, s); i++)
                {
                    int j = s - i;
                    if (j < 20)
                    {
                        try
                        {
                            list.Add(grid[i][j]);
                        }
                        catch (Exception ex)
                        {

                        }


                    }
                }
                fLists.Add(list);
            }


            return fLists;
        }

        List<List<int>> GetBackDiagonalLists_1()
        {
            List<List<int>> bLists = new List<List<int>>();
            for (int s = -19; s < 20; s++)
            {
                List<int> list = new List<int>();
                for (int i = Math.Max(0, s); i <= 19; i++)
                {
                    int j = s + i;
                    if (j < 20)
                    {
                        try
                        {
                            list.Add(grid[i][j]);
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                }
                bLists.Add(list);
            }


            return bLists;
        }

        long GetMaxProductOf4(List<int> list)
        {
            long maxP = 0;
            if (list.Count < 4) return 0;
            for (int i = 0; i < list.Count - 3; i++)
            {
                long p = 1;
                for (int j = 0; j < 4; j++)
                {
                    p *= list[i + j];
                }

                maxP = Math.Max(maxP, p);
            }

            return maxP;
        }

        public override string solution1()
        {
            long maxP = 0;

            List<List<int>> hLists = GetHorizontalLists_1();
            List<List<int>> vLists = GetVerticalLists_1();
            List<List<int>> fLists = GetForwardDiagonalLists_1();
            List<List<int>> bLists = GetBackDiagonalLists_1();

            List<List<int>> allLists = new List<List<int>>();
            allLists.AddRange(hLists);
            allLists.AddRange(vLists);
            allLists.AddRange(fLists);
            allLists.AddRange(bLists);


            foreach (List<int> list in allLists)
            {
                maxP = Math.Max(maxP, GetMaxProductOf4(list));
            }

            return maxP.ToString();
        }

        List<int> GetNumberList()
        {
            List<int> numbers = new List<int>();
            foreach (int[] line in grid)
            {
                foreach (int i in line)
                {
                    numbers.Add(i);
                }
            }

            return numbers;
        }

        List<List<int>> GetHorizontalLists_2(List<int> numbers)
        {
            List<int> rowStart = new List<int> { 0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220, 240, 260, 280, 300, 320, 340, 360, 380 };
            List<List<int>> rowLists = new List<List<int>>();

            foreach (int rs in rowStart)
            {
                List<int> list = new List<int>();
                for (int i = 0; i < 20; i++) list.Add(numbers[rs + i]);
                rowLists.Add(list);
            }

            return rowLists;
        }

        List<List<int>> GetVerticalLists_2(List<int> numbers)
        {
            List<int> columnStart = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            List<List<int>> columnLists = new List<List<int>>();


            foreach (int cs in columnStart)
            {
                List<int> list = new List<int>();
                for (int i = 0; i < 20; i++) list.Add(numbers[cs + i * 20]);
                columnLists.Add(list);
            }

            return columnLists;
        }

        List<List<int>> GetForwardDiagonalLists_2(List<int> numbers)
        {
            List<int> forwardDiagonalStart = new List<int>{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
                    39, 59, 79, 99, 119, 139, 159, 179, 199, 219, 239, 259, 279, 299, 319, 339, 359, 379, 399};

            List<List<int>> forwardDiagonalLists = new List<List<int>>();

            foreach (int fs in forwardDiagonalStart)
            {
                int r = fs / 20;
                int c = fs % 20;

                List<int> list = new List<int>();
                while (r >= 0 && r < 20 && c >= 0 && c < 20)
                {
                    list.Add(numbers[r * 20 + c]);
                    r++;
                    c--;
                }

                forwardDiagonalLists.Add(list);
            }

            return forwardDiagonalLists;
        }

        List<List<int>> GetBackDiagonalLists_2(List<int> numbers)
        {
            List<int> backDiagonalStart = new List<int>{380, 360, 340, 320, 300, 280, 260, 240, 220, 200, 180, 160, 140, 120, 100, 80, 60, 40, 20,
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };

            List<List<int>> backDiagonalLists = new List<List<int>>();

            foreach (int bs in backDiagonalStart)
            {
                List<int> list = new List<int>();
                int r = bs / 20;
                int c = bs % 20;
                while (r >= 0 && r < 20 && c >= 0 && c < 20)
                {
                    list.Add(numbers[r * 20 + c]);
                    r++;
                    c++;
                }

                backDiagonalLists.Add(list);
            }

            return backDiagonalLists;
        }

        public override string solution2()
        {
            List<int> numbers = GetNumberList();
            List<List<int>> allLists = new List<List<int>>();
            allLists.AddRange(GetHorizontalLists_2(numbers));
            allLists.AddRange(GetVerticalLists_2(numbers));
            allLists.AddRange(GetForwardDiagonalLists_2(numbers));
            allLists.AddRange(GetBackDiagonalLists_2(numbers));

            long maxP = 0;

            foreach (List<int> list in allLists)
                maxP = Math.Max(maxP, GetMaxProductOf4(list));

            return maxP.ToString();
        }
    }
}
