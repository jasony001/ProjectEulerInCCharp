using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem58Solver : ProblemSolver
    {
        public Problem58Solver() : base()
        {
            Problem.Id = 58;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Spiral primes";
            Problem.Description = 
@"

Starting with 1 and spiralling anticlockwise in the following way, a square spiral with side length 7 is formed.

37 36 35 34 33 32 31
38 17 16 15 14 13 30
39 18  5  4  3 12 29
40 19  6  1  2 11 28
41 20  7  8  9 10 27
42 21 22 23 24 25 26
43 44 45 46 47 48 49

It is interesting to note that the odd squares lie along the bottom right diagonal, but what is more interesting is that 8 out of the 13 numbers lying along both diagonals are prime; that is, a ratio of 8/13 ≈ 62%.

If one complete new layer is wrapped around the spiral above, a square spiral with side length 9 will be formed. If this process is continued, what is the side length of the square spiral for which the ratio of primes along both diagonals first falls below 10%?
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 58,
                Description = "",
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

        public override string solution1()
        {
            // 3: 3/5
            // 5: 5/9
            // 7: 8/13

            // 3: 3, 5, 7, 9
            // 5: 13, 17, 21, 25
            // 7: 31, 31, 37, 43
            // 9: 51, 59, 67, 75
            MoreMath.PrimeCalculator primeCalculator = new MoreMath.PrimeCalculator();

            int length = 3;
            long [] cornerNumbers = new long[]{3, 5, 7, 9};
            int primeCount = 3;
            int totalNumber = 7;
            while (primeCount * 10 > totalNumber)
            {
                try
                {
                    length += 2;
                    totalNumber = 2 * length - 1;

                    cornerNumbers[0] = cornerNumbers[3] + length - 1;
                    for(int i = 1; i <4; i ++)
                        cornerNumbers[i] = cornerNumbers[i - 1] + length - 1;

                    for(int i = 0; i <4; i ++)
                        if (primeCalculator.IsPrime(cornerNumbers[i])) primeCount ++;
                }
                catch (System.Exception ex)
                {
                    
                    Console.WriteLine(length.ToString() + ": " + ex.Message);
                    Console.WriteLine(cornerNumbers[3]);
                    throw ex;
                }
            }

Console.WriteLine(length.ToString());

Console.WriteLine(cornerNumbers[3]);
            return length.ToString();
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
