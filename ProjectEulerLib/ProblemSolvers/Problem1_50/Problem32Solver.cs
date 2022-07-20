using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem32Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {
"        public bool IsPandigitalNumber(string s)",
"        {",
"            if (s.Length != 9) return false;",
"            char[] charArray = s.ToArray().Where(c => c != '0').Distinct().ToArray();",
"",
"            return charArray.Length == 9;",
"        }",
"",
"        public override string solution1()",
"        {",
"            List<long> resultList = new List<long>();",
"",
"            for(int i1 = 1; i1 <= 9; i1 ++)",
"            {",
"                for(long i4 = 1234; i4 <= 9876; i4 ++)",
"                {",
"                    long prod = i1 * i4;",
"                    if (IsPandigitalNumber(i1.ToString() + i4.ToString() + prod.ToString()) && !resultList.Contains(prod))",
"                        resultList.Add(prod);",
"                }",
"            }",
"",
"            for(int i2 = 12; i2 <= 98; i2 ++)",
"            {",
"                for(long i3 = 123; i3 <= 987; i3 ++)",
"                {",
"                    long prod = i2 * i3;",
"                    if (IsPandigitalNumber(i2.ToString() + i3.ToString() + prod.ToString()) && !resultList.Contains(prod))",
"                        resultList.Add(prod);",
"                }",
"            }",
"",
"            return resultList.Sum(r => r).ToString();",
"        }",

            },
            new List<string>{

            },
            new List<string>{

            }
        };

        public Problem32Solver() : base()
        {
            Problem.Id = 32;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Pandigital products";
            Problem.Description = 
@"We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.

The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 32,
                Description = "possible equations: 1d * 4d = 4d; 2d * 3d = 4d. that's it. loop through all, check if the product qualify.",
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

        public bool IsPandigitalNumber(string s)
        {
            if (s.Length != 9) return false;
            char[] charArray = s.ToArray().Where(c => c != '0').Distinct().ToArray();

            return charArray.Length == 9;
        }

        public override string solution1()
        {
            List<long> resultList = new List<long>();

            for(int i1 = 1; i1 <= 9; i1 ++)
            {
                for(long i4 = 1234; i4 <= 9876; i4 ++)
                {
                    long prod = i1 * i4;
                    if (IsPandigitalNumber(i1.ToString() + i4.ToString() + prod.ToString()) && !resultList.Contains(prod))
                        resultList.Add(prod);
                }
            }

            for(int i2 = 12; i2 <= 98; i2 ++)
            {
                for(long i3 = 123; i3 <= 987; i3 ++)
                {
                    long prod = i2 * i3;
                    if (IsPandigitalNumber(i2.ToString() + i3.ToString() + prod.ToString()) && !resultList.Contains(prod))
                        resultList.Add(prod);
                }
            }

            return resultList.Sum(r => r).ToString();
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
