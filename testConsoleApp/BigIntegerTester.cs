using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using ProjectEulerLib.MoreMath;

namespace testConsoleApp
{
    class BigIntegerTester
    {
        const int REPEAT = 1000;

        public static void TestConstructorLongParam()
        {
            foreach (long n in new List<long> { 0, 12, -345 })
            {
                BigInteger a = new BigInteger(n);
                Console.WriteLine(PerformTest(a.ToString() == n.ToString(), $"Test constructor (long) test 1: new BigInteger({n}).ToString() = \"{n.ToString()}\""));
            }
        }

        public static void TestConstructorBigIntegerParam()
        {
            foreach (long n in new List<long> { 0, 12, -345 })
            {
                BigInteger a = new BigInteger(n);
                BigInteger b = new BigInteger(a);
                Console.WriteLine(PerformTest(b.ToString() == n.ToString(), $"Test constructor (BigInteger) test 2: new BigInteger(New BigInteger({n})).ToString() = \"{n.ToString()}\""));
            }
        }

        public static void TestConstructorValidNumberString()
        {
            foreach (string s in new List<string> { "0", "12", "-345" })
            {
                BigInteger a = new BigInteger(s);
                Console.WriteLine(PerformTest(a.ToString() == s, $"Test constructor (string) test 3: new BigInteger(\"{s}\").ToString() = \"{s}\""));
            }
        }

        public static void TestConstructorNotANumberString()
        {
            foreach (string s in new List<string> { "--10", "12.345" })
            {
                try
                {
                    BigInteger a = new BigInteger(s);
                }
                catch (System.Exception ex)
                {
                    string expectedMsg = "string contains non-numeric character";
                    Console.WriteLine(PerformTest(ex.Message == expectedMsg, $"Test constructor (string) test 4: new BigInteger({s}).ToString() throws exception \"{ex.Message}\""));
                }
            }
        }

        static void TestToLongHappyPath()
        {
            foreach (long n in new List<long> { -23, 0, 987987987 })
            {
                BigInteger b = new BigInteger(n);
                Console.WriteLine(PerformTest(b.ToLong() == n, $"Test ToLong() test 1: new BigInteger({n}).ToString() = {n}"));
            }
        }

        public static void TestToLongException()
        {
            foreach (long n in new List<long> { long.MinValue, long.MaxValue })
            {
                BigInteger b = new BigInteger(n);

                try
                {
                    long m = b.ToLong();
                    Console.WriteLine(PerformTest(false, "Test ToLong() excepetion case - Integer is too big for long data type"));
                }
                catch (System.Exception ex)
                {
                    string expectedMsg = "Cannot be converted to long. Exceeded max value of long.";
                    Console.WriteLine(PerformTest(ex.Message == expectedMsg, $"Test ToLong() excepetion case - Integer is too big for long data type throws exception \"{ex.Message}\""));
                }
            }
        }

        static void TestCompareTo_AnotherBigInteger()
        {
            foreach (long m in new List<long> { long.MinValue, -254, 0, 23, long.MaxValue })
            {
                foreach (long n in new List<long> { long.MinValue, -2354, 0, 293, long.MaxValue })
                {
                    BigInteger a = new BigInteger(m);
                    BigInteger b = new BigInteger(n);
                    int result = m == n ? 0 : (m > n ? 1 : -1);

                    Console.WriteLine(PerformTest(a.CompareTo(b) == result, $"BigInteger({m}).CompareTo(BigInteger({n})) = {result}"));
                }
            }
        }

        static void TestCompareTo_Long()
        {
            foreach (long m in new List<long> { long.MinValue, -254, 0, 23, long.MaxValue })
            {
                foreach (long n in new List<long> { long.MinValue, -2354, 0, 293, long.MaxValue })
                {
                    BigInteger a = new BigInteger(m);
                    int result = m == n ? 0 : (m > n ? 1 : -1);

                    Console.WriteLine(PerformTest(a.CompareTo(n) == result, $"BigInteger({m}).CompareTo({n}) = {result}"));
                }
            }
        }

