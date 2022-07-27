using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem55Solver : ProblemSolver
    {
        public Problem55Solver() : base()
        {
            Problem.Id = 55;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Lychrel numbers";
            Problem.Description = 
@"If we take 47, reverse and add, 47 + 74 = 121, which is palindromic.

Not all numbers produce palindromes so quickly. For example,

349 + 943 = 1292,
1292 + 2921 = 4213
4213 + 3124 = 7337

That is, 349 took three iterations to arrive at a palindrome.

Although no one has proved it yet, it is thought that some numbers, like 196, never produce a palindrome. A number that never forms a palindrome through the reverse and add process is called a Lychrel number. Due to the theoretical nature of these numbers, and for the purpose of this problem, we shall assume that a number is Lychrel until proven otherwise. In addition you are given that for every number below ten-thousand, it will either (i) become a palindrome in less than fifty iterations, or, (ii) no one, with all the computing power that exists, has managed so far to map it to a palindrome. In fact, 10677 is the first number to be shown to require over fifty iterations before producing a palindrome: 4668731596684224866951378664 (53 iterations, 28-digits).

Surprisingly, there are palindromic numbers that are themselves Lychrel numbers; the first example is 4994.

How many Lychrel numbers are there below ten-thousand?

NOTE: Wording was modified slightly on 24 April 2007 to emphasise the theoretical nature of Lychrel numbers.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 55,
                Description = 
@"use a List<int> to represent each integer, from 1 to 9999
for each number, reverse and add, count steps, increase Lychrel number count when steps are over 50
",
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
            int countOfLychrelNumbers = 0;

            for(int i = 1; i < 10000; i ++)
            {
                List<int> digits = ConvertNumberToDigitList(i);
                int steps = 0;
                bool reachedPalindrome = false;
                while(steps < 50 && !reachedPalindrome)
                {
                    digits = ReverseAndAdd(digits);
                    reachedPalindrome = IsPalindrome(digits);
                    steps ++;
                }
                if (!reachedPalindrome) countOfLychrelNumbers ++;
            }

            return countOfLychrelNumbers.ToString();
        }

        List<int> ConvertNumberToDigitList(int number)
        {
            List<int> digits = new List<int>();
            while(number > 0)
            {
                digits.Insert(0, number % 10);
                number /= 10;
            }

            return digits;
        }

        List<int> ReverseAndAdd(List<int> number)
        {
            List<int> reverseNumber = new List<int>();
            for(int i = 0; i < number.Count; i ++) 
                reverseNumber.Insert(0, number[i]);

            List<int> sum = new List<int>();
            for(int i = 0; i < number.Count; i ++) sum.Add(reverseNumber[i] + number[i]);

            int c = 0;
            for(int i = sum.Count - 1; i >= 0; i --)
            {
                int value = sum[i] + c;
                sum[i] = value % 10;
                c = value / 10;
            }

            while(c > 0)
            {
                sum.Insert(0, c % 10);
                c /= 10;
            }

            return sum;
        }

        bool IsPalindrome(List<int> number)
        {
            for(int i = 0; i < number.Count / 2; i ++)
            {
                if (number[i] != number[number.Count - 1 - i]) return false;
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
