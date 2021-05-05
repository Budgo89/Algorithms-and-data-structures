using System;

namespace Lesson_7
{
    class Program
    {
        public class TestCase
        {            
            public int[,] X { get; set; }
            public int M { get; set; }
            public int N { get; set; }
            public int searchValue { get; set; }
            public Exception ExpectedException { get; set; }
        }
        static void Test(TestCase testCase)
        {
            try
            {
                var a = Routes(testCase.M, testCase.N, testCase.X);
                if (a == testCase.searchValue)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }


        static int Routes (int a, int b, int[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                if (a == x[i, 0] && b == x[i, 1]) return 0;
            }
            
            if (a == 1 && b == 1) return 1;    
            if (a == 1) return Routes(a, b - 1, x);
            if (b == 1) return Routes(a - 1, b, x);
            return Routes(a - 1, b, x) + Routes(a, b - 1, x);
        }
        static int Routes1(int a, int b)
        {
            if (a == 1 || b == 1) return 1;
            return Routes1(a - 1, b) + Routes1(a, b - 1);
        }

        static void Main(string[] args)
        {
            var mas1 = new int[,] { } ;
            var test1 = new TestCase
            {
                X = mas1,
                M = 2,
                N = 2,
                searchValue = 2,
                ExpectedException = null,
            };
            Test(test1);
            var test2 = new TestCase
            {
                X = mas1,
                M = 3,
                N = 3,
                searchValue = 6,
                ExpectedException = null,
            };
            Test(test2);
            var mas2 = new int[,] { { 2, 2 }, { 2, 3 } };
            var test3 = new TestCase
            {
                X = mas2,
                M = 3,
                N = 3,
                searchValue = 1,
                ExpectedException = null,
            };
            Test(test3);
            var mas4 = new int[,] { { 2,1}, { 2, 2 }, { 2, 3 } };
            var test4 = new TestCase
            {
                X = mas4,
                M = 3,
                N = 3,
                searchValue = 0,
                ExpectedException = null,
            };
            Test(test4);
            var mas5 = new int[1,1];
            mas5 = null;
            var test5 = new TestCase
            {
                X = mas5,
                M = 3,
                N = 3,
                searchValue = 6,
                ExpectedException = null,
            };
            Test(test5);
        }
    }
}
