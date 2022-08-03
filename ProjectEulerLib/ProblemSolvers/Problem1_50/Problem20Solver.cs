using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;
using ProjectEulerLib.MoreMath;

namespace ProjectEulerLib
{
    public class Problem20Solver : ProblemSolver
    {

        public Problem20Solver() : base()
        {
            Problem.Id = 20;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Factorial digit sum";
            Problem.Description = 
@"n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 20,
                Description = "Use List<long> to store bigNumber, carryDigits when an item is bigger than long.MaxValue / 100",
                Version = 1,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 0,
                Description = "BigInteger custom class",
                Version = 2,
            });
        }

        long MaxLongOne100th = long.MaxValue / 100;

        public List<long> CarryDigits(List<long> bigNumber)
        {
            long c = 0;
            for(int i = bigNumber.Count - 1; i >= 0; i --)
            {
                long r = (bigNumber[i] + c) % 10;
                c = (bigNumber[i] + c) / 10;
                bigNumber[i] = r;
            }

            while(c > 0)
            {
                bigNumber.Insert(0, c % 10);
                c /= 10;
            }

            return bigNumber;
        }

        public List<long> MultiplyBigNumber(List<long> bigNumber, long n)
        {
            bool needsToCarryDigits = false;
            for(int i = 0; i < bigNumber.Count; i ++)
            {
                bigNumber[i] *= n;
                if (bigNumber[i] >= MaxLongOne100th) needsToCarryDigits = true;
            }
            if (needsToCarryDigits) bigNumber = CarryDigits(bigNumber);

            return bigNumber;
        }

        public override string solution1()
        {
            List<long> bigNumber = new List<long>{1};
            for(long n = 2; n <= 100; n ++)
            {
                bigNumber = MultiplyBigNumber(bigNumber, n);
            }

            bigNumber = CarryDigits(bigNumber);

            long sum = 0;
            foreach(long n in bigNumber) sum+= n;

            return sum.ToString();
        }

        public override string solution2()
        {
            BigInteger result = new BigInteger(1);
            for(int i = 2; i <= 100; i ++)
            {
                result = result * i;
            }
            string resultString = result.ToString();
            int sum = 0;
            for(int i = 0; i < resultString.Length; i++)
            sum += resultString[i] - '0';

            return sum.ToString();
        }
    }
}
