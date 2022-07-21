using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem38Solver : ProblemSolver
    {
        public Problem38Solver() : base()
        {
            Problem.Id = 38;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Pandigital multiples";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 38,
                Description = "UpperBound is a 4 digit number. concatenate two unmber: 4 + 5 = 9. Loop through 1 to 100000. ",
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
            long maxP = 0;
            for(int n = 1; n <10000; n ++)
            {
                string s = "";
                int i = 1;
                do
                {
                    s = s + (n * i).ToString();
                    i ++;
                } while(s.Length < 9);
                if (Is1to9PandigitalNumber(s))
                {
                    if(maxP < Convert.ToInt64(s))
                    {
                        maxP = Convert.ToInt64(s);
                        Console.WriteLine(s);
                    }
                }
            }

            
            return maxP.ToString();
        }

        private bool Is1to9PandigitalNumber(string s)
        {
            if (s.IndexOf('0')>= 0) return false;
            if (s.Length != 9) return false;
            if(s.ToArray().Distinct().Count() != 9) return false;

            return true;
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
