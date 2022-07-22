using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem43Solver : ProblemSolver
    {
        public Problem43Solver() : base()
        {
            Problem.Id = 43;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Sub-string divisibility";
            Problem.Description = 
@"The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.

Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:

    d2d3d4=406 is divisible by 2
    d3d4d5=063 is divisible by 3
    d4d5d6=635 is divisible by 5
    d5d6d7=357 is divisible by 7
    d6d7d8=572 is divisible by 11
    d7d8d9=728 is divisible by 13
    d8d9d10=289 is divisible by 17

Find the sum of all 0 to 9 pandigital numbers with this property.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 43,
                Description = "Need a lot refactoring",
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
                List<long> subStringDivisibleNumbers = new List<long>();
                for(int i17 = 17; i17 < 1000; i17 += 17)
                {
                    List<int> list13 = FindPreviousDigit(i17, 7);
                    foreach(int i13 in list13)
                    {
                        List<int> list11 = FindPreviousDigit(i13, 6 );
                        foreach(int i11 in list11)
                        {
                            List<int> list7 = FindPreviousDigit(i11, 5);
                            foreach(int i7 in list7)
                            {
                                List<int> list5 = FindPreviousDigit(i7, 4);
                                foreach(int i5 in list5)
                                {
                                    List<int> list3 = FindPreviousDigit(i5, 3);
                                    foreach(int i3 in list3)
                                    {
                                        List<int> list2 = FindPreviousDigit(i3, 2);
                                        foreach(int i2 in list2)
                                        {
                                            for (int i1 = 100; i1 <=900; i1 +=100)
                                            {
                                                long divisibleNumber = i17;
                                                long powerOf10 = 1000;
                                                int [] digits = new int[] {i13, i11, i7, i5, i3, i2, i1};
                                                foreach(int d in digits)
                                                {
                                                    divisibleNumber += d / 100 * powerOf10;
                                                    powerOf10 *= 10;
                                                }

                                                if (IsPandigitalNumber(divisibleNumber, 10))
                                                {
                                                    subStringDivisibleNumbers.Add(divisibleNumber);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                foreach(long n in subStringDivisibleNumbers)
                {
                    Console.WriteLine(n);
                }

                return subStringDivisibleNumbers.Sum(n => n).ToString();
            }

        private bool IsPandigitalNumber(long n, int digitsCount)
        {
            string s = n.ToString();
            if (s.Length != digitsCount) return false;
            if (s.ToArray().Distinct().Count() != digitsCount) return false;

            return true;
        }

        List<int> FindPreviousDigit(int n, int startingDigit)
            {
                List<int> pList = new List<int>();
                int [] primes = new int []{1, 1, 2, 3, 5, 7, 11, 13, 17};
                if (startingDigit > 7 || startingDigit < 2) return pList;
                int x = n/10;
                for(int i = 0; i <= 9; i ++)
                {
                    int p = i * 100 + x;
                    if (p % primes[startingDigit] == 0)
                        pList.Add(p);
                }

                return pList;
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
