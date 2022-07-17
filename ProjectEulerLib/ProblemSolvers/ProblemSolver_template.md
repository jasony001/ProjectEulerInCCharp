using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class ProblemxxSolver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {

            },
            new List<string>{

            }
        };

        public ProblemxxSolver() : base()
        {
            Problem.Id = 99999;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 99999,
                Description = "",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "Flatten the grid, build rowLists, columnLists, ForwardDiagonalLists, backDiagonalLists. Then loop to find the max product of 4.",
            //     Version = 2,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            // });
        }

        public override string solution1()
        {
            return "";
        }

        public override string solution2()
        {
            return "";
        }
    }
}
