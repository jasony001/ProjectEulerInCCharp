using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem22Solver : ProblemSolver
    {


        public Problem22Solver() : base()
        {
            Problem.Id = 22;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Names scores";
            Problem.Description = 
@"Using names.txt (ProjectEulerWebAPI/p022_names.txt), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

What is the total of all the name scores in the file?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 22,
                Description = "Binary tree, traverse recursively. Remember to remove the quote in name string.",
                Version = 1,
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "Flatten the grid, build rowLists, columnLists, ForwardDiagonalLists, backDiagonalLists. Then loop to find the max product of 4.",
            //     Version = 2,
            // });
        }

        public override string solution1()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader("p022_names.txt");
            string s = sr.ReadToEnd();
            sr.Close();
            string [] names = s.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);

            TreeNode root = new TreeNode{
                Value = names[0].Replace("\"", ""),
                LeftLeaf = null,
                RightLeaf = null
            };

            for(int i = 1; i < names.Length; i ++)
            {
                root.AddNode(names[i].Replace("\"", ""));
            }

            List<string> sortedNameList = root.Traverse();
            long sum = 0;
            for(int i = 0; i < sortedNameList.Count; i ++)
            {
                sum += GetNameValue(sortedNameList[i]) * (i+1);
            }

            return sum.ToString();
        }

        private int GetNameValue(string name)
        {
            int sum = 0;
            foreach(char c in name.ToLower())
            {
                sum += (c - 'a' + 1);
            }

            return sum;
        }

        public override string solution2()
        {
            return "";
        }
    }

    public class TreeNode
    {
        public string Value{get;set;}

        public TreeNode LeftLeaf {get;set;}

        public TreeNode RightLeaf{get;set;}

        public void AddNode(string newValue)
        {
            TreeNode currentNode = this;
            int compareResult = newValue.CompareTo(currentNode.Value);

            while(compareResult < 0 && currentNode.LeftLeaf != null
                || compareResult >= 0 && currentNode.RightLeaf != null)
            {
                currentNode = compareResult < 0 ? currentNode.LeftLeaf : currentNode.RightLeaf;
                compareResult = newValue.CompareTo(currentNode.Value);
            }

            if (compareResult < 0 && currentNode.LeftLeaf == null)
            {
                currentNode.LeftLeaf = new TreeNode {Value = newValue, LeftLeaf = null, RightLeaf = null};
            }
            else
            {
                currentNode.RightLeaf = new TreeNode {Value = newValue, LeftLeaf = null, RightLeaf = null};
            }
        }
    
        public List<string> Traverse()
        {
            List<string> leftTreeValueList = LeftLeaf == null ? new List<string>() : LeftLeaf.Traverse();
            List<string> rightTreeValueList = RightLeaf == null ? new List<string>() : RightLeaf.Traverse();

            List<string> list = new List<string>();
            list.AddRange(leftTreeValueList);
            list.Add(Value);
            list.AddRange(rightTreeValueList);

            return list;
        }
    }
}
