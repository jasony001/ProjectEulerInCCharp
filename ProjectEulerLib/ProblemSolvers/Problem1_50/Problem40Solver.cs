using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem40Solver : ProblemSolver
    {
        public Problem40Solver() : base()
        {
            Problem.Id = 40;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Champernowne's constant";
            Problem.Description = 
@"An irrational decimal fraction is created by concatenating the positive integers:

0.123456789101112131415161718192021...

It can be seen that the 12th digit of the fractional part is 1.

If dn represents the nth digit of the fractional part, find the value of the following expression.

d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 40,
                Description = "It's easier (not easy either) to solve this by paper. ",
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
            long product = 1;
            // d1 and d10 are 1, ignore
            for(int digit = 3; digit <= 7; digit ++)
            {
                int nthDigit  = GetNthNumber(digit);
                product *= nthDigit;
            }

            return product.ToString();
        }

        int GetNthNumber(int digit)
        {
            long [] firstXDigitsNumber = new long [] {0, 1, 10, 100, 1000, 10000, 100000, 1000000};
            long [] xDigitsNumberCount = new long [] {0, 9, 180, 2700, 36000, 450000, 5400000};
            long [] countOfNumbersNoGreaterThanXDigits = new long [] {0, 9, 189, 2889, 38889, 488889, 5888889};

            long countedNumbers = countOfNumbersNoGreaterThanXDigits[digit - 2];
            long position = (long)Math.Pow(10, digit - 1);
            long leftToCount = position - countedNumbers;
            long wholeNumber = firstXDigitsNumber[digit - 1] + leftToCount / (digit - 1) - 1;
            int remainder = (int)(leftToCount % (digit - 1));

            if (remainder == 0)
            {
                return (int)(wholeNumber.ToString()[digit - 2] - '0');
            }
            else
            {
                return (int)((wholeNumber + 1).ToString()[remainder - 1] - '0');
            }
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
