using System;
using System.Collections.Generic;

namespace Lesson_8
{
    class Program
    {
		public class TestCase
		{
			public int[] X { get; set; }
			public int[] searchValue { get; set; }
			public Exception ExpectedException { get; set; }
		}
		static bool MassTect(int[] a, int[] b)
		{
			bool flag = false;
			if (a.Length == b.Length)
			{
				for (int i = 0; i < b.Length; i++)
				{
					if (a[i] == b[i])
					{
						flag = true;
					}
					else return false;
				}
				return flag;
			}
			else return false;
		}

		static void TestBucketSort(TestCase testCase)
        {
            try
            {
				var mass = BucketSort(testCase.X);
				if (MassTect(mass, testCase.searchValue))
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

		public static int[] BucketSort(int[] data)
		{
			int minValue = data[0];
			int maxValue = data[0];

			for (int i = 1; i < data.Length; i++)
			{
				if (data[i] > maxValue)
					maxValue = data[i];
				if (data[i] < minValue)
					minValue = data[i];
			}

			List<int>[] bucket = new List<int>[maxValue - minValue + 1];

			for (int i = 0; i < bucket.Length; i++)
			{
				bucket[i] = new List<int>();
			}

			for (int i = 0; i < data.Length; i++)
			{
				bucket[data[i] - minValue].Add(data[i]);
			}

			int k = 0;
			for (int i = 0; i < bucket.Length; i++)
			{
				if (bucket[i].Count > 0)
				{
					for (int j = 0; j < bucket[i].Count; j++)
					{
						data[k] = bucket[i][j];
						k++;
					}
				}
			}
			return data;
		}
		static void Main(string[] args)
        {
			int[] data = new int[] { -5, -25, -84668, 261, -8913, 0, 83153 };
			int[] testMass = new int[] { -84668, -8913, -25, -5, 0, 261, 83153 };
			var test1 = new TestCase
			{
				X = data,
				searchValue = testMass,
				ExpectedException = null
			};
			TestBucketSort(test1);
			int[] data2 = new int[] { -5, -25, -84668, 261, -8913, 0, 83153 };
			int[] testMass2 = new int[] { -84668, -8913, -25, -5, 261, 83153 };
			var test2 = new TestCase
			{
				X = data2,
				searchValue = testMass2,
				ExpectedException = null
			};
			TestBucketSort(test2);
		}
    }
}
