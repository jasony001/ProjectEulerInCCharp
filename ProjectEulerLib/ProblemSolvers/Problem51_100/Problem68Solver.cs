using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem68Solver : ProblemSolver
    {
        public Problem68Solver() : base()
        {
            Problem.Id = 68;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Magic 5-gon ring";
            Problem.Description = "Using the numbers 1 to 10, and depending on arrangements, it is possible to form 16- and 17-digit strings. What is the maximum 16-digit string for a 'magic' 5-gon ring?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 68,
                Description = 
@"For the answer to be 16 digits, number 10 must not be in the inner circle,
// 10 + i1 + i2
// i6 + i2 + i3
// i7 + i3 + i4
// i8 + i4 + i5
// i9 + i5 + i1
9 level loop, those sums should be the same
pick the set that 5 lines start with 6, 7, 8, 9, 10. that is, the minimum start number is 6.
rotate the 5 3-number set, until the set starts with 6 is the first set
toString(), save the max
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

        List<T> ListExcept<T>(List<T> list, T x)
        {
            List<T> resultList = new List<T>();
            resultList.AddRange(list);
            resultList.Remove(x);

            return resultList;
        }
        public override string solution1()
        {
            // 10 + i1 + i2
            // i6 + i2 + i3
            // i7 + i3 + i4
            // i8 + i4 + i5
            // i9 + i5 + i1

            List<int> list9 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string answer = "";

            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                int i1 = list9[i];
                List<int> list8 = ListExcept<int>(list9, i1);
                
                for (int j = 0; j < 8; j++)
                {
                    int i2 = list8[j];
                    List<int> list7 = ListExcept<int>(list8, i2);

                    int sum = 10 + i1 + i2;

                    for (int k = 0; k < 7; k++)
                    {
                        int i3 = list7[k];
                        List<int> list6 = ListExcept<int>(list7, i3);
                        for (int m = 0; m < 6; m++)
                        {
                            int i4 = list6[m];
                            List<int> list5 = ListExcept<int>(list6, i4);

                            for (int n = 0; n < 5; n++)
                            {
                                int i5 = list5[n];
                                List<int> list4 = ListExcept<int>(list5, i5);
                                for (int p = 0; p < 4; p++)
                                {
                                    int i6 = list4[p];
                                    if (i6 + i2 + i3 != sum) continue;

                                    List<int> list3 = ListExcept<int>(list4, i6);
                                    for (int q = 0; q < 3; q++)
                                    {
                                        int i7 = list3[q];
                                        if (i7 + i3 + i4 != sum) continue;
                                        List<int> list2 = ListExcept<int>(list3, i7);

                                        for (int r = 0; r < 2; r++)
                                        {
                                            int i8 = list2[r];
                                            if (i8 + i4 + i5 != sum) continue;
                                            List<int> list1 = ListExcept<int>(list2, i8);

                                            int i9 = list1[0];

                                            if (i8 + i4 + i5 != sum) continue;
                                            if (i6 < 6 || i7 < 6 || i8 < 6 || i9 < 6) continue;

                                            List<List<int>> ring = new List<List<int>>{
                                                new List<int> { 10, i1, i2 },
                                                new List<int> { i6, i2, i3 },
                                                new List<int> { i7, i3, i4 },
                                                new List<int> { i8, i4, i5 },
                                                new List<int> { i9, i5, i1 },
                                            };

                                            while (ring[0][0] != 6)
                                            {
                                                List<int> listT = new List<int>();
                                                listT.AddRange(ring[0]);
                                                for(int x = 0; x < 4; x++)
                                                {
                                                    ring[x].Clear();
                                                    ring[x].AddRange(ring[x + 1]);
                                                }
                                                ring[4].Clear();
                                                ring[4].AddRange(listT);
                                            }

                                            for(int y = 0; y < 5; y ++)
                                            {
                                                Console.Write($"[{ring[y][0]} {ring[y][1]} {ring[y][2]}] ");
                                            }
                                            Console.WriteLine();

                                            string s = "";
                                            for(int y = 0; y < 5; y ++)
                                                for(int z = 0; z < 3; z ++)
                                                    s = s + ring[y][z].ToString();
                                            if (s.CompareTo(answer) > 0) answer = s;


                                            count++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

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
