using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem14Solver : ProblemSolver
    {

        public Problem14Solver() : base()
        {
            Problem.Id = 14;
            Problem.UpperBound = 1000000;
            Problem.IsClosedOnRight = false;
            Problem.Title = "Longest Collatz sequence";
            Problem.Description = @"The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:
13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 14,
                Description = "",
                Version = 1,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 0,
                Description = "",
                Version = 2,
            });
        }

        public List<long> getStepCountList(long n, List<long> stepCountList)
        {
            long solvedNumbersCount = stepCountList.Count - 1;

            if (n <= solvedNumbersCount) return stepCountList;
            if (n > solvedNumbersCount + 1)
            {
                stepCountList = getStepCountList(n - 1, stepCountList);

                return getStepCountList(n, stepCountList);
            }

            long c = n;
            long steps = 0;
            do
            {
                steps++;
                if (c % 2 == 0)
                    c /= 2;
                else
                    c = 3 * c + 1;
            } while (c >= n);
            stepCountList.Add(steps + stepCountList[(int)c]);

            return stepCountList;
        }

        public override string solution1()
        {
            List<long> stepCountList = new List<long> { 0, 1, 2, 8 };

            long maxSteps = 0;
            long answer = 0;
            for (long n = 4; n <= Problem.CalculatedIncludedUpperBound; n++)
            {
                stepCountList = getStepCountList(n, stepCountList);
                if (stepCountList[stepCountList.Count - 1] > maxSteps)
                {
                    maxSteps = stepCountList[stepCountList.Count - 1];
                    answer = n;
                }
            }

            return answer.ToString();
        }

        public override string solution2()
        {
            List<long> stepCountList = new List<long> { 0, 1, 2, 8 };

            long maxSteps = 0;
            long steps = 0;
            for (long n = 4; n <= Problem.CalculatedIncludedUpperBound; n++)
            {
                try
                {
                    
                long c = n;
                steps = 0;
                while (c != 1)
                {

                    if (c < stepCountList.Count)
                    {
                        steps += stepCountList[(int)c];
                        break;
                    }
                    else
                    {
                        if (c % 2 == 0)
                            c /= 2;
                        else
                            c = c * 3 + 1;

                        steps++;
                    }
                }

                stepCountList.Add(steps);
                maxSteps = Math.Max(maxSteps, steps);

                }
                catch (System.Exception ex)
                {
                    
                    Console.WriteLine(n.ToString() + "-" + steps.ToString() + ": " + ex.Message);
                    return "failed";
                }
            }
            return maxSteps.ToString();
        }

        // public override string solution3()
        // {
        //     try
        //     {
        //     int maxSteps = 0;
        //     int maxN = 0;
        //     for(int i = 1; i < 1000000; i ++)
        //     {
        //         int steps = CountSteps(i);
        //         if (steps > maxSteps)
        //         {
        //             maxN = i;
        //             maxSteps = steps;
        //         }
        //     }
        //     return maxN.ToString();
        //     }
        //     catch(Exception ex)
        //     {
        //         return ex.Message;
        //     }
        // }

        // int CountSteps(int n)
        // {
        //     if (n == 1) return 1;
        //     if (n % 2 == 0) return CountSteps(n / 2) + 1;
        //     return CountSteps(n * 3 + 1) + 1;
        // }
    }
}