        private static void TestCompareOperators()
        {
            foreach (long m in new List<long> { long.MinValue, -254, -2016, -387, 0, 23, 387, long.MaxValue })
            {
                foreach (long n in new List<long> { long.MinValue, -2354, -2016, -387, 0, 293, 387, 2016, long.MaxValue })
                {
                    // >, <, >=, <=, ==, !=

                    BigInteger a = new BigInteger(m);
                    BigInteger b = new BigInteger(n);

                    bool mGreaterThanN = (m > n);
                    bool mLessThanN = (m < n);
                    bool mGreaterThanOrEqualToN = (m >= n);
                    bool mLessThanOrEqualToN = (m <= n);
                    bool mEqualToN = (m == n);
                    bool mNotEqualToN = (m != n);

                    Console.WriteLine(PerformTest((a > b) == mGreaterThanN, $"Test BigInteger({m}) > BigInteger({n}). Expected: {mGreaterThanN}"));
                    Console.WriteLine(PerformTest((a > n) == mGreaterThanN, $"Test BigInteger({m}) > long({n}). Expected: {mGreaterThanN}"));
                    Console.WriteLine(PerformTest((m > b) == mGreaterThanN, $"Test long({m}) > BigInteger({n}). Expected: {mGreaterThanN}"));
                    Console.WriteLine();

                    Console.WriteLine(PerformTest((a < b) == mLessThanN, $"Test BigInteger({m}) < BigInteger({n}). Expected: {mLessThanN}"));
                    Console.WriteLine(PerformTest((a < n) == mLessThanN, $"Test BigInteger({m}) < long({n}). Expected: {mLessThanN}"));
                    Console.WriteLine(PerformTest((m < b) == mLessThanN, $"Test long({m}) < BigInteger({n}). Expected: {mLessThanN}"));
                    Console.WriteLine();

                    Console.WriteLine(PerformTest((a >= b) == mGreaterThanOrEqualToN, $"Test BigInteger({m}) >= BigInteger({n}). Expected: {mGreaterThanOrEqualToN}"));
                    Console.WriteLine(PerformTest((a >= n) == mGreaterThanOrEqualToN, $"Test BigInteger({m}) >= long({n}). Expected: {mGreaterThanOrEqualToN}"));
                    Console.WriteLine(PerformTest((m >= b) == mGreaterThanOrEqualToN, $"Test long({m}) >= BigInteger({n}). Expected: {mGreaterThanOrEqualToN}"));
                    Console.WriteLine();

                    Console.WriteLine(PerformTest((a <= b) == mLessThanOrEqualToN, $"Test BigInteger({m}) <= BigInteger({n}). Expected: {mLessThanOrEqualToN}"));
                    Console.WriteLine(PerformTest((a <= n) == mLessThanOrEqualToN, $"Test BigInteger({m}) <= long({n}). Expected: {mLessThanOrEqualToN}"));
                    Console.WriteLine(PerformTest((m <= b) == mLessThanOrEqualToN, $"Test long({m}) <= BigInteger({n}). Expected: {mLessThanOrEqualToN}"));
                    Console.WriteLine();

                    Console.WriteLine(PerformTest((a == b) == mEqualToN, $"Test BigInteger({m}) == BigInteger({n}). Expected: {mEqualToN}"));
                    Console.WriteLine(PerformTest((a == n) == mEqualToN, $"Test BigInteger({m}) == long({n}). Expected: {mEqualToN}"));
                    Console.WriteLine(PerformTest((m == b) == mEqualToN, $"Test long({m}) == BigInteger({n}). Expected: {mEqualToN}"));
                    Console.WriteLine();

                    Console.WriteLine(PerformTest((a != b) == mNotEqualToN, $"Test BigInteger({m}) != BigInteger({n}). Expected: {mNotEqualToN}"));
                    Console.WriteLine(PerformTest((a != n) == mNotEqualToN, $"Test BigInteger({m}) != long({n}). Expected: {mNotEqualToN}"));
                    Console.WriteLine(PerformTest((m != b) == mNotEqualToN, $"Test long({m}) != BigInteger({n}). Expected: {mNotEqualToN}"));
                    Console.WriteLine();
                }
            }
        }

