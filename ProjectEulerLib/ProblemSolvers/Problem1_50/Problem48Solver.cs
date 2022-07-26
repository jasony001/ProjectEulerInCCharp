using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem48Solver : ProblemSolver
    {
        public Problem48Solver() : base()
        {
            Problem.Id = 48;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Self powers";
            Problem.Description = 
@"The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.

Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 48,
                Description = "'Kind of' brutal force. use an int[10] to represent an integer. for each multiplication or addition, carry digits, only save the last ten digits.",
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

        public int [] IntTo10DigitArray(int n)
        {
            int [] result = new int[10];
            int index = 9;
            while (n > 0)
            {
                result[index--] = n % 10;
                n /= 10;
            }

            return result;
        }

        public int [] IntMultiply10DigitArray(int x, int[] tenDigitArray)
        {
            int [] result = new int[10];

            for(int i = 0; i < tenDigitArray.Length; i ++)
            {
                result[i] = tenDigitArray[i] * x;
            }

            int carry = 0;
            for(int i = 9; i >= 0; i --)
            {
                int value = carry + result[i];
                result[i] = value % 10;
                carry = value / 10;
            }

            return result;
        }


        public int [] AddTwo10DigitArrays(int[] tenDigitArrayA, int[] tenDigitArrayB)
        {
            int [] result = new int[10];
            for(int i = 0; i < tenDigitArrayA.Length; i ++)
            {
                result[i] = tenDigitArrayA[i] + tenDigitArrayB[i];
            }

            int carry = 0;
            for(int i = 9; i >= 0; i --)
            {
                int value = carry + result[i];
                result[i] = value % 10;
                carry = value / 10;
            }

            return result;
        }

        public override string solution1()
        {
            int [] last10DigitsOfSum = new int [10];

            for(int i = 1; i <= 1000; i ++)
            {
                int [] last10DigitsOfPower = new int [10];
                last10DigitsOfPower[9] = 1;
                for(int pow = 1; pow <=i; pow ++)
                {
                    last10DigitsOfPower = IntMultiply10DigitArray(i, last10DigitsOfPower);
                }

                last10DigitsOfSum = AddTwo10DigitArrays(last10DigitsOfSum, last10DigitsOfPower);
            }

            string answer = "";
            for(int i = 0; i < 10; i ++) answer = answer + last10DigitsOfSum[i].ToString();

            return answer;
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
