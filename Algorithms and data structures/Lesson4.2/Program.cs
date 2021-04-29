using System;

namespace Lesson4._2
{



    class Program
    {
        public class TestCase
        {            
            public TestWood treeNode { get; set; }
            public int X { get; set; }
            public int[] searchValue { get; set; }
            public int searchValueInt { get; set; }
            public Exception ExpectedException { get; set; }
        }
        static bool MassTect(NodeInfo[] a, int[] b)
        {
            bool flag = false;
            if (a.Length == b.Length)
            {
                for (int i = 0; i < b.Length; i++)
                {
                    if (a[i].Node.Value == b[i])
                    {
                        flag = true;
                    }
                    else return false;
                }
                return flag;
            }
            else return false;
        }
        static void TestAddItem(TestCase testCase)
        {
            try
            {
                testCase.treeNode.AddItem(testCase.X);
                var a = testCase.treeNode.GetTreeInLine(testCase.treeNode);
                var b = MassTect(a, testCase.searchValue);
                TestResult(b);
            }
            catch (Exception)
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
        static void TestRemoveItem(TestCase testCase)
        {
            try
            {
                testCase.treeNode.RemoveItem(testCase.X);
                var a = testCase.treeNode.GetTreeInLine(testCase.treeNode);
                var b = MassTect(a, testCase.searchValue);
                TestResult(b);

            }
            catch (Exception)
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
        static void TestResult(bool b)
        {
            if (b == true)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
        static void TestBFS(TestCase testCase)
        {
            try
            {
                
                if (testCase.treeNode.BFS(testCase.X).Value == testCase.searchValueInt)
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
        static void TestDFS(TestCase testCase)
        {
            try
            {

                if (testCase.treeNode.DFS(testCase.X).Value == testCase.searchValueInt)
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

        static void Main(string[] args)
        {
            var wood = new TestWood();
            int[] intArray1 = new int[] { 6 };
            var testCase1 = new TestCase()
            {
                treeNode = wood,
                X = 6,
                searchValue = intArray1,
                ExpectedException = null
            };
            TestAddItem(testCase1);
            int[] intArray2 = new int[] { 6, 2 };
            var testCase2 = new TestCase()
            {
                treeNode = wood,
                X = 2,
                searchValue = intArray2,
                ExpectedException = null
            };
            TestAddItem(testCase2);
            int[] intArray3 = new int[] { 6, 2, 11 };
            var testCase3 = new TestCase()
            {
                treeNode = wood,
                X = 11,
                searchValue = intArray3,
                ExpectedException = null
            };
            TestAddItem(testCase3);
            int[] intArray4 = new int[] { 6, 2, 11,3 };
            var testCase4 = new TestCase()
            {
                treeNode = wood,
                X = 3,
                searchValue = intArray4,
                ExpectedException = null
            };
            TestAddItem(testCase4);
            int[] intArray5 = new int[] { 6, 2, 11, 3,9 };
            var testCase5 = new TestCase()
            {
                treeNode = wood,
                X = 9,
                searchValue = intArray5,
                ExpectedException = null
            };
            TestAddItem(testCase5);
            int[] intArray6 = new int[] { 6, 2, 11, 3, 9,30 };
            var testCase6 = new TestCase()
            {
                treeNode = wood,
                X = 30,
                searchValue = intArray6,
                ExpectedException = null
            };
            TestAddItem(testCase6);
            wood.PrintTree();
            //int[] intArray7 = new int[] { 6, 3, 11, 9, 30 };
            //var testCase7 = new TestCase()
            //{
            //    treeNode = wood,
            //    X = 2,
            //    searchValue = intArray7,
            //    ExpectedException = null
            //};
            //Console.WriteLine();
            //TestRemoveItem(testCase7);
            //int[] intArray8 = new int[] { 6, 3, 30, 9 };
            //var testCase8 = new TestCase()
            //{
            //    treeNode = wood,
            //    X = 11,
            //    searchValue = intArray8,
            //    ExpectedException = null
            //};
            //TestRemoveItem(testCase8);
            Console.WriteLine();

            var tesrCase9 = new TestCase()
            {
                treeNode = wood,
                X = 30,
                searchValueInt = 30,
                ExpectedException = null
            };
            TestBFS(tesrCase9);
            var tesrCase10 = new TestCase()
            {
                treeNode = wood,
                X = 3,
                searchValueInt = 3,
                ExpectedException = null
            };
            TestDFS(tesrCase10);
            var tesrCase11 = new TestCase()
            {
                treeNode = wood,
                X = 31,
                searchValueInt = 31,
                ExpectedException = null
            };
            TestDFS(tesrCase11);
        }
    }
   
}
