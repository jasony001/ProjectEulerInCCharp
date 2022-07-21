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
            int count = 0;
            int wrongNumerator = -1;
            int wrongDenomenator = -1;
            int numerator = 11;
            int denomenator = 12;
            long productOfWrongNumerators = 1;
            long productOfWrongDenomenators = 1;

        try{
            for ( numerator = 11; numerator < 100; numerator ++)
            {
                for( denomenator = numerator + 1; denomenator < 100; denomenator ++)
                {
                     wrongNumerator = -1;
                     wrongDenomenator = -1;
                    if (denomenator.ToString()[0] == numerator.ToString()[0] && numerator.ToString()[0] != '0')
                    {
                        wrongNumerator = numerator.ToString()[1] - '0';
                        wrongDenomenator = denomenator.ToString()[1] - '0';
                    } else if (denomenator.ToString()[1] == numerator.ToString()[0] && numerator.ToString()[0] != '0')
                    {
                        wrongNumerator = numerator.ToString()[1] - '0';
                        wrongDenomenator = denomenator.ToString()[0] - '0';
                    } else if (denomenator.ToString()[0] == numerator.ToString()[1] && numerator.ToString()[1] != '0')
                    {
                        wrongNumerator = numerator.ToString()[0] - '0';
                        wrongDenomenator = denomenator.ToString()[1] - '0';
                    } else if (denomenator.ToString()[1] == numerator.ToString()[1] && numerator.ToString()[1] != '0')
                    {
                        wrongNumerator = numerator.ToString()[0] - '0';
                        wrongDenomenator = denomenator.ToString()[0] - '0';
                    } else
                    {
                        continue;
                    }

                    if (wrongNumerator * denomenator == numerator * wrongDenomenator)
                    {

                        productOfWrongNumerators *= wrongNumerator;
                        productOfWrongDenomenators *= wrongDenomenator;
                        Console.WriteLine($"{numerator}/{denomenator} = {wrongNumerator}/{wrongDenomenator}");
                        count ++;
                    }

                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"{ex.Message}: {numerator}/{denomenator}; {wrongNumerator}/{wrongDenomenator}");
        }

            return $"{productOfWrongNumerators}/{productOfWrongDenomenators}";
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
