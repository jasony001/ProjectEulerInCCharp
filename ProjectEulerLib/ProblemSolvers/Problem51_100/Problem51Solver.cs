using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem51Solver : ProblemSolver
    {
        public Problem51Solver() : base()
        {
            Problem.Id = 51;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 51,
                Description = 
@"set a limit of how many digits. If no solution is found for numbers under certain digits, return 'no solution found'
for 2 digit numbers, mask can be applied to 1 digit (1 or 2)
for 3 digit numbers, mask can be applied to 1 digit (1, 2, or 3), 2 digits (1 2, 1 3, or 2 3)
...
foreach of the above case (under maxDigits), 
    first eliminate cases by 3 modular. Test if it's possible to get 8 numbers that cannot be devided by 3.
        bool ValidateDigits(int digits, int [] positions)
    if the case is valid, check each possible number is a prime, by using the prepopulated prime boolean array.
    If the prime count >= 8, a solution is found.
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
            int digits = 2;
            int maxDigits = 6;
            MoreMath.CombinationCalculator combinationCalculator = new MoreMath.CombinationCalculator();
            MoreMath.PrimeCalculator primeCalculator = new MoreMath.PrimeCalculator();
            bool [] primeFlags = primeCalculator.GetPrimeFlagArray((long)Math.Pow(10, maxDigits));

            while(digits <= maxDigits)
            {
                List<int> positions = new List<int>();
                for(int mc = 0; mc < digits; mc ++)
                    positions.Add(mc);

                for(long pick = 1; pick < digits; pick ++)
                {
                    List<List<int>> combinations = combinationCalculator.ListCombinations<int>(positions, pick);
                    foreach(List<int> vpList in combinations)
                    {
                        bool isValid = ValidateDigits(digits, vpList.ToArray());
                        if (isValid)
                        {
                            List<int> cpList = positions.Where(p => !vpList.Contains(p)).ToList();
                            long cpNumber = (long)Math.Pow(10, cpList.Count);
                            for(long c = 0; c < cpNumber; c++)
                            {
                                int primeCount = 0;
                                int start = vpList.Any(p => p == 0) ? 1 : 0;
                                int firstV = -1;
                                for(int v = start; v < 10; v ++)
                                {
                                    long number = GetTestNumber(digits, cpList, c, v);
                                    if (number > 0 && primeFlags[number]) 
                                    {
                                        primeCount ++;
                                        if (firstV < 0) firstV = v;
                                    }
                                }

                                if (primeCount >= 8)
                                    return GetTestNumber(digits, cpList, c, 1).ToString();
                            }
                        }
                    }
                }

                digits ++;
            }
           
            long maxNumber = (long)Math.Pow(10, maxDigits);
            return $"no solution found under {maxNumber}";
        }

        private long GetTestNumber(int digits, List<int> cpList, long c, long v)
        {
            // apply mask (v)
            string format = "";
            for(int i = 0; i < cpList.Count; i ++) format = format + "0";
            string cNumberString = c.ToString(format);
            string numberString = "";
            for(int index = 0, cIndex = 0; index < digits; index ++)
            {
                if (cpList.Contains(index)) 
                {
                    numberString = numberString + cNumberString[cIndex]; 
                    cIndex ++;
                } 
                else 
                {
                    numberString = numberString + v;
                }
            }
            if (numberString.StartsWith("0")) return -1;

            return Convert.ToInt64(numberString);
        }
        
        bool ValidateDigits(int digits, int [] positions)
        {
            long multiple = 0;
            foreach (var position in positions)
                multiple += (long)Math.Pow(10, digits - 1 - position);

            int start = positions.Any(p => p == 0) ? 1 : 0;
            int r0 = 0;
            for(int cr = 0; cr < 3; cr ++)      // the constant part of a number, possible remaindar where devided by 3 are 0, 1, or 2
            {
                r0 = 0;
                for(long v = start; v < 10; v ++)
                {
                    long n = (v * multiple + cr);
                    if (n % 3 == 0) r0 ++;
                }
            }

            return r0 <= 2;
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