        private static void TestMinMax()
        {
            foreach (long m in new List<long> { long.MinValue, -254, -2016, -387, 0, 23, 387, long.MaxValue })
            {
                foreach (long n in new List<long> { long.MinValue, -2354, -2016, -387, 0, 293, 387, 2016, long.MaxValue })
                {
                    // Max, Min
                    BigInteger a = new BigInteger(m);
                    BigInteger b = new BigInteger(n);

                    var expectedMaxResult = m > n ? m : n;
                    var maxResult = BigInteger.Max(a, b);
                    Console.WriteLine(PerformTest(
                        (maxResult is BigInteger) && (expectedMaxResult == maxResult), 
                        $"Test BigInteger.Max(BigInteger({m}), BigInteger({n})). Expected: {expectedMaxResult}"));

                    maxResult = BigInteger.Max(a, n);
                    Console.WriteLine(PerformTest(
                        (maxResult is BigInteger) && (expectedMaxResult == maxResult), 
                        $"Test BigInteger.Max(BigInteger({m}), {n}). Expected: {expectedMaxResult}"));

                    maxResult = BigInteger.Max(m, b);
                    Console.WriteLine(PerformTest(
                        (maxResult is BigInteger) && (expectedMaxResult == maxResult), 
                        $"Test BigInteger.Max({m}, BigInteger({n})). Expected: {expectedMaxResult}"));

                    var expectedMinResult = m < n ? m : n;
                    var minResult = BigInteger.Min(a, b);
                    Console.WriteLine(PerformTest(
                        (minResult is BigInteger) && (expectedMinResult == minResult), 
                        $"Test BigInteger.Min(BigInteger({m}), BigInteger({n})). Expected: {expectedMinResult}"));

                    minResult = BigInteger.Min(a, n);
                    Console.WriteLine(PerformTest(
                        (minResult is BigInteger) && (expectedMinResult == minResult), 
                        $"Test BigInteger.Min(BigInteger({m}), {n}). Expected: {expectedMinResult}"));

                    minResult = BigInteger.Min(m, b);
                    Console.WriteLine(PerformTest(
                        (minResult is BigInteger) && (expectedMinResult == minResult), 
                        $"Test BigInteger.Min({m}, BigInteger({n})). Expected: {expectedMinResult}"));



                    Console.WriteLine();
                }
            }
        }

        static void TestAddOperator()
        {
            foreach (long m in new List<long> { long.MinValue, -254, -2016, -387, 0, 23, 387, long.MaxValue })
            {
                foreach (long n in new List<long> { long.MinValue, -2354, -2016, -387, 0, 293, 387, 2016, long.MaxValue })
                {
                    BigInteger expectedResult = new BigInteger(m) + new BigInteger(n);
                    
                    Console.WriteLine(PerformTest(() => (new BigInteger(m) + new BigInteger(n)) == expectedResult, $"testing BigInteger({m}) + BigInteger({n}). Exprected result: {expectedResult}", REPEAT));
                    Console.WriteLine(PerformTest(() => (m + new BigInteger(n)) == expectedResult, $"testing long({m}) + BigInteger({n}). Exprected result: {expectedResult}", REPEAT));
                    Console.WriteLine(PerformTest(() => (new BigInteger(m) + n) == expectedResult, $"testing BigInteger({m}) + long({n}). Exprected result: {expectedResult}", REPEAT));
                }
            }
        }

        static void TestSubstractOperator()
        {
            foreach (long m in new List<long> { long.MinValue, -254, -2016, -387, 0, 23, 387, long.MaxValue })
            {
                foreach (long n in new List<long> { long.MinValue, -2354, -2016, -387, 0, 293, 387, 2016, long.MaxValue })
                {
                    BigInteger expectedResult = new BigInteger(m) - new BigInteger(n);
                    
                    Console.WriteLine(PerformTest(() => (new BigInteger(m) - new BigInteger(n)) == expectedResult, $"testing BigInteger({m}) + BigInteger({n}). Exprected result: {expectedResult}", REPEAT));
                    Console.WriteLine(PerformTest(() => (m - new BigInteger(n)) == expectedResult, $"testing long({m}) + BigInteger({n}). Exprected result: {expectedResult}", REPEAT));
                    Console.WriteLine(PerformTest(() => (new BigInteger(m) - n) == expectedResult, $"testing BigInteger({m}) + long({n}). Exprected result: {expectedResult}", REPEAT));
                }
            }
        }

        static void TestMultiplyOperator()
        {
            foreach (long m in new List<long> { long.MinValue, -254, -2016, -387, 0, 23, 387, long.MaxValue })
            {
                foreach (long n in new List<long> { long.MinValue, -2354, -2016, -387, 0, 293, 387, 2016, long.MaxValue })
                {
                    BigInteger expectedResult = new BigInteger(m) * new BigInteger(n);
                    
                    Console.WriteLine(PerformTest(() => (new BigInteger(m) * new BigInteger(n)) == expectedResult, $"testing BigInteger({m}) * BigInteger({n}). Exprected result: {expectedResult}", REPEAT));
                    Console.WriteLine(PerformTest(() => (m * new BigInteger(n)) == expectedResult, $"testing long({m}) * BigInteger({n}). Exprected result: {expectedResult}", REPEAT));
                    Console.WriteLine(PerformTest(() => (new BigInteger(m) * n) == expectedResult, $"testing BigInteger({m}) * long({n}). Exprected result: {expectedResult}", REPEAT));
                }
            }
        }        

