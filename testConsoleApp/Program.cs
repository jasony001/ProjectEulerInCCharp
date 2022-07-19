using System.Diagnostics;
using System;
using System.Collections.Generic;
using ProjectEulerLib.MoreMath;

namespace testConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            long n = Convert.ToInt64(Console.ReadLine());

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            FactorCalculator worker = new FactorCalculator();
            List<long> factors = worker.GetFactors(n);

            stopWatch.Stop();

            foreach(long f in factors) Console.Write($"{f} ");
            Console.WriteLine();
            Console.WriteLine(((int)(stopWatch.ElapsedMilliseconds)).ToString() + " milliseconds");
        }
    }
}
