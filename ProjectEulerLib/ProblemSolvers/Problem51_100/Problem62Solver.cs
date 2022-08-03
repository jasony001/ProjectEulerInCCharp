using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem62Solver : ProblemSolver
    {
        public Problem62Solver() : base()
        {
            Problem.Id = 62;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Cubic permutations";
            Problem.Description = 
@"The cube, 41063625 (345^3), can be permuted to produce two other cubes: 56623104 (3843) and 66430125 (4053). In fact, 41063625 is the smallest cube which has exactly three permutations of its digits which are also cube.

Find the smallest cube for which exactly five permutations of its digits are cube.";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 62,
                Description = 
@"
Dictionary<string, int[]>
each kv: key is a cube tostring, sort by characters, int[0] is count of cubes, int[1] is the first such cube
starting with n = 1, increase by one in each iteration, populate the dictionary
every time the digits of the cube changes, clear the dictionary
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
            bool solved = false;
            long n = 1;
            int digits  = 1;
            Dictionary<string, long[]> dict = new Dictionary<string, long[]>();

            while (!solved)
            {
                long cube = n * n * n;
                int newDigits = 0;
                long c = cube;
                while(c > 0)
                {
                    c /= 10;
                    newDigits ++;
                }
                if (newDigits > digits)
                {
                    dict.Clear();
                    digits = newDigits;
                }
                string key = new string(cube.ToString().ToCharArray().OrderBy(c => c).ToArray());
                if (!dict.ContainsKey(key))
                    dict.Add(key, new long []{1, cube});
                else
                    dict[key][0] = dict[key][0] + 1;
                
                if (dict.Any(kv => kv.Value[0] == 5))
                {
                    KeyValuePair<string, long[]> answer = dict.FirstOrDefault(kv => kv.Value[0] == 5);
                    return answer.Value[1].ToString();
                }

                n ++;
            }
            
            return "working on it";
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
