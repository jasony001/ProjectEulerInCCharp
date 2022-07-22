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
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 40,
                Description = "easier to count by paper. will start over when head is clear",
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
            
            List<long> nDigitsNumberCount = new List<long>{0};
            List<long> totalNumberEqualsAndUnderNDigits = new List<long>{0};
            List<long> firstNDigitsNumbers = new List<long>(){0};
            long powerOf10 = 1;
            long total = 0;
            for(int i = 1; i <= 7; i ++) 
            {
                firstNDigitsNumbers.Add(powerOf10);
                nDigitsNumberCount.Add(i * 9 * powerOf10);
                total += nDigitsNumberCount[i];
                totalNumberEqualsAndUnderNDigits.Add(total);
                powerOf10 *= 10;
            }
firstNDigitsNumbers[1] = 0;
            long answer = 1;
            powerOf10 = 1;
            for(int i = 1; i <= 7; i ++) 
            {
                long position = powerOf10;
                long countedNumbers = 0;
                
                int t = 1;
                while(position > countedNumbers + nDigitsNumberCount[t - 1])
                {
                    countedNumbers += nDigitsNumberCount[t - 1];
                    t++;
                }

                long leftToCount = position - countedNumbers;
                long wholeNumber = firstNDigitsNumbers[i] + leftToCount / (t - 1);
                long remainder = leftToCount % (t - 1);
                int d = 0;
                if (remainder == 0)
                {
                    d = wholeNumber.ToString()[wholeNumber.ToString().Length - 1] - '0';
                }
                else
                {
                    d = (wholeNumber+1).ToString()[(int)remainder - 1] - '0';
                }

                powerOf10 *= 10;
                answer *= d;
            }

            return answer.ToString();
        }

        // public override string solution2()
        // {
        //     string s = "";
        //     int i = 1;
        //     while(s.Length < 1000000)
        //     {
        //         s = s + i.ToString();
        //         i ++;
        //     }

        //     long prd = (s[0] - '0') * 
        //         (s[9] - '0') * 
        //         (s[99] - '0') * 
        //         (s[999] - '0') * 
        //         (s[9999] - '0') * 
        //         (s[99999] - '0');
        //     return prd.ToString();
        // }

        public override string solution3()
        {
            return "";
        }
    }
}
