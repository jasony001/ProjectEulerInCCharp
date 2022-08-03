using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public abstract class ProblemSolver
    {
        public ProblemSolver()
        {
            Problem = new Problem();
        }

        public Problem Problem { get; set; }
        public virtual string solution1() { throw new NotImplementedException("solution1 is not implemented"); }
        public virtual string solution2() { throw new NotImplementedException("solution2 is not implemented"); }
        public virtual string solution3() { throw new NotImplementedException("solution3 is not implemented"); }

        public void SaveProblem()
        {

        }

        public string CalculateSolutionAnswer(int version)
        {
            string answer = null;
            switch (version)
            {
                case 1:
                    answer = solution1();
                    break;
                case 2:
                    answer = solution2();
                    break;
                case 3:
                    answer = solution3();
                    break;
                default:
                    break;
            }

            return answer;
        }

        public void SolveProblem()
        {
            for (int i = 1; i <= 3; i++)
            {
                try
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();

                    string answer = CalculateSolutionAnswer(i);

                    stopWatch.Stop();
                    if (answer != null)
                    {
                        Problem.Solutions[i - 1].Answer = answer.ToString();
                        Problem.Solutions[i - 1].TestRunElapsedTime = (int)(stopWatch.ElapsedMilliseconds);
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"Solution {i} not implemented: " + ex.Message);
                }
            }
        }
    }
}
