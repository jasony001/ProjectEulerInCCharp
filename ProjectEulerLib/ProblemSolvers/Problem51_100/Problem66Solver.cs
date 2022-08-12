using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem66Solver : ProblemSolver
    {
        public Problem66Solver() : base()
        {
            Problem.Id = 66;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 66,
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

List<PossibleModSet> possibleModSets = new List<PossibleModSet>();
for(long d = 0; d < 10; d++)
{
    for(long x = 0; x < 10; x ++)
    {
        for(long y = 0; y < 10; y ++)
        {
            long diff = x * x - d * y * y % 10;
            if (diff > 0 && diff % 10 == 1 || diff < 0 && ((-1 * diff) % 10 == 9))
            possibleModSets.Add(new PossibleModSet{
                dm = d,
                xm = x,
                ym = y
            });
        }
    }
}

/*
d       x       y
0       1       any
0       9       any
1       0       3
1       0       7
1       1       0
1       4       5
1       5       2
1       5       8
1       6       5
1       9       0
2       1       0
2       1       5
2       3       2
2       3       8
2       7       2
2       7       9
3       
*/


            long[] squares = new long[32];
            for(long i = 0; i <= 31; i ++) squares[i] = i * i;
            long maxX = 0;

            for(long d = 2; d <= 10; d ++)
            {
                if (squares.Any(s => s == d)) continue;
                long dm = d % 10;
                List<long> possibleXList = possibleModSets.Where(s => s.dm == d % 10).Select(s => s.xm).Distinct().ToList();

                double sqrtD = Math.Sqrt(d);
                if (Math.Abs(sqrtD - (long)sqrtD) < 0.01 ) continue;
                long x = 2;
                long sd = -1;
                while (sd < 0)
                {
                    long xm = x % 10;
                    if (!possibleXList.Contains(xm)) { x++; continue; }

                    List<long> possibleYList = 
                        possibleModSets.Where(s => s.dm == dm && s.xm == xm).Select(s => s.ym).Distinct().ToList();

                    for(long y = 1; y < x; y ++)
                    {

                        if (!possibleYList.Contains(y % 10)) continue;

                        if (x * x - d * y * y == 1)
                        {
                            Console.WriteLine($"{d}: {x}^2 - {d} * {y}^2 = 1; {Math.Sqrt(d)}");
                            sd =x;
                            break;
                        }
                    }
                    x ++;
                    
                }

                maxX = Math.Max(maxX, sd);
            }

            // return maxX.ToString();
            return "working on it";
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

    public class PossibleModSet
    {
        public long dm {get;set;}

        public long xm {get;set;}

        public long ym {get;set;}
    }
}
