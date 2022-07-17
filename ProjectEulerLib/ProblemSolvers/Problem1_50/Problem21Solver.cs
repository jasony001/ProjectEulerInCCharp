using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem21Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {

            },
            new List<string>{

            }
        };

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
                Description = "",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "Flatten the grid, build rowLists, columnLists, ForwardDiagonalLists, backDiagonalLists. Then loop to find the max product of 4.",
            //     Version = 2,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            // });
        }

        long[] PrimesUnder100 = new MoreMath.PrimeCalculator().SeiveOfEratosthenes(100);
        Dictionary<long, int> GetPrimeFactorsDict(long n)
        {
            long o = n;
            Dictionary<long, int> primeFactorsDict = new Dictionary<long, int>();
            foreach (long p in PrimesUnder100)
            {
                int pow = 0;
                while (n % p == 0)
                {
                    pow++;
                    n /= p;
                }
                if (pow > 0) primeFactorsDict.Add(p, pow);
            }

            if (n < o && n > 1) primeFactorsDict.Add(n, 1);

            return primeFactorsDict;
        }

        public List<long> GetFactors(long n)
        {
            Dictionary<long, int> primeFactorsDict = GetPrimeFactorsDict(n);
            MoreMath.CombinationCalculator worker = new MoreMath.CombinationCalculator();

            List<long> factors = new List<long> { 1 };
            for (int i = 1; i <= primeFactorsDict.Count; i++)
            {
                List<List<long>> primeKeyCombinations = worker.ListCombinations<long>(primeFactorsDict.Keys.ToList(), i);
                foreach (List<long> combination in primeKeyCombinations)
                {
                    List<List<long>> factorsBaseListList = new List<List<long>>();
                    foreach (long p in combination)
                    {
                        List<long> factorsBaseList = new List<long>();
                        int pow = primeFactorsDict[p];
                        for (int m = 1; m <= pow; m++)
                        {
                            factorsBaseList.Add((long)Math.Pow(p, m));
                        }
                        factorsBaseListList.Add(factorsBaseList);
                    }

                    factors.AddRange(GetCombinedFactors(factorsBaseListList));
                }
            }

            factors.Sort();
            return factors;
        }

        long GetSumOfFactors(long n)
        {
            if (n <= 1) return 0;
            long sum = 0;
            List<long> factors = GetFactors(n);
            factors.Remove(n);
            foreach (long f in factors) sum += f;

            return sum;
        }

        private List<long> GetCombinedFactors(List<List<long>> factorsBaseListList)
        {

            List<long> limits = new List<long>();
            List<int> indecies = new List<int>();
            foreach (List<long> factorBaseList in factorsBaseListList)
            {
                limits.Add(factorBaseList.Count);
                indecies.Add(0);
            }

            List<long> combinedFactors = new List<long>();
            while (indecies[0] < limits[0])
            {
                long factor = 1;
                for (int i = 0; i < factorsBaseListList.Count; i++)
                {
                    List<long> factorBaseList = factorsBaseListList[i];
                    factor *= factorBaseList[indecies[i]];
                }
                combinedFactors.Add(factor);

                // increase index by 1, carry 1 when exceeds limit
                int position = factorsBaseListList.Count - 1;
                indecies[position]++;
                while (limits[position] == indecies[position] && position > 0)
                {
                    if (position > 0)
                    {
                        indecies[position] = 0;
                        indecies[position - 1] = indecies[position - 1] + 1;
                        position--;
                    }
                }
            }

            return combinedFactors;
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
                    sum += i;
                    s = s + " + " + i.ToString();
                }
            }

            return s + " = " + sum.ToString();
        }

        public override string solution2()
        {
            return "";
        }
    }
}
