using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;
using ProjectEulerLib.MoreMath;

namespace ProjectEulerLib
{
    public class Problem57Solver : ProblemSolver
    {
        public Problem57Solver() : base()
        {
            Problem.Id = 57;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Square root convergents";
            Problem.Description =
@"It is possible to show that the square root of two can be expressed as an infinite continued fraction.

sqrt(2) = 1 + 1 / (2 + 1 / (2 + 1 / (2 + ...))))

By expanding this for the first four iterations, we get:
1 + 1/2 = 3/2
1 + 1/(2 + 1/2) = 7/5
1 + 1/(2 + 1/(2 + 1/2)) = 17/12
1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29

The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/984, is the first example where the number of digits in the numerator exceeds the number of digits in the denominator.

In the first one-thousand expansions, how many fractions contain a numerator with more digits than the denominator?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 57,
                Description = "",
                Version = 1,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 0,
                Description = "MoreMath.BigInteger. Add a public property - long DigitCount",
                Version = 2,
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "",
            //     Version = 3,
            // });
        }

        public override string solution2()
        {
            BigInteger[] nominator = new BigInteger[1000];
            BigInteger[] denominator = new BigInteger[1000];
            nominator[0] = new BigInteger(3);
            denominator[0] = new BigInteger(2);

            int count = 0;
            for (int i = 1; i < 1000; i++)
            {
                denominator[i] = nominator[i - 1] + denominator[i - 1];
                nominator[i] = denominator[i] + denominator[i - 1];
                string s = nominator[i].ToString() + "/" + denominator[i];
                
                
                if (nominator[i].DigitCount > denominator[i].DigitCount) count++;
            }


            return count.ToString();
        }

        public override string solution1()
        {
            return "";
        }

        public override string solution3()
        {
            return "";
        }
    }
}
