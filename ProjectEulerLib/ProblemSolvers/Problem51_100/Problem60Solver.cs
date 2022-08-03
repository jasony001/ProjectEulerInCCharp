using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem60Solver : ProblemSolver
    {
        public Problem60Solver() : base()
        {
            Problem.Id = 60;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Prime pair sets";
            Problem.Description = 
@"The primes 3, 7, 109, and 673, are quite remarkable. By taking any two primes and concatenating them in any order the result will always be prime. For example, taking 7 and 109, both 7109 and 1097 are prime. The sum of these four primes, 792, represents the lowest sum for a set of four primes with this property.

Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 60,
                Description = 
@"Build Dictionary<long, list<long>> for each prime under 10000 (cheating), build a list of prime that's greater than the current prime and satisfies ab & ba are also prime.  
code 5 level loop through intersection of 1, 2, 3, 4, 5 list. The first one reaches level 5 is the answer. ",
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
            List<long> primesUnder10000 = primeCalculator.GetPrimesUnderN(10000).ToList();
            bool[] primeFlags = primeCalculator.GetPrimeFlagArray(100000000);
            primesUnder10000.Remove(2);
            primesUnder10000.Remove(5);

            
            Dictionary<long, List<long>> pairsList = new Dictionary<long, List<long>>();
            foreach(long p1 in primesUnder10000)
            {
                if (!pairsList.ContainsKey(p1)) pairsList.Add(p1, new List<long>());
                foreach(long p2 in primesUnder10000.Where(p => p > p1))
                {
                    long n1 = Convert.ToInt64(p1.ToString() + p2.ToString());
                    if (!primeFlags[n1]) continue;
                    long n2 = Convert.ToInt64(p2.ToString() + p1.ToString());
                    if (!primeFlags[n2]) continue;
                    pairsList[p1].Add(p2);
                }
            }

            foreach(long p1 in pairsList.Keys)
                foreach (long p2 in pairsList[p1])
                    foreach (long p3 in pairsList[p1].Intersect(pairsList[p2]))
                        foreach (long p4 in pairsList[p1].Intersect(pairsList[p2].Intersect(pairsList[p3])))
                            foreach (long p5 in pairsList[p1].Intersect(pairsList[p2].Intersect(pairsList[p3].Intersect(pairsList[p4]))))
                                return (p1 + p2 + p3 + p4 + p5).ToString();

            return "no solution found checing primes under 10000";
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
