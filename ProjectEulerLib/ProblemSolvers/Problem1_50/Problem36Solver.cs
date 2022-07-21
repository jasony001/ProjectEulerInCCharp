using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem36Solver : ProblemSolver
    {
        public Problem36Solver() : base()
        {
            Problem.Id = 36;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Double-base palindromes";
            Problem.Description = 
@"The decimal number, 585 = 1001001001 (binary), is palindromic in both bases.

Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

(Please note that the palindromic number, in either base, may not include leading zeros.)";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 36,
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
            long sum = 0;
            for(long n = 1; n <= 1000000; n ++)
            {
                if (n % 10 == 0) continue;
                if (!IsPalindrome(n, 10)) continue;
                if (!IsPalindrome(n, 2)) continue;
                sum += n;
            }

            return sum.ToString();
        }

        bool IsPalindrome(long n, int baseNumber)
        {
            if (n <= 0 || (baseNumber != 2 && baseNumber != 10)) return false;

            long x = n;
            List<int> digits = new List<int>();
            while (x > 0)
            {
                digits.Insert(0, (int)(x % baseNumber));
                x /= baseNumber;
            }

            for(int i = 0; i < digits.Count / 2; i ++)
            {
                if (digits[i] != digits[digits.Count - 1 - i]) return false;
            }

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
