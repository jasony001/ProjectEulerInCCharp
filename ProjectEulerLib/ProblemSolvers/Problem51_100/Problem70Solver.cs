using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem70Solver : ProblemSolver
    {
        public Problem70Solver() : base()
        {
            Problem.Id = 70;
            Problem.UpperBound = 10000000;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 70,
                Description = 
@"Cannot improved to within 7000 ms. 
BuildRelativePrimeInfoArray, 
then findMinN
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
            return findMinN(BuildRelativePrimeInfoArray()).ToString();
        }

        int findMinN(RelateivePrimeInfo[] relateivePrimeInfoArray)
        {
            double minRatio = double.MaxValue;
            int minN = int.MaxValue;

            for (int n = 2; n <= Problem.CalculatedIncludedUpperBound; n++)
            {
                double ratio = (double)n / relateivePrimeInfoArray[n].RelateivePrimeCount;
                if (ratio < minRatio)
                {
                    bool isPermutation  = IsPermutation(n, relateivePrimeInfoArray[n].RelateivePrimeCount);
                    
                    if (!isPermutation) continue;
                    minRatio = ratio;
                    minN = n;
                }
            }

            return minN;
        }

        RelateivePrimeInfo[] InitializeRelativePrimeInfoArray()
        {
            RelateivePrimeInfo[] relateivePrimeInfoArray = new RelateivePrimeInfo[Problem.CalculatedIncludedUpperBound + 1];

            for (int i = 0; i <= Problem.CalculatedIncludedUpperBound; i++)
            {
                relateivePrimeInfoArray[i] = new RelateivePrimeInfo
                {
                    Number = i,
                    RelateiveFactorCount = 0,
                    PrimeFactorList = new List<int>(),
                    IsPrime = true
                };
            }

            return relateivePrimeInfoArray;
        }

        RelateivePrimeInfo[] BuildRelativePrimeInfoArray()
        {
            RelateivePrimeInfo[] relateivePrimeInfoArray = InitializeRelativePrimeInfoArray();

            for (int n = 2; n < relateivePrimeInfoArray.Length / 2; n++)
            {
                if (!relateivePrimeInfoArray[n].IsPrime) continue;
                for (int i = n * 2, j=2; i < relateivePrimeInfoArray.Length; i += n, j ++)
                {
                    relateivePrimeInfoArray[i].RelateiveFactorCount += j - 1;
                    foreach (int p in relateivePrimeInfoArray[i].PrimeFactorList)
                        relateivePrimeInfoArray[i].RelateiveFactorCount -= (i / (p * n) - 1);
                    relateivePrimeInfoArray[i].RelateivePrimeCount = i - relateivePrimeInfoArray[i].RelateiveFactorCount - 1;
                    relateivePrimeInfoArray[i].PrimeFactorList.Add(n);
                    relateivePrimeInfoArray[i].IsPrime = false;
                }
            }

            return relateivePrimeInfoArray;
        }

        bool IsPermutation(int n1, int n2)
        {
            if (n1 * 10 < n2 || n2 * 10 < n1) return false;

            int [] dc1 = new int[10];
            int [] dc2 = new int[10];

            while (n1 > 0)
            {
                dc1[n1%10] ++; n1 /= 10;
                dc2[n2%10] ++; n2 /= 10;
            }

            for(int i = 0; i < 10; i ++)
                if(dc1[i] != dc2[i]) return false;

            return true;
        }

//         RelateivePrimeInfo[] BuildRelativePrimeInfoArray2()
//         {
//             RelateivePrimeInfo[] relateivePrimeInfoArray = InitializeRelativePrimeInfoArray();

//             // for(int n = 2; n < Math.Sqrt(Problem.CalculatedIncludedUpperBound + 1); n ++)
//             // {
//             //     if (relateivePrimeInfoArray[n].PrimeFactorList.Count != 0) continue;
//             //     for(int i = n * 2; i < Problem.CalculatedIncludedUpperBound + 1; i +=n)
//             //         relateivePrimeInfoArray[i].PrimeFactorList.Add(n);
//             // }
// // 2600
// //             for(int n = (int)Math.Sqrt(Problem.CalculatedIncludedUpperBound + 1); n <= Problem.CalculatedIncludedUpperBound; n ++)
// //             {
// //                 int a = n;
// //                 foreach(int p in relateivePrimeInfoArray[n].PrimeFactorList)
// //                 {
// //                     while(a % p == 0) a/=p;
// //                 }
// //                 if (a > Math.Sqrt(n)) relateivePrimeInfoArray[n].PrimeFactorList.Add(a);
// //             }
// // // 3600

// //             for(int n = 2; n <=Problem.CalculatedIncludedUpperBound; n ++)
// //             {
// //                 if (relateivePrimeInfoArray[n].PrimeFactorList.Count == 0) continue;
                
// //                 int rfCount = 0;
// //                 int rpCount = 0;
// //                 for(int pIndex = 0; pIndex < relateivePrimeInfoArray[n].PrimeFactorList.Count; pIndex ++)
// //                 {
// //                     int p = relateivePrimeInfoArray[n].PrimeFactorList[pIndex];
// //                     rfCount += n / p -1;

// //                     foreach (int ps in relateivePrimeInfoArray[n].PrimeFactorList.Where(pp => pp < p))
// //                         rfCount -= (n / (p * ps) - 1);
// //                     rpCount = n - rfCount - 1;
// //                 }

// //                 relateivePrimeInfoArray[n].RelateivePrimeCount = rpCount;
// //             }

//             return relateivePrimeInfoArray;
//         }

        public override string solution2()
        {


            return "work on  it";
        }

        public override string solution3()
        {
            return "";
        }
    }

    public class RelateivePrimeInfo
    {
        public int Number { get; set; }

        public int RelateiveFactorCount { get; set; }

        public int RelateivePrimeCount { get; set; }

        public List<int> PrimeFactorList { get; set; }

        public bool IsPrime { get; set; }

        public int Residue {get;set;}
    }
}
