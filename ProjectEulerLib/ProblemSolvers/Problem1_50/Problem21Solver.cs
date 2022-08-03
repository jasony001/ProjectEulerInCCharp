using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem21Solver : ProblemSolver
    {

        public Problem21Solver() : base()
        {
            Problem.Id = 21;
            Problem.UpperBound = 10000;
            Problem.IsClosedOnRight = false;
            Problem.Title = "Amicable numbers";
            Problem.Description =
@"Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 21,
                Description = "Find and sum all factors for each number 2 to 1000. Find amicable pairs",
                Version = 1,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 0,
                Description = "create sum array, 1 item for each number 0 to 10000. starting with i=2, for each multiple of i, add i to the sum for that element in the arrau. find amicable pairs.",
                Version = 2,
            });
        }


        long GetSumOfFactors(long n)
        {
            if (n <= 1) return 0;
            long sum = 0;
            List<long> factors = new MoreMath.FactorCalculator().GetFactors(n);
            factors.Remove(n);
            foreach (long f in factors) sum += f;

            return sum;
        }

        public override string solution1()
        {
            List<long> factorsSumList = new List<long>(){0, 0};
            for (long i = 2; i <= Problem.CalculatedIncludedUpperBound; i++)
            {
                factorsSumList.Add(GetSumOfFactors(i));
            }

            long sum = 0;
            string s = " 0 ";
            for (int i = 2; i <= Problem.CalculatedIncludedUpperBound; i++)
            {
                if (factorsSumList[i] <= Problem.CalculatedIncludedUpperBound && factorsSumList[i] != i && factorsSumList[(int)factorsSumList[i]] == i)
                {
                    sum += i + factorsSumList[i];
                    s = s + " + [" + i.ToString() + ", " + factorsSumList[i] + "]";
                    i = Math.Max(i, (int)factorsSumList[i]) + 1;
                }
            }

            return s + " = " + sum.ToString();
        }

        public override string solution2()
        {
            long [] factorsSumList = new long[Problem.CalculatedIncludedUpperBound + 1];
            factorsSumList[0] = 0;
            factorsSumList[1] = 0;

            for (long i = 2; i <= Problem.CalculatedIncludedUpperBound; i++)
                factorsSumList[i] = 1;

            for (long i = 2; i <= Problem.CalculatedIncludedUpperBound / 2; i++)
                for(long j = 2 * i; j <= Problem.CalculatedIncludedUpperBound; j += i)
                    factorsSumList[j] += i;

            long sum = 0;
            string s = " 0 ";
            for (int i = 2; i <= Problem.CalculatedIncludedUpperBound; i++)
            {
                if (factorsSumList[i] <= Problem.CalculatedIncludedUpperBound && factorsSumList[i] != i && factorsSumList[(int)factorsSumList[i]] == i)
                {
                    sum += i + factorsSumList[i];
                    s = s + " + [" + i.ToString() + ", " + factorsSumList[i] + "]";
                    i = Math.Max(i, (int)factorsSumList[i]) + 1;
                }
            }

            return s + " = " + sum.ToString();
        }

    }
}
