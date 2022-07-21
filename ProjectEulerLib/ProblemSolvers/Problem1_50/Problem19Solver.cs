using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem19Solver : ProblemSolver
    {
        const long HALF_MAX = long.MaxValue / 2;

        public Problem19Solver() : base()
        {
            Problem.Id = 19;
            Problem.UpperBound = 1000;
            Problem.Title = "Counting Sundays";
            Problem.Description = 
@"

You are given the following information, but you may prefer to do some research for yourself.

    1 Jan 1900 was a Monday.
    Thirty days has September,
    April, June and November.
    All the rest have thirty-one,
    Saving February alone,
    Which has twenty-eight, rain or shine.
    And on leap years, twenty-nine.
    A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 19,
                Description = "",
                Version = 1,
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 19,
            //     Description = "put number in a list, each item is 1 digit. use junior school math multiplication carry digit. Perform carry when any of the item is over long.Maxvalue / 2.",
            //     Version = 2,
            // });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 19,
            //     Description = "Rever the number, save number 1234 in a list<int> {4, 3, 2, 1}. When perform carry, use List.Add instead of List.Insert.  Turned out that List.add costs same amount of time as List.Insert.",
            //     Version = 3,
            // });
        }

        public override string solution1()
        {
            int year = 1900;
            int dayOfWeekOnJan1st = 1;
            int totalSundaysOn1st = 0;

            while(year < 2000)
            {
                bool isLastYearLeapYear = (year %4 == 0 && year % 100 != 0 ) || year %400 == 0;
                int daysInTheYear = isLastYearLeapYear ? 366 : 365; // 366 % 7 or 365 % 7
                dayOfWeekOnJan1st = (dayOfWeekOnJan1st + daysInTheYear) % 7;
                int dayOfWeekOn1st = dayOfWeekOnJan1st;
                if (dayOfWeekOn1st == 0) totalSundaysOn1st ++;

                bool isThisYearLeapYear = ((year + 1) %4 == 0 && (year + 1) % 100 != 0 ) || (year + 1) %400 == 0;

                List<int> daysInMonths = new List<int>{31, isThisYearLeapYear?29:28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
                for(int m = 1; m < 12; m ++)
                {
                    dayOfWeekOn1st = (dayOfWeekOn1st + daysInMonths[m - 1]) % 7;
                    if (dayOfWeekOn1st == 0) 
                    {
                        totalSundaysOn1st ++;
                    }
                }

                year ++;
            }

            return totalSundaysOn1st.ToString();
        }
    }
}