using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem25Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {
"double Phi = (1 + Math.Sqrt(5)) / 2;",
"            double phi = (1 - Math.Sqrt(5)) / 2;",
"",
"            long n = 4780;",
"            double logF = 0;",
"            while(logF < 999)",
"            {",
"                double pdP = (1 - Math.Sqrt(5)) / (1 + Math.Sqrt(5));//(3 - Math.Sqrt(5)) / (-2);",
"                logF = n * Math.Log(Phi, 10) + Math.Log(1 - Math.Pow(pdP, n), 10)",
"                 - Math.Log(Math.Sqrt(5), 10);",
"",
"                n ++;",
"            }",
"            return (n - 1).ToString();",
            },
            new List<string>{
"            double Phi = (1 + MathF.Sqrt(5)) / 2;",
"            double n = (999 + Math.Log(Math.Sqrt(5), 10)) / Math.Log(Phi, 10);",
"            ",
"            return ((int)(Math.Ceiling(n))).ToString();",
            },
            new List<string>{
"            List<List<int>> fList = new List<List<int>>",
"                {new List<int>{0}, new List<int>{1}};",
"            ",
"            int n = 2;",
"            do {",
"                fList.Add(AddTwoPreviousF(fList[n -1], fList[n -2]));",
"                if (n == 4780)",
"                {",
"                    int size = fList[n].Count;",
"                }",
"                n ++;",
"            } while (fList[n - 1].Count < 1000);",
"",
"            return (n-1).ToString();",
            }
        };

        public Problem25Solver() : base()
        {
            Problem.Id = 25;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "1000-digit Fibonacci number";
            Problem.Description = 
@"The Fibonacci sequence is defined by the recurrence relation:

    Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.

Hence the first 12 terms will be:

    F1 = 1
    F2 = 1
    F3 = 2
    F4 = 3
    F5 = 5
    F6 = 8
    F7 = 13
    F8 = 21
    F9 = 34
    F10 = 55
    F11 = 89
    F12 = 144

The 12th term, F12, is the first term to contain three digits.

What is the index of the first term in the Fibonacci sequence to contain 1000 digits?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 25,
                Description = "This is a mah problem. Cannor brutal force using the Phi formula f(n) = (Phi^n - phi^n) / sqrt(5) , even with the phi formula. blows at 1476. Use log10 on both side.",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 0,
                Description = "phi**n/sqrt(5) > 10**999",
                Version = 2,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 0,
                Description = "Brutal force, adding two previous numbers.",
                Version = 3,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[2])
            });
        }

        public override string solution1()
        {
            // f(n) = (Phi^n - phi^n) / sqrt(5) 
            // f(0) = 0
            // f(1) = 1
            // f(2) = 1
            // f(3) = 2
            // f(4) = 3
            // f(7) = 13 - 2 digits, >10^(2 - 1)
            // f(n) >= 10^999
            // log(Ph^n - phi^n)/sqrt(5)) >= 999
            // Log(P^n ( 1- (p/P)^n)) - Log(sqrt(5)) >= 999
            // Log(P^n) + Log(1 - (p/P)^n) >= 999 + 1/2Log(5)
            // nlog(Phi) + log(1 - (phi/Phi)^n) > 999 + log(sqrt(5))
            double Phi = (1 + Math.Sqrt(5)) / 2;
            double phi = (1 - Math.Sqrt(5)) / 2;

            long n = 4780;
            double logF = 0;
            while(logF < 999)
            {
                double pdP = (1 - Math.Sqrt(5)) / (1 + Math.Sqrt(5));//(3 - Math.Sqrt(5)) / (-2);
                logF = n * Math.Log(Phi, 10) + Math.Log(1 - Math.Pow(pdP, n), 10)
                 - Math.Log(Math.Sqrt(5), 10);

                n ++;
            }
            return (n - 1).ToString();
        }

        public override string solution2()
        {
            // phi**n/sqrt(5) > 10**999
            double Phi = (1 + MathF.Sqrt(5)) / 2;
            double n = (999 + Math.Log(Math.Sqrt(5), 10)) / Math.Log(Phi, 10);
            
            return ((int)(Math.Ceiling(n))).ToString();
        }
    
        public override string solution3()
        {
            List<List<int>> fList = new List<List<int>>
                {new List<int>{0}, new List<int>{1}};
            
            int n = 2;
            do {
                fList.Add(AddTwoPreviousF(fList[n -1], fList[n -2]));
                if (n == 4780)
                {
                    int size = fList[n].Count;
                }
                n ++;
            } while (fList[n - 1].Count < 1000);

            return (n-1).ToString();
        }

        List<int> AddTwoPreviousF(List<int> f1, List<int> f2)
        {
            List<int> sl = (f1.Count > f2.Count) ? f2 : f1;
            List<int> ll = (f1.Count > f2.Count) ? f1 : f2;
            int diff = ll.Count - sl.Count;

            for(int i = 0; i < diff; i ++)
            {
                sl.Insert(0, 0);
            }

            List<int> sum = new List<int>();
            for(int i = 0; i < ll.Count; i ++)
            {
                sum.Add(sl[i] + ll[i]);
            }



            int c = 0;
            for(int index = sum.Count - 1; index >= 0; index --)
            {
                int r = (sum[index] + c) % 10;
                c = (sum[index] + c) / 10;
                sum[index] = r;
            }

            while (c > 0)
            {
                sum.Insert(0, c % 10);
                c /= 10;
            }

            return sum;
        }
    }
}
