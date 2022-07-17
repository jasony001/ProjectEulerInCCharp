using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem22Solver : ProblemSolver
    {

        List<List<string>> sourceCodeLinesList = new List<List<string>>{
            new List<string> {

            },
            new List<string>{

            }
        };

        public Problem22Solver() : base()
        {
            Problem.Id = 22;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "";
            Problem.Description = "";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 22,
                Description = "Binary tree. Remember to remove the quote in name string.",
                Version = 1,
                SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[0])
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "Flatten the grid, build rowLists, columnLists, ForwardDiagonalLists, backDiagonalLists. Then loop to find the max product of 4.",
            //     Version = 2,
            //     SolutionCodes = ConvertStringListToSolutionCodeList(sourceCodeLinesList[1])
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
            if (name == "COLIN")
            {
                int x = 0;
            }
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
