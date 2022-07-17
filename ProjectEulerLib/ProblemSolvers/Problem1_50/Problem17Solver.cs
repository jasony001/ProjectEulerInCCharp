using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem17Solver : ProblemSolver
    {
        const long HALF_MAX = long.MaxValue / 2;

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {
"        public override string solution1()",
"        {",
"            string [] oneToNineWords = ",
"                new string []{\"one\", \"two\", \"three\", \"four\", \"five\", \"six\", \"seven\", \"eight\", \"nine\"};",
"            string [] tenToNineTeenWords = ",
"                new string []{\"ten\", \"eleven\", \"twelve\", \"thirteen\", \"fourteen\", \"fifteen\", \"sixteen\", \"seventeen\", \"eighteen\", \"nineteen\"};",
"            string[] twentyToNinetyWords = ",
"                new string []{\"twenty\", \"thirty\", \"forty\", \"fifty\", \"sixty\", \"seventy\", \"eighty\", \"ninety\"};",
"",
"",
"            int oneToNine = 0;",
"            foreach(var w in oneToNineWords) oneToNine +=  w.Length;",
"",
"",
"            int tenToNineteen = 0;",
"            foreach(var w in tenToNineTeenWords) tenToNineteen +=  w.Length;",
"            Console.WriteLine($\"tenToNineteen = {tenToNineteen}\");",
"            ",
"            int twentyToNinetyNine = 0;",
"            foreach (var w in twentyToNinetyWords) twentyToNinetyNine += w.Length * 10 + oneToNine;",
"",
"            int oneToNinetyNine = oneToNine + tenToNineteen + twentyToNinetyNine;",
"            int total = oneToNinetyNine;",
"            foreach(var w in oneToNineWords) total +=  (w.Length + \"hundred\".Length) * 100 + \"and\".Length * 99 + oneToNinetyNine;",
"",
"            return (total + \"onethousand\".Length).ToString();",
"        }",
            },
            new List<string>{

            },
            new List<string>{
            },
        };

        public Problem17Solver() : base()
        {
            Problem.Id = 17;
            Problem.UpperBound = 1000;
            Problem.Title = "Number letter counts";
            Problem.Description = @"
If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of 'and' when writing out numbers is in compliance with British usage.
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 99999,
                Description = "Count letters with fingers",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 17,
            //     Description = "",
            //     Version = 2,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
            // });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 17,
            //     Description = "Rever the number, save number 1234 in a list<int> {4, 3, 2, 1}. When perform carry, use List.Add instead of List.Insert.  Turned out that List.add costs same amount of time as List.Insert.",
            //     Version = 3,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[2])
            // });
        }
        
        public override string solution1()
        {
            string [] oneToNineWords = 
                new string []{"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            string [] tenToNineTeenWords = 
                new string []{"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
            string[] twentyToNinetyWords = 
                new string []{"twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};


            int oneToNine = 0;
            foreach(var w in oneToNineWords) oneToNine +=  w.Length;


            int tenToNineteen = 0;
            foreach(var w in tenToNineTeenWords) tenToNineteen +=  w.Length;
            Console.WriteLine($"tenToNineteen = {tenToNineteen}");
            
            int twentyToNinetyNine = 0;
            foreach (var w in twentyToNinetyWords) twentyToNinetyNine += w.Length * 10 + oneToNine;

            int oneToNinetyNine = oneToNine + tenToNineteen + twentyToNinetyNine;
            int total = oneToNinetyNine;
            foreach(var w in oneToNineWords) total +=  (w.Length + "hundred".Length) * 100 + "and".Length * 99 + oneToNinetyNine;

            return (total + "onethousand".Length).ToString();
        }
    }
}