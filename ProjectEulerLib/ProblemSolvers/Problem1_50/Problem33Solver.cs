using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem33Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {

            },
            new List<string>{

            },
            new List<string>{

            }
        };

        public Problem33Solver() : base()
        {
            Problem.Id = 33;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Digit cancelling fractions";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 33,
                Description = "",
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
            List<int[]> fractionList = new List<int[]>();
            for(int i1 = 2; i1 <= 9; i1 ++)
            {
                for(int i0 = i1; i0 <= 9; i0 ++)
                {
                    int numerator = i1 * 10 + i0;
                    for(int i2 = 1; i2 <= 9; i2 ++)
                    {
                        int denominator = i0 * 10 + i2;
                        if (denominator <= numerator) continue;

                        if ((double)i1 / (double)i2 == (double)numerator / (double)denominator)
                        {
                            fractionList.Add(new int[]{numerator, denominator});
                            Console.WriteLine($"{numerator}/{denominator}");
                        }
                    }
                }
            }

            return fractionList.Count.ToString();
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
