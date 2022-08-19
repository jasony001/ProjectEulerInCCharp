using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem106Solver : ProblemSolver
    {
        public Problem106Solver() : base()
        {
            Problem.Id = 106;
            Problem.UpperBound = 12;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Special subset sums: meta-testing";
            Problem.Description = 
@"

Let S(A) represent the sum of elements in set A of size n. We shall call it a special sum set if for any two non-empty disjoint subsets, B and C, the following properties are true:

    S(B) ≠ S(C); that is, sums of subsets cannot be equal.
    If B contains more elements than C then S(B) > S(C).

For this problem we shall assume that a given set contains n strictly increasing elements and it already satisfies the second rule.

Surprisingly, out of the 25 possible subset pairs that can be obtained from a set for which n = 4, only 1 of these pairs need to be tested for equality (first rule). Similarly, when n = 7, only 70 out of the 966 subset pairs need to be tested.

For n = 12, how many of the 261625 subset pairs that can be obtained need to be tested for equality?

NOTE: This problem is related to Problem 103 and Problem 105.
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 106,
                Description = 
@"
only need to test when first set item count = second set item count
for(int subSetItemCount = 2; subSetItemCount <= Problem.UpperBound / 2; subSetItemCount ++)
{
    for each combination for first set
        for each combination in seconset
            sort first set and second set
            if f[0] > s[0] and there is any f[x] < s[x], then count it
}
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
            List<int> wholeSet = new List<int>();
            for(int i = 1; i <= Problem.UpperBound; i ++) wholeSet.Add(i);

            long needTestPairCount = 0;
            for(int subSetItemCount = 2; subSetItemCount <= Problem.UpperBound / 2; subSetItemCount ++)
            {
                needTestPairCount += GetNeedTestPairCount(subSetItemCount, wholeSet);
            }
            
            return needTestPairCount.ToString();
        }

        private long GetNeedTestPairCount(int subSetItemCount, List<int> wholeSet)
        {
            int count = 0;
            MoreMath.CombinationCalculator combinationCalculator = new MoreMath.CombinationCalculator();

            foreach(List<int> firstSet in combinationCalculator.ListCombinations<int>(wholeSet, subSetItemCount))
            {
                List<int> remainingItems = wholeSet.Where(n => !firstSet.Contains(n)).ToList();
                foreach(List<int> secondSet in combinationCalculator.ListCombinations<int>(remainingItems, subSetItemCount))
                {
                    firstSet.Sort();
                    secondSet.Sort();

                    int sign = firstSet[0] > secondSet[0] ? 1 : -1;
                    for(int j = 1; j < subSetItemCount; j ++)
                    {
                        if (sign == 1 && firstSet[j] < secondSet[j] || sign == -1 && firstSet[j] > secondSet[j])
                        {
                            count ++;
                            break;
                        }
                    }
                }
            }

            return count / 2;
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
