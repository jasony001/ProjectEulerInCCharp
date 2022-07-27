using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem53Solver : ProblemSolver
    {
        public Problem53Solver() : base()
        {
            Problem.Id = 53;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Combinatoric selections";
            Problem.Description = 
@"How many, not necessarily distinct, values of C(n, r) for 1 <= n <= 100, are greater than one-million?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 53,
                Description = 
@"log(n!) - log(r!) - log ((n - r)!) > 6. Build an array of 101 to save all log(n, 10). Do not calculate n! or r!, access log(n!) or log(r!) from the array.",
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
            double [] log1to100 = new double [101];
            double sum = 0;
            for(int i = 1; i <= 100; i ++)
            {
                double d = Math.Log(i, 10);
                sum += d;
                log1to100[i] = sum;
            }

            int count = 0;
            for(int n = 2; n <= 100; n ++)
            {
                for(int r = 1; r <= n; r ++)
                {
                    // log(n!) - log(r!) - log ((n - r)!) > 6
                    if (log1to100[n] - log1to100[r] - log1to100[n - r] > 6)
                        count ++;
                }
            }

            return count.ToString();
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
