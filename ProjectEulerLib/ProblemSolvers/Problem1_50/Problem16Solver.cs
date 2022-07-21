using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem16Solver : ProblemSolver
    {
        const long HALF_MAX = long.MaxValue / 2;

        public Problem16Solver() : base()
        {
            Problem.Id = 16;
            Problem.UpperBound = 1000;
            Problem.Title = "Power digit sum";
            Problem.Description =
                "2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.\n" +
                "What is the sum of the digits of the number 2^1000?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 16,
                Description = "put number in a list, each item is 1 digit. use junior school math multiplication carry digit.",
                Version = 1,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 16,
                Description = "put number in a list, each item is 1 digit. use junior school math multiplication carry digit. Perform carry when any of the item is over long.Maxvalue / 2.",
                Version = 2,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 16,
                Description = "Rever the number, save number 1234 in a list<int> {4, 3, 2, 1}. When perform carry, use List.Add instead of List.Insert.  Turned out that List.add costs same amount of time as List.Insert.",
                Version = 3,
            });
        }

        public override string solution1()
        {
            List<long> number = new List<long> { 1 };
            for (int i = 0; i < Problem.UpperBound; i++)
            {
                number = Multiply(number, 2);
            }

            long sum = 0;
            for (int i = 0; i < number.Count(); i++)
            {
                sum += number[i];
            }

            return sum.ToString();
        }

        public List<long> Multiply(List<long> number, int x)
        {
            List<long> result = new List<long>();
            for (int i = 0; i < number.Count(); i++)
            {
                result.Add(number[i] * x);
            }

            return PerformCarry(result);
        }

        public override string solution2()
        {
            List<long> number = new List<long> { 1 };
            for (int i = 0; i < Problem.UpperBound; i++)
            {
                number = MultiplyLessCarry(number, 2);
            }

            number = PerformCarry(number);

            long sum = 0;
            for (int i = 0; i < number.Count(); i++)
            {
                sum += number[i];
            }

            return sum.ToString();
        }

        public List<long> MultiplyLessCarry(List<long> number, int x)
        {
            List<long> result = new List<long>();
            bool performCarry = false;
            for (int i = 0; i < number.Count(); i++)
            {
                long n = number[i] * x;
                result.Add(n);
                if (n > HALF_MAX) { performCarry = true; }
            }

            return performCarry ? PerformCarry(result) : result;
        }

        public List<long> PerformCarry(List<long> result)
        {

            long carry = 0;
            List<long> finalResult = new List<long>();
            for (int i = result.Count() - 1; i > 0; i--)
            {
                long d = (carry + result[i]) % 10;
                finalResult.Insert(0, d);
                carry = (carry + result[i]) / 10;
            }

            long f = carry + result[0];
            while (f > 0)
            {
                finalResult.Insert(0, f % 10);
                f /= 10;
            }

            return finalResult;
        }

        public override string solution3()
        {
            List<long> number = new List<long>() { 1 };

            for (int i = 0; i < Problem.UpperBound; i++)
            {
                number = MultiplyReverseCarry(number, 2);
            }

            number = PerformReverseCarry(number);

            long sum = 0;
            for (int i = 0; i < number.Count(); i++)
            {
                sum += number[i];
            }

            return sum.ToString();
        }

        public List<long> MultiplyReverseCarry(List<long> number, byte x)
        {
            List<long> result = new List<long>();
            bool performCarry = false;
            for (int i = 0; i < number.Count(); i++)
            {
                long n = number[i] * x;
                result.Add(n);
                if (n > HALF_MAX) { performCarry = true; }
            }
            return performCarry ? PerformReverseCarry(result) : result;
        }

        public List<long> PerformReverseCarry(List<long> result)
        {

            long carry = 0;
            List<long> finalResult = new List<long>();
            for (int i = 0; i < result.Count() - 1; i++)
            {
                long d = (carry + result[i]) % 10;
                finalResult.Add(d);
                carry = (carry + result[i]) / 10;
            }

            long f = carry + result[result.Count() - 1];
            while (f > 0)
            {
                finalResult.Add(f % 10);
                f /= 10;
            }

            return finalResult;
        }
    }
}