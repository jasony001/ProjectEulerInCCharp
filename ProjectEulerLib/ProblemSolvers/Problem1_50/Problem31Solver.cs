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
            Problem.UpperBound = 200;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Coin sums";
            Problem.Description = 
@"In the United Kingdom the currency is made up of pound (£) and pence (p). There are eight coins in general circulation:

    1p, 2p, 5p, 10p, 20p, 50p, £1 (100p), and £2 (200p).

It is possible to make £2 in the following way:

    1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p

How many different ways can £2 be made using any number of coins?";

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
            MoreMath.CombinationCalculator worker = new MoreMath.CombinationCalculator();
            List<int> coinTypes = new List<int>{200, 100, 50, 20, 10, 5, 2, 1};
            int answer = 0;

            for(int i = 1; i <= 8; i ++)
            {
                foreach(List<int> combination in worker.ListCombinations(coinTypes, i))
                {
                    if (i == 1) { answer ++; continue;}
                    if (i == 2 ) { if (combination[0] < 200) answer += (200 - combination[0]) / combination[0]; continue;}

                    int [] numberOfCoin = new int[combination.Count];
                    foreach(int n in numberOfCoin) numberOfCoin[n] = 1;

                    Dictionary<int, int> coinDict = new Dictionary<int, int>();
                    for(int ci = 0; ci < combination.Count - 2; ci ++)
                    {
                        coinDict.Add(combination[ci], 1);
                    }

                    int max0 = 200 / coinDict.Keys.ToArray()[0];
                    while(coinDict[coinDict.Keys.ToArray()[0]] < max0)
                    {
                        int sum = 0;
                        for(int c = 0; c < coinDict.Keys.Count; c ++)
                        {
                            sum += coinDict[coinDict.Keys.ToArray()[c]] * coinDict.Keys.ToArray()[c];
                        }
                        // if (sum < 200)
                        // {
                            int r = (200 - sum) % combination[combination.Count - 2];
                            answer += (200 - sum) / combination[combination.Count - 2] - (r == 0 ? 1 : 0);
                        // }
                        
                        coinDict = IncreaseOdometer(coinDict, 200);
                    }
                }
            }

            return answer.ToString();
        }

        Dictionary<int, int> IncreaseOdometer(Dictionary<int, int> coinDict, int limit)
        {
            int position = coinDict.Keys.Count() - 1;
            coinDict[coinDict.Keys.ToArray()[position]] ++;
            while (coinDict.Values.Sum(v => v) >= limit && position > 0)
            {
                coinDict[coinDict.Keys.ToArray()[position]] = 1;
                coinDict[coinDict.Keys.ToArray()[position - 1]] ++;
            }


            return coinDict;
        }

        public override string solution2()
        {
            return "";
        }
    }
}
