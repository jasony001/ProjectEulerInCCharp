using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem28Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {

            },
            new List<string>{

            },
            new List<string>{

            }
        };

        public Problem28Solver() : base()
        {
            Problem.Id = 28;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Number spiral diagonals";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 28,
                Description = "When the size is s, the 4 corners are s^2, s^2 - (s - 1), s^2 - 2(s - 1), s^2 - 3(s - 1)",
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
            long sum = 1;
            int l = 3;
            while(l <= 1001)
            {
                sum += 4 * l * l - 6 * l + 6;
                l +=2;
            }

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
