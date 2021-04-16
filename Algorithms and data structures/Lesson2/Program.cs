using System;

namespace Lesson2
{
    class Program
    {
        public class TestCase
        {
            public int[] X { get; set; }
            public int searchValue { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static void TestBinarySearch(TestCase testCase)
        {
            try
            {
                var actual = BinarySearch(testCase.X, testCase.searchValue);
                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception )
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

        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0; //O(1)
            int max = inputArray.Length - 1;//O(1)
            while (min <= max) //O(N)
            {
                int mid = (min + max) / 2; //O(1)
                if (searchValue == inputArray[mid])//O(1)
                {
                    return inputArray[mid];
                }
                else if (searchValue < inputArray[mid])//O(1)
                {
                    max = mid - 1;
                }
                else//O(1)
                {
                    min = mid + 1;
                }
            }
            return -1;//O(1)
            // 2 + N + 5 = N
            //Асимптотическая сложность O(N)
        }

        static void Main(string[] args)
        {
            //LinkedList ds = new LinkedList();

            //ds.AddNode(10);
            //ds.AddNode(55);
            //ds.AddNode(68);
            //ds.AddNode(75);
            //ds.print();
            //var a = ds.FindNode(55);

            //ds.AddNodeAfter(a, 11);
            //Console.WriteLine();
            //ds.print();
            //a = ds.FindNode(11);
            //Console.WriteLine();
            //Console.WriteLine(a.Value);
            //Console.WriteLine();
            //Console.WriteLine(ds.GetCount());
            //Console.WriteLine();          

            //ds.RemoveNode(0);
            //Console.WriteLine();
            //ds.print();

            //a = ds.FindNode(68);
            //ds.RemoveNode(a);
            //Console.WriteLine();
            //ds.print();
            //ds.RemoveNode(3);
            //Console.WriteLine();
            //ds.print();

            int[] intArray = new int[] { 1, 6, 77, 123, 444, 555, 660 };
            var testCase1 = new TestCase()
            {
                X = intArray, searchValue = 6, Expected = 6, ExpectedException = null
            };
            var testCase2 = new TestCase()
            {
                X = intArray,
                searchValue = 6,
                Expected = 2,
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                X = intArray,
                searchValue = 555,
                Expected = 555,
                ExpectedException = null
            };

            TestBinarySearch(testCase1);
            TestBinarySearch(testCase2);
            TestBinarySearch(testCase3);

            int[] intArray1 = new int[] { 1, 6, 77, 123, 444, 555 };
            var testCase4 = new TestCase()
            {
                X = intArray1,
                searchValue = 555,
                Expected = 555,
                ExpectedException = null
            };
            TestBinarySearch(testCase4);
            Console.ReadKey();


        }
    }
}
