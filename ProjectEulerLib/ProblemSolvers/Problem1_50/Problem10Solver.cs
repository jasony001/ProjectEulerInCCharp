using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;
using System.IO;
using ProjectEulerLib.MoreMath;

namespace ProjectEulerLib
{
    public class Problem10Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {
"public override long solution1()",
"        {",
"            long sum = 0;",
"            foreach(long n in SeiveOfEratosthenes(Problem.CalculatedIncludedUpperBound))",
"                sum +=n;",
"",
"            return sum;",
"        }",
"",
"        public override long solution2()",
"        {",
"            return 0;",
"        }",
"",
"        public long [] SeiveOfEratosthenes(long upperBound)",
"        {",
"            long sqrtOfN = (long)(Math.Sqrt(upperBound));",
"            bool [] bArray = new bool [upperBound + 1];",
"            for(long i = 0; i <= upperBound; i ++) bArray[i] = true;",
"            bArray[0] = false;",
"            bArray[1] = false;",
"",
"            for(long i = 2; i <= sqrtOfN; i ++)",
"            {",
"                for(long m = i * 2; m <=upperBound; m +=i)",
"                {",
"                    bArray[m] = false;",
"                }",
"            }",
"",
"            List<long> list = new List<long> ();",
"            long index = 0;",
"            while (index <= upperBound)",
"            {",
"                if (bArray[index]) list.Add(index);",
"                index ++;",
"            }",
"",
"            return list.ToArray();",
"        }",
            },
            new List<string>{

            }
        };

        public Problem10Solver() : base()
        {
            Problem.Id = 10;
            Problem.Title = "Summation of primes";
            Problem.UpperBound = 2000000;
            Problem.IsClosedOnRight = true;
            Problem.Description =
                "The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.\n"
                    + "\n"
                    + "Find the sum of all the primes below two million.\n";


            Problem.Solutions.Add(new Solution
            {
                ProblemId = 10,
                Description = "SeiveOfEratosthenes",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
        }

        public override string solution1()
        {
            long sum = 0;
            foreach (long n in SeiveOfEratosthenes(Problem.CalculatedIncludedUpperBound))
                sum += n;

            return sum.ToString();
        }

        public override string solution2()
        {
            return "";
        }

        public long[] SeiveOfEratosthenes(long upperBound)
        {
            long [] primes = new ProjectEulerLib.MoreMath.PrimeCalculator().SeiveOfEratosthenes(upperBound);
            return primes;
            // long sqrtOfN = (long)(Math.Sqrt(upperBound));
            // bool[] bArray = new bool[upperBound + 1];
            // for (long i = 0; i <= upperBound; i++) bArray[i] = true;
            // bArray[0] = false;
            // bArray[1] = false;

            // for (long i = 2; i <= sqrtOfN; i++)
            // {
            //     for (long m = i * 2; m <= upperBound; m += i)
            //     {
            //         bArray[m] = false;
            //     }
            // }

            // List<long> list = new List<long>();
            // long index = 0;
            // while (index <= upperBound)
            // {
            //     if (bArray[index]) list.Add(index);
            //     index++;
            // }

            // return list.ToArray();
        }
    }
}