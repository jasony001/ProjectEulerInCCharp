using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem27Solver : ProblemSolver
    {
        long [] primesUnder1M;
        long [] primesUnder1000;

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {
"           public override string solution1()",
"           {",
"            primesUnder1M = new MoreMath.PrimeCalculator().SeiveOfEratosthenes(1000000);",
"            primesUnder1000 = primesUnder1M.Where(p => p < 1000).ToArray();            ",
"            int maxN = 0;",
"            int maxA = 0;",
"            int maxB = 0;",
"",
"            foreach(long b in primesUnder1000)",
"            {",
"                int pCount = 0;",
"                for(int a = (int)(1 - b); a <= 1000; a ++)",
"                {",
"                    if (!primesUnder1000.Contains(1 + a + b)) continue;",
"                    if (!primesUnder1000.Contains(b)) continue;",
"                    if (!primesUnder1000.Contains(4 + 2*a + b)) continue;",
"                    ",
"                    int n = 3;",
"                    long p = f(n, a, (int)b);",
"                    while (primesUnder1M.Contains(p))",
"                    {",
"                        p = f(++n, a, (int)b);",
"                    }",
"                    n --;",
"                    if (n > maxN)",
"                    {",
"                        maxN = n;",
"                        maxA = a;",
"                        maxB = (int)b;",
"                    }",
"                }",
"            }",
"",
"            string mSign = (maxA < 0) ? \"-\" : \"+\";",
"            return $\"{maxA * maxB}. n^2 {mSign}{maxA}n + {maxB} produces {maxN} primes \";",
"        }",

            },
            new List<string>{

            },
            new List<string>{

            }
        };

        public Problem27Solver() : base()
        {
            Problem.Id = 27;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Quadratic primes";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 27,
                Description = "loop with some constrains: b is a prime, so b >=2; 1 + a + b is a prime, so a >= 1 -b",
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
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "Flatten the grid, build rowLists, columnLists, ForwardDiagonalLists, backDiagonalLists. Then loop to find the max product of 4.",
            //     Version = 3,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            // });
        }

        public override string solution1()
        {
            primesUnder1M = new MoreMath.PrimeCalculator().SeiveOfEratosthenes(1000000);
            primesUnder1000 = primesUnder1M.Where(p => p < 1000).ToArray();            
            // long product = 0;
            int maxN = 0;
            int maxA = 0;
            int maxB = 0;

            foreach(long b in primesUnder1000)
            {
                for(int a = (int)(1 - b); a <= 1000; a ++)
                {
                    if (!primesUnder1000.Contains(1 + a + b)) continue;
                    if (!primesUnder1000.Contains(b)) continue;
                    if (!primesUnder1000.Contains(4 + 2*a + b)) continue;
                    
                    int n = 3;
                    long p = f(n, a, (int)b);
                    while (primesUnder1M.Contains(p))
                    {
                        p = f(++n, a, (int)b);
                    }
                    n --;
                    if (n > maxN)
                    {
                        maxN = n;
                        maxA = a;
                        maxB = (int)b;
                        // product = a * b;
                        // string sign = (a < 0) ? "-" : "+";
                        // Console.WriteLine($"n^2 {sign}{a}n + {b}: {maxN} primes produced");
                    }
                }
            }

            // Console.WriteLine();
            // Console.WriteLine();
            // Console.WriteLine();

            string mSign = (maxA < 0) ? "-" : "+";
            // $"{maxA * maxB}. n^2 {mSign}{maxA}n + {maxB} {maxN} primes ";

            return $"{maxA * maxB}. n^2 {mSign}{maxA}n + {maxB} produces {maxN} primes ";
        }

        public long f(int n, int a, int b)
        {
            return n * n + n * a + b;
        }

    }
}
