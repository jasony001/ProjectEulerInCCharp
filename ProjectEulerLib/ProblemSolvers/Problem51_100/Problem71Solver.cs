using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem71Solver : ProblemSolver
    {
        public Problem71Solver() : base()
        {
            Problem.Id = 71;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 71,
                Description = "Build prime factor list for 2 to 1000000, find max numeratror less than 3/7 where numerator and denumerator does not have common prime factor",
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
int upperBound = 1000000;
            List<int>[] primeFactorListArray = new List<int>[upperBound + 1];
            for(int i = 0; i <= upperBound; i ++) primeFactorListArray[i] = new List<int>();

            for(int i = 2; i <= Math.Sqrt(upperBound); i ++)
            {
                if (primeFactorListArray[i].Count > 0) continue;
                for(int j = i * 2; j <= upperBound; j +=i)
                {
                    primeFactorListArray[j].Add(i);
                }
            }

            for(int i = 2; i <= upperBound; i ++)
            {
                int a = i;
                foreach (var p in primeFactorListArray[i])
                {
                    while(a % p == 0) a /= p;
                }
                if (a > 1) primeFactorListArray[i].Add(a);
            }

double maxFraction = 0;
int maxN = 0;
int maxD = 0;
            for(int denumerator = upperBound; denumerator >=2; denumerator --)
            {
                int numerator = (int)(Math.Floor((double)denumerator * 3 / 7));
                if (numerator == (double)denumerator * 3 / 7) continue;  
                while(primeFactorListArray[denumerator].Intersect<int>(primeFactorListArray[numerator]).Count() > 0 && numerator > 0)
                {
                    numerator --;
                }
                if (numerator > 0) 
                {
                    if ((double)numerator/denumerator > maxFraction)
                    {
                        maxFraction = (double)numerator/denumerator;
                        maxN = numerator;
                        maxD = denumerator;
                    }
                    // Console.WriteLine($"{numerator} / {denumerator}");
                }
            }



            return $"{maxN} / {maxD}";
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
