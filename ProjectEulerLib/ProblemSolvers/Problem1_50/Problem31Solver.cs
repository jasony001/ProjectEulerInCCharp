using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem31Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {

            },
            new List<string>{

            }
        };

        public Problem31Solver() : base()
        {
            Problem.Id = 31;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 31,
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

        long GetWays(int sum, List<int> coinValues)
        {
            if (sum <= 0) return 0;
            if (sum == 1) return 1;
            if (coinValues.Count == 1) return 1;

            long ways = 0;

            int maxCoinValue = coinValues.Where( c => c <= sum).Max();
            while (sum >= maxCoinValue)
            {
                long waysWith1MaxCoin = GetWays(sum - maxCoinValue, coinValues.Where(c => c < maxCoinValue).ToList());
                long waysWithoutMaxCoin = GetWays(sum, coinValues.Where(c => c < maxCoinValue).ToList());
                ways += waysWith1MaxCoin + waysWithoutMaxCoin;
                sum -= maxCoinValue;
            }

            return ways;
        }

        public override string solution1()
        {
            return GetWays(8, new List<int>{200, 100, 50, 20, 10, 5, 2, 1}).ToString();
        }

        public override string solution2()
        {
            return "";
        }
    }
}
