using System.Diagnostics;
using System;
using System.Collections.Generic;
using ProjectEulerLib;

namespace testConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            System.IO.StreamReader sr = new System.IO.StreamReader("p022_names.txt");
            string s = sr.ReadToEnd();
            sr.Close();
            string [] names = s.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
            int longest = 0;
            foreach(string name in names) longest = Math.Max(name.Length, longest);
            Console.WriteLine($"{names.Length + 1} names. Longest name has {longest} characters");

            stopWatch.Stop();

            Console.WriteLine(((int)(stopWatch.ElapsedMilliseconds)).ToString() + " milliseconds");
        }
    }
}
