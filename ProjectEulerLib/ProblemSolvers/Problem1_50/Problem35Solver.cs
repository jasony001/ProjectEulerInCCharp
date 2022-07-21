using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem35Solver : ProblemSolver
    {
        public Problem35Solver() : base()
        {
            Problem.Id = 35;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 35,
                Description = "Note it's 'all rotations', not 'all permutations'. Get prime list, remove the ones containing 0, 2, 4, 5, 6, 8. Check each of them, remove checked number and all of its 'rotations'.",
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
            MoreMath.PrimeCalculator primeCalculator = new MoreMath.PrimeCalculator();
            long[] primes = primeCalculator.GetPrimesUnderN(1000000);
            List<long> candidates = primes.Where(p => p > 10 && IsCandidate(p)).ToList();
            List<long> answers = new List<long>();

            while (candidates.Count > 0)
            {
                long n = candidates[0];
                List<long> temp = new List<long>();
                bool IsQualify = true;
                long[] rotatedNumberList = GetRotatedNumberList(n);

                foreach (long l in GetRotatedNumberList(n))
                {
                    if (!primes.Contains(l)) { IsQualify = false; break; }
                    if (!temp.Contains(l)) temp.Add(l);
                }

                foreach (long l in temp)
                {
                    if (IsQualify)
                        answers.Add(l);

                    candidates.Remove(l);
                }
            }

            answers.InsertRange(0, new List<long> { 2, 3, 5, 7 });
            return answers.Count().ToString();
        }

        public bool IsCandidate(long n)
        {
            string s = n.ToString();
            foreach (char c in new char[] { '0', '2', '4', '5', '6', '8' })
                if (s.IndexOf(c) >= 0) return false;

            return true;
        }

        long[] GetRotatedNumberList(long n)
        {
            List<long> resultList = new List<long> { n };
            long x = n;
            while (true)
            {
                string s = x.ToString();
                s = s.Substring(1) + s[0];
                long n1 = Convert.ToInt64(s);
                if (n1 == n) break;
                resultList.Add(n1);
                x = n1;
            }

            return resultList.ToArray();
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
