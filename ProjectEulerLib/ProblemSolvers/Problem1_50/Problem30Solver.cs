using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem30Solver : ProblemSolver
    {
        public Problem30Solver() : base()
        {
            Problem.Id = 30;
            Problem.UpperBound = 5;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Digit fifth powers";
            Problem.Description =
@"Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

    1634 = 1^4 + 6^4 + 3^4 + 4^4
    8208 = 8^4 + 2^4 + 0^4 + 8^4
    9474 = 9^4 + 4^4 + 7^4 + 4^4

As 1 = 1^4 is not a sum it is not included.

The sum of these numbers is 1634 + 8208 + 9474 = 19316.

Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 30,
                Description = "hand picked 301051 numbers, slower than brutal force",
                Version = 1,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 0,
                Description = "Brutal force 100 to 354294 (6 * 9^5)",
                Version = 2,
            });
        }

        List<int> AddOne(List<int> numberDigits, int highestNumber)
        {
            int index = numberDigits.Count() - 1;
            while (index >= 0)
            {
                numberDigits[index] = numberDigits[index] + 1;
                if (numberDigits[index] > highestNumber)
                {
                    numberDigits[index] = 0;
                    index--;
                }
                else
                {
                    return numberDigits;
                }
            }

            return numberDigits;
        }

        public override string solution1()
        {
            int digits = 2;
            long total = 0;
            List<long> answers = new List<long>();

            while (digits * Math.Pow(9, Problem.UpperBound.Value) > Math.Pow(10, digits - 1))
            {
                int highestNumber = 9; // highest number in each digit
                while (Math.Pow(highestNumber, Problem.UpperBound.Value) > Math.Pow(10, digits)) highestNumber--;
                int lowestNumber = 0; // at least one digit with this number or higher
                while (digits * Math.Pow(lowestNumber, Problem.UpperBound.Value) < Math.Pow(10, digits - 1)) lowestNumber++;
                int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }.Where(n => n <= highestNumber).ToArray();

                MoreMath.CombinationCalculator worker = new MoreMath.CombinationCalculator();
                int[] atLeast1NumberList = numbers.Where(n => n >= lowestNumber).ToArray();

                List<string> possibleNumbers = new List<string>();
                List<long> fifthPowerList = new List<long>();
                for (int i = 0; i < 10; i++) fifthPowerList.Add((long)Math.Pow(i, Problem.UpperBound.Value));

                foreach (int n1 in atLeast1NumberList)
                {
                    List<int> numberDigits = new List<int> { n1 };
                    for (int i = 0; i < digits - 1; i++) numberDigits.Add(0);
                    while (numberDigits[0] == n1)
                    {
                        long sum = FifthPowerSum(numberDigits, fifthPowerList);
                        string sumString = String.Concat(sum.ToString().OrderBy(c => c));

                        string numberStr = "";
                        for (int i = 0; i < digits; i++) numberStr = numberStr + (char)(numberDigits[i] + '0');

                        numberDigits = AddOne(numberDigits, highestNumber);

                        if (String.Concat(sum.ToString().OrderBy(c => c)) == String.Concat(numberStr.ToString().OrderBy(c => c)))
                        {
                            if (answers.Contains(sum)) continue;
                            answers.Add(sum);
                            // found 1
                            total += sum;
                        }

                    }



                }

                digits++;
            }

            return total.ToString();
        }

        private long FifthPowerSum(List<int> numberDigits, List<long> fifthPowerList)
        {
            long sum = 0;
            foreach (int d in numberDigits)
            {
                sum += fifthPowerList[d];
            }

            return sum;
        }

        private long FifthPowerSum(long n, List<long> fifthPowerList)
        {
            long sum = 0;
            while (n > 0)
            {
                long d = n % 10;
                n /= 10;
                sum += fifthPowerList[(int)d];
            }

            return sum;
        }

        public override string solution2()
        {
            List<long> fifthPowerList = new List<long>();
            for (int i = 0; i < 10; i++) fifthPowerList.Add((long)Math.Pow(i, Problem.UpperBound.Value));
            long total = 0;

            int digits = 2;
            long NumberWithAll9s = digits * (long)Math.Pow(9, Problem.UpperBound.Value); 
            while (NumberWithAll9s > Math.Pow(10, digits - 1))
            {
                long upperLimit = Math.Min(NumberWithAll9s + 1, (long)(Math.Pow(10, digits)));
                for (long l = (long)(Math.Pow(10, digits - 1)); l < upperLimit; l++)
                {
                    if (FifthPowerSum(l, fifthPowerList) == l)
                    {
                        total += l;
                    }
                }

                digits ++;
                NumberWithAll9s = digits * (long)Math.Pow(9, Problem.UpperBound.Value); 
            }

            return total.ToString();
        }
    }
}
