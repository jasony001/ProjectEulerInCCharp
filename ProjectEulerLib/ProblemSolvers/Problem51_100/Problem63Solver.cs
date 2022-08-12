using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem63Solver : ProblemSolver
    {
        public Problem63Solver() : base()
        {
            Problem.Id = 63;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Powerful digit counts";
            Problem.Description = 
@"
The 5-digit number, 16807=7^5, is also a fifth power. Similarly, the 9-digit number, 134217728=8^9, is a ninth power.

How many n-digit positive integers exist which are also an nth power?
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 63,
                Description = 
@"10^n is an n+ 1 digit number
for any x^n to be an n digit number, x must be 0 - 9
0^1 is a 1 digit number, but the question requires 'positive number', so 0 doesn't count
log10(x^n) = n log10(x), must be >=n and < n + 1",
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
            double [] log10Array = new double [10];
            log10Array[0] = 0;
            for(int i = 1; i < 10; i ++)
                log10Array[i] = Math.Log(i, 10);

            int count = 0;
            for(int i = 2; i < 10; i ++)
            {
                int n = 1;
                while(n * log10Array[i] > n - 1)
                {
                    if (n * log10Array[i] < n)
                        count ++;
                    else 
                        break;
                    n ++;
                }
            }
            
            return (count + 1).ToString();
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
