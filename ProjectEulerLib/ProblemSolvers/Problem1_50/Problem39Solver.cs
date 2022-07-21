using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem39Solver : ProblemSolver
    {
        public Problem39Solver() : base()
        {
            Problem.Id = 399;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Integer right triangles";
            Problem.Description = 
@"If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.

{20,48,52}, {24,45,51}, {30,40,50}

For which value of p ≤ 1000, is the number of solutions maximised?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 399,
                Description = "loop: a < c, b < c, a + b + c <= 1000.",
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
            Dictionary<int, int> pDict = new Dictionary<int, int>();
            for(int a = 1; a <=998; a ++)
            {
                for(int b = 1; b <= 998 - a; b ++)
                {
                    for(int c = Math.Max(a, b) + 1; c <= 1000 - a - b; c++)
                    {
                        if (a * a + b* b == c * c)
                        {
                            if (pDict.ContainsKey(a+b+c)) 
                                pDict[a+b+c] = pDict[a+b+c] + 1;
                            else 
                                pDict[a+b+c] = 1;
                        }
                    }
                }
            }

            int maxCount = 0;
            int maxCountP = 0;
            foreach (int key in pDict.Keys)
            {
                if (pDict[key] > maxCount)
                {
                    maxCount = pDict[key];
                    maxCountP = key;
                }
            }

            return maxCountP.ToString();
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
