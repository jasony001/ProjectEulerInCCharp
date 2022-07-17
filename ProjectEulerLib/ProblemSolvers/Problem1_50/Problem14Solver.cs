using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem14Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {

            },
            new List<string>{

            }
        };

        public Problem14Solver() : base()
        {
            Problem.Id = 14;
            Problem.UpperBound = 1000000;
            Problem.IsClosedOnRight = false;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 14,
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

        public List<long> getStepCountList(long n, List<long> stepCountList)
        {
            long solvedNumbersCount = stepCountList.Count - 1;

            if (n <= solvedNumbersCount) return stepCountList;
            if (n > solvedNumbersCount + 1)
            {
                stepCountList = getStepCountList(n -1, stepCountList);

                return getStepCountList(n, stepCountList);
            }

            long c = n;
            long steps = 0;
            do 
            {
                steps ++;
                if (c %2 == 0)
                    c/=2;
                else
                    c = 3 * c + 1;
            } while (c >= n);
            stepCountList.Add(steps + stepCountList[(int)c]);

            return stepCountList;
        }

        public override string solution1()
        {
            List<long> stepCountList = new List<long>{0, 1, 2, 8};
            
            long maxSteps = 0;
            long answer = 0;
            for(long n = 4; n <= Problem.CalculatedIncludedUpperBound; n ++)
            {
                stepCountList = getStepCountList(n, stepCountList);
                if (stepCountList[stepCountList.Count - 1] > maxSteps)
                {
                    maxSteps = stepCountList[stepCountList.Count - 1];
                    answer = n;
                    Console.WriteLine($"n = {n}; steps = {maxSteps}");
                }
            }

            return answer.ToString();
        }

        public override string solution2()
        {
            return "";
        }
    }
}
