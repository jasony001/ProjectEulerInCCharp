using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem8Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {
"        public override string solution1()",
"        {",
"            ProjectEulerLib.MoreMath.PrimeCalculator primeCalculator = new ProjectEulerLib.MoreMath.PrimeCalculator();",
"            long upperBound = Problem.CalculatedIncludedUpperBound * 2;",
"            long increment = Problem.CalculatedIncludedUpperBound * 2;",
"            long [] primes =  primeCalculator.SeiveOfEratosthenes(upperBound);",
"            while (primes.Length < Problem.CalculatedIncludedUpperBound + 1)",
"            {",
"                upperBound += increment;",
"                primes = primeCalculator.SeiveOfEratosthenes(primes, upperBound);",
"            }",
"",
"            return primes[Problem.CalculatedIncludedUpperBound].ToString();",
"        }",
            },
            new List<string>{

            }
        };

string ProblmeParamter = 
@"73167176531330624919225119674426574742355349194934|
96983520312774506326239578318016984801869478851843|
85861560789112949495459501737958331952853208805511|
12540698747158523863050715693290963295227443043557|
66896648950445244523161731856403098711121722383113|
62229893423380308135336276614282806444486645238749|
30358907296290491560440772390713810515859307960866|
70172427121883998797908792274921901699720888093776|
65727333001053367881220235421809751254540594752243|
52584907711670556013604839586446706324415722155397|
53697817977846174064955149290862569321978468622482|
83972241375657056057490261407972968652414535100474|
82166370484403199890008895243450658541227588666881|
16427171479924442928230863465674813919123162824586|
17866458359124566529476545682848912883142607690042|
24219022671055626321111109370544217506941658960408|
07198403850962455444362981230987879927244284909188|
84580156166097919133875499200524063689912560717606|
05886116467109405077541002256983155200055935729725|
71636269561882670428252483600823257530420752963450";

        public Problem8Solver() : base()
        {
            Problem.Id = 8;
            Problem.Title = "Largest product in a series";
            Problem.Description =
                "The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.\n";
            foreach(string line in ProblmeParamter.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries ))
            {
                Problem.Description = Problem.Description + line + "\n";
            }
            Problem.Description = Problem.Description + "\n";
            Problem.Description = Problem.Description + "Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?\n";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 8,
                Description = "Brutal force",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 2,
            //     Description = "Build factor list, foreach number add dividen remainder",
            //     Version = 2,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            // });
        }

        public override string solution1()
        {
            int [] digits = new int[1000];
            int x = 0;
            foreach(char c in ProblmeParamter)
            {
                if (c < '0' || c > '9') continue;

                if (x > 999) throw new System.ArgumentException("the string is not a 1000 digits number");
                digits[x++] = c - '0';
            }

            if (x != 1000) throw new System.ArgumentException("the string is not a 1000 digits number");

            long maxP = 0;
            for(int i = 0; i < 987; i ++)
            {
                long product = 1;
                for(int j = 0; j < 13; j ++)
                {
                    product *= digits[i + j];
                }
                maxP = Math.Max(maxP, product);
            }

            return maxP.ToString();
        }

    }
}
