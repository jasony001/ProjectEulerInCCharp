using ProjectEulerDataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerLib
{
    public class Problem4Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {
" public override string solution1()",
"        {",
"            long maxP = 0;",
"            for (int i = 999; i > 100; i--)",
"            {",
"                for (int j = 999; j > 100; j--)",
"                {",
"                    long product = i * j;",
"                    if (product > 99999)",
"                    {",
"                        if (",
"                            product / 100000 == product % 10 &&",
"                            product / 10000 % 10 == product % 100 / 10 &&",
"                            product / 1000 % 10 == product % 1000 / 100",
"                        ) maxP = Math.Max(maxP, product);",
"                    }",
"                    else",
"                    {",
"                        if (",
"                            product / 10000 == product % 10 &&",
"                            product / 1000 % 10 == product % 100 / 10",
"                        ) maxP = Math.Max(maxP, product);",
"                    }",
"                }",
"            }",
"            return maxP.ToString();",
"        }",
            },
            new List<string>{

            }
        };

        public Problem4Solver() : base()
        {
            Problem.Id = 4;
           
            Problem.Title = "Largest palindrome product";
            Problem.Description =
                "A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.\n"
                    + "\n"
                    + "Find the largest palindrome made from the product of two 3-digit numbers.\n";


            Problem.Solutions.Add(new Solution
            {
                ProblemId = 4,
                Description = "Loop, save max",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 2,
                Description = "Go through each palindrome numbers, big to small, check IsProdOfTwo3DigitsNumbers",
                Version = 2,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            });
        }

        public override string solution1()
        {
            long maxP = 0;
            for (int i = 999; i > 100; i--)
            {
                for (int j = 999; j > 100; j--)
                {
                    long product = i * j;
                    if (product > 99999)
                    {
                        if (
                            product / 100000 == product % 10 &&
                            product / 10000 % 10 == product % 100 / 10 &&
                            product / 1000 % 10 == product % 1000 / 100
                        ) maxP = Math.Max(maxP, product);
                    }
                    else
                    {
                        if (
                            product / 10000 == product % 10 &&
                            product / 1000 % 10 == product % 100 / 10
                        ) maxP = Math.Max(maxP, product);
                    }
                }
            }
            return maxP.ToString();
        }

        public override string solution2()
        {
            for(long a = 9; a > 0; a --)
            {
                for(long b = 9; b >= 0; b --)
                {
                    for(long c = 9; c >= 0; c --)
                    {
                        long n = a * 100000 + b * 10000 + c * 1000 + c * 100 + b * 10 + a;
                        if (IsProdOfTwo3DigitsNumbers(n))
                            return n.ToString();
                    }
                }
            }

            // 5 digits number. wouldn't reach here.
            for(long a = 9; a > 0; a --)
            {
                for(long b = 9; b >= 0; b --)
                {
                    for(long c = 9; c >= 0; c --)
                    {
                        long n = a * 100000 + b * 10000 + c * 1000+ b * 10 + a;
                        if (IsProdOfTwo3DigitsNumbers(n))
                            return n.ToString();
                    }
                }
            }

            return "10201";
        }

        public bool IsProdOfTwo3DigitsNumbers(long n)
        {
            long sqrtOfN = (long)Math.Sqrt(n);
            for(long i = sqrtOfN; i > 100; i --)
            {
                if (n % i == 0)
                {
                    long f = n / i;
                    if (f > 100 && f < 1000)
                    {
                        Console.WriteLine($"{n} {i} {n/i} {n%i}");
                        return true;
                    }
                }
                    
            }

            return false;
        }

    }
}