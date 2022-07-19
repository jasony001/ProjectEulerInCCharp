using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerLib.MoreMath
{
    public class CombinationCalculator
    {
        public long NumberOfCombinations(long n, long m)
        {
            if (n < m) return 0;
            if (n <= 0 || m <= 0) return 0;
            if (n == m) return 1;
            if (m == 1) return n;

            long n1 = NumberOfCombinations(n - 1, m - 1);
            long n2 = NumberOfCombinations(n - 1, m);

            return n1 + n2;
        }

        public List<List<T>> ListCombinations<T>(List<T> list, long m)
        {
            List<List<T>> allCombinations = new List<List<T>>();
            if (list.Count < 0 || m < 0) return allCombinations;
            if (list.Count == 0) return allCombinations;
            if (m == 0) return allCombinations;
            if (list.Count < m) return allCombinations;

            if (m == 1) 
            {
                foreach(T obj in list)
                {
                    allCombinations.Add(new List<T>{obj});
                }
                return allCombinations;
            }

            for(int i = 0; i < list.Count; i ++)
            {
                List<T> subList = new List<T>();
                for(int j = i + 1; j < list.Count; j ++) subList.Add(list[j]);

                foreach(List<T> subCombination in ListCombinations(subList, m -1))
                {
                    List<T> combination = new List<T>{list[i]};
                    combination.AddRange(subCombination);
                    allCombinations.Add(combination);
                }
            }

            return allCombinations;
        }
    
        public long NumberOfPermutaions (long n)
        {
            long result = 1;
            while(n > 1) { result *= n; n--; }

            return result;
        }
    }
}