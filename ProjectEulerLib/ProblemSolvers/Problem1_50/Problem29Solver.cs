using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem29Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {
"           Dictionary<int, bool[]> dict = new Dictionary<int, bool[]>();",
"            for(int n = 2; n <= 100; n ++) dict.Add(n, new bool[1]);",
"",
"            for(int n = 2; n <= 100; n ++)",
"            {",
"                if (!dict.ContainsKey(n)) continue;",
"",
"                int maxPow = 1;",
"                while(Math.Pow(n, maxPow + 1) <= 100)",
"                {",
"                    maxPow ++;",
"                    dict.Remove((int)Math.Pow(n, maxPow));",
"                }",
"",
"                dict[n] = new bool[maxPow * 100 + 1];",
"                for(int p = 2; p <= 100; p ++)",
"                    for(int m = 1; m <= maxPow; m ++) ",
"                        dict[n][m * p] = true;",
"            }",
"",
"            int sum = 0;",
"            foreach (int key in dict.Keys)",
"                sum += dict[key].Where(b => b).Count();",
"",
"            return sum.ToString();",
            },
            new List<string>{

            },
            new List<string>{

            }
        };

        public Problem29Solver() : base()
        {
            Problem.Id = 10;
            Problem.UpperBound = 10;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Distinct powers";
            Problem.Description =
@"Consider all integer combinations of ab for 2 ≤ a ≤ 5 and 2 ≤ b ≤ 5:

    2^2=4, 2^3=8, 2^4=16, 2^5=32
    3^2=9, 3^3=27, 3^4=81, 3^5=243
    4^2=16, 4^3=64, 4^4=256, 4^5=1024
    5^2=25, 5^3=125, 5^4=625, 5^5=3125

If they are then placed in numerical order, with any repeats removed, we get the following sequence of 15 distinct terms:

4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125

How many distinct terms are in the sequence generated by ab for 2 ≤ a ≤ 100 and 2 ≤ b ≤ 100?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 29,
                Description =
@"Build a dictionary<int, bool[]>, size of the bool array not determined yet.
loop through 2 to 100, find max power. 2 -> 6, 3 ->4, ... 10->2, 11-> 1. Remove the key value pair for any 2nd or up power. For example, 4, 8, 16, 32, 64, 9, 27, 81, 25, 36, ...
mark 1(1...100), 2(1...100), ...6(1...100) items to true in the [2] bool array
mark (1...100), ... 4(1...100) items to true in the [2] bool array
...
count all the bool items in all the bool array
",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "",
            //     Version = 2,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            // });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "",
            //     Version = 3,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[2])
            // });
        }

        public override string solution1()
        {
            Dictionary<int, bool[]> dict = new Dictionary<int, bool[]>();
            for (int n = 2; n <= 100; n++) dict.Add(n, new bool[1]);

            for (int n = 2; n <= 100; n++)
            {
                if (!dict.ContainsKey(n)) continue;

                int maxPow = 1;
                while (Math.Pow(n, maxPow + 1) <= 100)
                {
                    maxPow++;
                    dict.Remove((int)Math.Pow(n, maxPow));
                }

                dict[n] = new bool[maxPow * 100 + 1];
                for (int p = 2; p <= 100; p++)
                    for (int m = 1; m <= maxPow; m++)
                        dict[n][m * p] = true;
            }

            int sum = 0;
            foreach (int key in dict.Keys)
                sum += dict[key].Where(b => b).Count();

            return sum.ToString();
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