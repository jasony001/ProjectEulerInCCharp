using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem9Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {

            },
            new List<string>{

            }
        };


        public Problem9Solver() : base()
        {
            Problem.Id = 9;
            Problem.UpperBound = 1000;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Special Pythagorean triplet";
            Problem.Description =
                "A Pythagorean triplet is a set of three natural numbers, a < b < c, for which, a^2 + b^2 = c^2\n"
                + "For example, 3^2 + 4^2 = 5^2\n"
                + "There exists exactly one Pythagorean triplet for which a + b + c = 1000.\n"
                + "Find the product abc.\n";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 9,
                Description = "let a + b + c = s, a^2 + b^2 = c^2; \n c = s - a - b \n (s - a - b)^2 = a^2 + b^2 \n b = (s^2 -2as) / (2s -2a)\n try a from 1 to 997, when b is an integer, that's the answer",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 2,
            //     Description = "Build factor list, foreach number add dividen remainder",
            //     Version = 2,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            // });
        }

        public override string solution1()
        {
            for(long a = 1; a < Problem.CalculatedIncludedUpperBound; a ++)
            {
                long b1 = Problem.CalculatedIncludedUpperBound * Problem.CalculatedIncludedUpperBound 
                            - 2 * a * Problem.CalculatedIncludedUpperBound;
                long b2 = 2 * Problem.CalculatedIncludedUpperBound - 2 * a;

                if (b1 % b2 == 0)
                {
                    long b = b1 / b2;
                    long c = 1000 - a - b;

                    return (a * b * c).ToString();
                }
            }
            return "not solution found";
        }

    }
}
