using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem42Solver : ProblemSolver
    {
        public Problem42Solver() : base()
        {
            Problem.Id = 42;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 42,
                Description = "https://www.symbolab.com/solver/function-inverse-calculator/inverse; n = (Math.Sqrt(1 + 8 * x)  -1) / 2",
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
            System.IO.StreamReader sr = new System.IO.StreamReader("p042_words.txt");
            string allWords = sr.ReadToEnd();
            sr.Close();
            int count = 0;
            foreach(string word in allWords.Split(new char []{','}, StringSplitOptions.RemoveEmptyEntries))
            {
                string s = word.Replace("\"", "").ToUpper();
                long wordValue = GetWordValue(s);
                bool isTraiangleNumber = IsTraiangleNumber(wordValue);
                count += isTraiangleNumber ? 1 : 0;
            }

            return count.ToString();
        }

        bool IsTraiangleNumber(long x)
        {
            double positiveSolution = (Math.Sqrt(1 + 8 * x)  -1) / 2;
            
            return (Math.Abs((int)positiveSolution - positiveSolution) < Math.Pow(0.1, 6));
        }

        long GetWordValue(string word)
        {
            long wordValue = 0;
            foreach(char c in word)
            {
                wordValue += (c - 'A' + 1);
            }

            return wordValue;
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
