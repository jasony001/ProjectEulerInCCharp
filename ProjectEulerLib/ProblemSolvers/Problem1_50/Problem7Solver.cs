using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem7Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {
"        public override string solution1()",
"        {",
"            ProjectEulerLib.MoreMath.PrimeCalculator primeCalculator = new ProjectEulerLib.MoreMath.PrimeCalculator();",
"            long upperBound = Problem.CalculatedIncludedUpperBound * 2;",
"            long increment = Problem.CalculatedIncludedUpperBound * 2;",
"            long [] primes =  primeCalculator.SeiveOfEratosthenes(upperBound);",
"            while (primes.Length < Problem.CalculatedIncludedUpperBound + 1)",
"            {",
"                upperBound += increment;",
"                primes = primeCalculator.SeiveOfEratosthenes(primes, upperBound);",
"            }",
"",
"            return primes[Problem.CalculatedIncludedUpperBound].ToString();",
"        }",
"",
"        public long [] SeiveOfEratosthenes(long [] knownPrimes, long n)",
"        {",
"            long sqrtOfN = (long)(System.Math.Sqrt(n));",
"            bool [] bArray = new bool [n + 1];",
"            foreach(long p in knownPrimes)",
"            {",
"                bArray[p] = true;",
"            }",
"            ",
"            long newLowerBound = knownPrimes[knownPrimes.Length - 1] + 1;",
"",
"            for(long x = newLowerBound; x <= n; x ++)",
"            {",
"                bArray[x] = true;",
"            }",
"",
"            for(long i = 2; i <= sqrtOfN; i ++)",
"            {",
"                if (bArray[i])",
"                {",
"                    long start = (newLowerBound % i > 0) ? (newLowerBound - newLowerBound % i + i) : newLowerBound;",
"                    ",
"                    for(long j = start; j <= n; j +=i)",
"                    {",
"                        bArray[j] = false;",
"                    }",
"                }",
"            }",
"",
"            List<long> list = new List<long>();",
"            for(int i = 0; i <= n; i ++)",
"            {",
"                if (bArray[i]) list.Add(i);",
"            }",
"",
"            return list.ToArray();",
"        }",

            },
            new List<string>{

            }
        };

        public Problem7Solver() : base()
        {
            Problem.Id = 7;
            Problem.Title = "10001st prime";
            Problem.UpperBound = 10001;
            Problem.IsClosedOnRight = false;
            Problem.Description =
                "By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.\n"
                    + "\n"
                    + "What is the 10 001st prime number?\n";


            Problem.Solutions.Add(new Solution
            {
                ProblemId = 7,
                Description = "Incremental SeiveOfEratosthenes. Starts from 20000, increment of 20000.",
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
            ProjectEulerLib.MoreMath.PrimeCalculator primeCalculator = new ProjectEulerLib.MoreMath.PrimeCalculator();
            long upperBound = Problem.CalculatedIncludedUpperBound * 2;
            long increment = Problem.CalculatedIncludedUpperBound * 2;
            long [] primes =  primeCalculator.SeiveOfEratosthenes(upperBound);
            while (primes.Length < Problem.CalculatedIncludedUpperBound + 1)
            {
                upperBound += increment;
                primes = primeCalculator.SeiveOfEratosthenes(primes, upperBound);
            }

            return primes[Problem.CalculatedIncludedUpperBound].ToString();
        }

    }
}
