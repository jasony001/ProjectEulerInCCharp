using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using ProjectEulerLib.MoreMath;

namespace testConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0].ToLower() == "-d")
            {
                Console.WriteLine("Press enter to start:");
                Console.ReadLine();
            }

            char [][] xorResult = new char [129][];
            for(int i = 0; i < 128; i ++) 
            {
                xorResult[i] = new char[26];
                for(int j = 0; j < 26; j ++)
                {
                    xorResult[i][j] = (char)(i ^ (int)('a' + j));
                }
            }

            for(int i = 0; i < 128; i ++)
            {
                Console.Write(i.ToString() + ": ");
                for(int j = 0; j < 26; j ++)
                {
                    Console.Write(xorResult[i][j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
