using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem100Solver : ProblemSolver
    {
        public Problem100Solver() : base()
        {
            Problem.Id = 100;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Arranged probability";
            Problem.Description = 
@"
If a box contains twenty-one coloured discs, composed of fifteen blue discs and six red discs, and two discs were taken at random, it can be seen that the probability of taking two blue discs, P(BB) = (15/21)×(14/20) = 1/2.

The next such arrangement, for which there is exactly 50% chance of taking two blue discs at random, is a box containing eighty-five blue discs and thirty-five red discs.

By finding the first arrangement to contain over 10^12 = 1,000,000,000,000 discs in total, determine the number of blue discs that the box would contain.
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 100,
                Description = 
@"Generic two integer variable equation solver
https://www.alpertron.com.ar/QUAD.HTM
b1 = 15
n1 = 21

b_{k 1} = 3b_k + 2n_k - 2
n_{k 1} = 4b_k + 3n_k - 3

loop until n > 10^12, increase n by 1 in each loop
",
                Version = 1,
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "",
            //     Version = 2,
            // });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "",
            //     Version = 3,
            // });
        }

        public override string solution2()
        {
            // MoreMath.PrimeCalculator primeCalculator = new MoreMath.PrimeCalculator();
            // long[] primes = primeCalculator.GetPrimesUnderN(1000000);

            // bool found = false;
            // long t = (long)(Math.Pow(10, 12));
            // long checking = t;
            // while (!found)
            // {
            //     checking = t;
            //     Console.WriteLine(checking);

            //     long lb = (long)Math.Floor(t / Math.Sqrt(2)) - 1;
            //     long ub = (long)Math.Ceiling(t / Math.Sqrt(2)) + 1;

            //     for (long b0 = lb; b0 <= ub; b0++)
            //     {
            //         t = checking;
            //         long b = b0;
            //         long b1 = b + 1;
            //         long t1 = t + 1;
            //         foreach (long p in primes)
            //         {
            //             while ((b % p == 0 || b1 % p == 0) && (t % p == 0 || t1 % p == 0))
            //             {
            //                 if (b % p == 0)
            //                     b /= p;
            //                 else
            //                     b1 /= p;

            //                 if (t % p == 0)
            //                     t /= p;
            //                 else
            //                     t1 /= p;
            //             }
            //         }

            //         if (t%b==0)
            //         {
            //             b=1;
            //             t/=b;
            //         }

            //         if (t%b1==0)
            //         {
            //             b1=1;
            //             t/=b1;
            //         }                

            //         if (t1%b==0)
            //         {
            //             b=1;
            //             t1/=b;
            //         }

            //         if (t1%b1==0)
            //         {
            //             b1=1;
            //             t1/=b1;
            //         }      

            //         if (b == 1 && b1 == 1 && (t == 1 && t1 == 2 || t == 2 && t1 == 1))          
            //         {
            //             found = true;
            //         }

            //     }

            //     t = checking;
            //     t ++;

            // }
            // return checking.ToString();
            return "";
        }

        public override string solution1()
        {
            long b = 15;
            long n = 21;
            long target = (long)Math.Pow(10, 12);
            while(n <= target)
            {
                long bTemp = 3 * b + 2 * n - 2;
                long nTemp = 4 * b + 3 * n - 3;

                b = bTemp;
                n = nTemp;
            }

            return $"{b}/{n} * {b+1}/{n+1} = 1/2";
        }

        public override string solution3()
        {
            return "";
        }
    }
}
