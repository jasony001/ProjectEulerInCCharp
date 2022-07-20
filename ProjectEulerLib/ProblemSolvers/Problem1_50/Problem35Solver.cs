using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem35Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {

            },
            new List<string>{

            },
            new List<string>{

            }
        };

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
                Description = "",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "",
            //     Version = 2,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            // });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "",
            //     Version = 3,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[2])
            // });
        }
        public bool IsCandidate(long n)
        {
            string s = n.ToString();
            foreach(char c in new char[]{'0', '2', '4', '5', '6', '8'})
                if (s.IndexOf(c) >= 0) return false;
            
            return true;
        }


        long[] GetShuffledNumberList(long n)
        {
            MoreMath.CombinationCalculator combinationCalculator = new MoreMath.CombinationCalculator();
            List<List<char>> listOfCharList = combinationCalculator.ListPermutations<char>(n.ToString().ToArray().ToList());
            List<long> numberList = new List<long>();
            foreach(List<char> charList in listOfCharList)
            {
                string s = "";
                foreach(char c in charList) s = s + c;
                numberList.Add(Convert.ToInt64(s));
            }

            return numberList.ToArray();
        }

        public override string solution1()
        {
            MoreMath.PrimeCalculator primeCalculator = new MoreMath.PrimeCalculator();
            long[] primes = primeCalculator.SeiveOfEratosthenes(1000000);
            List<long> candidates = primes.Where(p => p > 10 && IsCandidate(p)).ToList();
            List<long> answers = new List<long>();

            while (candidates.Count > 0)
            {
                long n = candidates[0];
                List<long> temp = new List<long>();
                bool IsQualify = true;

                foreach(long l in GetShuffledNumberList(n))
                {
                    if (!primes.Contains(l)) {IsQualify = false;  break;}
                    if (!temp.Contains(l))
                        temp.Add(l);
                }

                foreach(long l in temp)
                {
                    if (IsQualify) 
                    {
                        answers.Add(l);
                        Console.WriteLine(l);
                    }
                    candidates.Remove(l);
                }
                
                
            }

            return answers.Count().ToString();
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
