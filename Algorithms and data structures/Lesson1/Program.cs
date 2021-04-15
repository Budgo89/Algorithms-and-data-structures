using System;

namespace Lesson1
{
    class Program
    {
        public class TestCase
        {
            public int X { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        public class TestCaseFib
        {
            public uint X { get; set; }
            public uint Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static void TestAlgorithms(TestCase testCase)
        {
            try
            {
                var actual = Algorithms(testCase.X);
                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }

            }
            catch (Exception e)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }
        static void TestFib(TestCaseFib testCaseFib)
        {
            try
            {
                var actualFib = Fib(testCaseFib.X);
                var actualFibRec = FibRec(testCaseFib.X);
                if (actualFib == testCaseFib.Expected)
                {
                    Console.WriteLine("VALID TEST Fib");
                }
                else
                {
                    Console.WriteLine("INVALID TEST Fib");
                }
                if (actualFibRec == testCaseFib.Expected)
                {
                    Console.WriteLine("VALID TEST Fib");
                }
                else
                {
                    Console.WriteLine("INVALID TEST Fib");
                }

            }
            catch (Exception e)
            {
                if (testCaseFib.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }
        static bool Algorithms(int n)
        {
            int d = 0; // O(1)
            int i = 2; // O(1)
            while (i < n) //O(N)
            {
                if (n % i == 0) // O(1)
                    d++;
                i++;
            }

            if (d == 0) // O(1)
                return true;
            return false;
            // Общая сложность O(N)
        }

        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1)
            for (int i = 0; i < inputArray.Length; i++) //O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) //O(N)
                    {
                        int y = 0; // O(1)

                        if (j != 0) // O(1)
                        {
                            y = k / j;
                        }
                        sum += inputArray[i] + i + k + j + y; // O(1)
                    }
                }
                /* 1 + N*N*3N = 1+3N^3 = Сокращаем константы = N^3  */
            }

            return sum; // O(1)
        }

        static uint Fib(uint n)
        {
            uint a0 = 0;
            uint a1 = 1;
            if (n == 0)
                return a0;
            uint a = a1;
            for (int i = 2; i <= n; i++)
            {
                a = a0 + a1;
                a0 = a1;
                a1 = a;
            }
            return a1;
        }
        static uint FibRec(uint n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return FibRec(n - 1) + FibRec(n - 2);
        }



        static void Main(string[] args)
        {
            #region task 1
            // if (Algorithms(6) == true)
            //     Console.WriteLine("Простое");
            // else Console.WriteLine("Не простое");
            var testCase1 = new TestCase()
            {
                X = 5,
                Expected = true,
                ExpectedException = null
            };
            var testCase2 = new TestCase()
            {
                X = -5,
                Expected = true,
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                X = 10,
                Expected = false,
                ExpectedException = null
            };
            var testCase4 = new TestCase()
            {
                X = 4,
                Expected = true,
                ExpectedException = null
            };
            var testCase5 = new TestCase()
            {
                X = 6,
                Expected = true,
                ExpectedException = null
            };
            TestAlgorithms(testCase1);
            TestAlgorithms(testCase2);
            TestAlgorithms(testCase3);
            TestAlgorithms(testCase4);
            TestAlgorithms(testCase5);
            #endregion
            #region task 2
            /* 1 + N*N*3N = 1+3N^3 = Сокращаем константы = N^3 
             */

            #endregion
            #region task 3

            // uint n = 7;
            // Console.WriteLine(Fib(n));
            // Console.WriteLine(FibRec(n));
            Console.WriteLine("Фибоначчи");
            var TestCaseFib1 = new TestCaseFib()
            {
                X = 0,
                Expected = 0,
                ExpectedException = null,
            };
            var TestCaseFib2 = new TestCaseFib()
            {
                X = 15,
                Expected = 610,
                ExpectedException = null,
            };
            var TestCaseFib3 = new TestCaseFib()
            {
                X = 7,
                Expected = 13,
                ExpectedException = null,
            };
            var TestCaseFib4 = new TestCaseFib()
            {
                X = 10,
                Expected = 56,
                ExpectedException = null,
            };
            TestFib(TestCaseFib1);
            TestFib(TestCaseFib2);
            TestFib(TestCaseFib3);
            TestFib(TestCaseFib4);
            #endregion
        }


    }
}

