using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem56Solver : ProblemSolver
    {
        public Problem56Solver() : base()
        {
            Problem.Id = 56;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Powerful digit sum";
            Problem.Description = 
@"A googol (10^100) is a massive number: one followed by one-hundred zeros; 100^100 is almost unimaginably large: one followed by two-hundred zeros. Despite their size, the sum of the digits in each number is only 1.

Considering natural numbers of the form, ab, where a, b < 100, what is the maximum digital sum?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 56,
                Description = 
@"
use a List<int> to represent each a (1 - 100), repeat multiply this by a 100 times, carry digits in the product, sum the digits in the list of the product
didn't understand how to work out the constraints
but using List<int> to represent the number makes it very fast - 22 ms
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
            long maxDigitSum = 0;
            for(int a = 1; a <= 100; a ++)
            {
                List<int> product = ConvertNumberToDigitList(a);
                for(int b = 2; b <= 100; b ++)
                {
                    product = MultiplyNumberDigits(product, a);
                    maxDigitSum = Math.Max(maxDigitSum, product.Sum(d => d));
                }
            }

            return maxDigitSum.ToString();
        }

        List<int> MultiplyNumberDigits(List<int> numberDigitList, int a)
        {
            for(int i = 0; i < numberDigitList.Count; i ++) numberDigitList[i] = numberDigitList[i] * a;
            int c = 0;
            for(int i = numberDigitList.Count - 1; i >= 0; i --)
            {
                int v = c + numberDigitList[i];
                numberDigitList[i] = v % 10;
                c = v / 10;
            }
            
            while (c > 0)
            {
                numberDigitList.Insert(0, c % 10);
                c /= 10;
            }

            return numberDigitList;
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