        static void TestDevideOperator()
        {
            foreach (long m in new List<long> { long.MinValue, -254, -2016, -387, 0, 23, 387, long.MaxValue })
            {
                foreach (long n in new List<long> { -2354, -2016, -387, 293, 387, 2016 })
                {
                    long expectedResult = m / n;
                    
                    Console.WriteLine(PerformTest(() => (new BigInteger(m) / n) == expectedResult, $"testing BigInteger({m}) / long({n}). Exprected result: {expectedResult}", REPEAT));
                }
            }
        }        

        static void TestModOperator()
        {
            foreach (long m in new List<long> { long.MinValue, -254, -2016, -387, 0, 23, 387, long.MaxValue })
            {
                foreach (long n in new List<long> { -2354, -2016, -387, 293, 387, 2016 })
                {
                    long expectedResult = m % n;
                    
                    Console.WriteLine(PerformTest(() => (new BigInteger(m) % n) == expectedResult, $"testing BigInteger({m}) % long({n}). Exprected result: {expectedResult}", REPEAT));
                }
            }
        }        

        static void TestPowerOperator()
        {
            foreach (long m in new List<long> { 2, 3, 756 })
            {
                foreach (long n in new List<long> { 2, 5, 50 })
                {
                    BigInteger expectedResult = new BigInteger(m) ^ n;
                    
                    Console.WriteLine(PerformTest(() => (new BigInteger(m) ^ n) == expectedResult, $"testing BigInteger({m}) ^ long({n}). Exprected result: {expectedResult}", REPEAT));
                }
            }
        }
        
        public static void ExecuteTests()
        {


            

            // TestConstructorLongParam(); Console.WriteLine();
            // TestConstructorBigIntegerParam(); Console.WriteLine();
            // TestConstructorValidNumberString(); Console.WriteLine();
            // TestConstructorNotANumberString(); Console.WriteLine();

            // TestToLongHappyPath(); Console.WriteLine();
            // TestToLongException(); Console.WriteLine();

            // TestCompareTo_AnotherBigInteger(); Console.WriteLine();
            // TestCompareTo_Long(); Console.WriteLine();

            // TestCompareOperators(); Console.WriteLine();

            // TestMinMax();


            // Console.WriteLine(BigInteger.AddTwoPositiveNumbers(new BigInteger(245), new BigInteger(98)));
            // Console.WriteLine(BigInteger.AddTwoPositiveNumbers(new BigInteger(98), long.MaxValue));

            // BigInteger a = BigInteger.SubstractSmallNumberFromBigNumber(new BigInteger(long.MaxValue), 98);

            // Console.WriteLine(BigInteger.SubstractSmallNumberFromBigNumber(long.MaxValue, a));
            // Console.WriteLine(long.MaxValue);

            // TestAddOperator();
            // TestSubstractOperator();
            // TestMultiplyOperator();
            // TestPowerOperator();
            // TestDevideOperator();
            TestModOperator();

            // long mod = new BigInteger(387) % 2016;
            // Console.WriteLine(mod);


            // Console.WriteLine($"51 % 7 = {51 % 7}");
            // Console.WriteLine($"51 % -7 = {51 % -7}");
            // Console.WriteLine($"-51 % 7 = {-51 % 7}");
            // Console.WriteLine($"-51 % -7 = {-51 % -7}");

            
            Console.WriteLine("Complete");
        }


        private static string PerformTest(bool testCondition, string description, string passedMsg = "passed", string failedMsg = "failed")
        {
            string result = testCondition ? passedMsg : failedMsg;
            return $"{result}: {description}";
        }

        private static string PerformTest(Expression<Func<bool>> predict, string description, int repeat = 1, string passedMsg = "passed", string failedMsg = "failed")
        {
            Func<bool> compiledExpression = predict.Compile();  
            
            // Execute the lambda expression.  
            bool testResult = compiledExpression();  

            Stopwatch w = new Stopwatch();
            w.Start();

            for(int i = 0; i < repeat; i++)
            {
                testResult = compiledExpression();  
            }

            w.Stop();

            string result = testResult ? passedMsg : failedMsg;
            long milSec = w.ElapsedMilliseconds;
            string timing = "";
            if (repeat > 1) timing = $" (repeated {repeat} times in {milSec} milliseconds)";
            return $"{result}{timing}: {description}";
        }
    }
}
