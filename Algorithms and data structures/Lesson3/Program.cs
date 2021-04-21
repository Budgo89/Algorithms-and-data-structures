using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class PointClass
    {
        public int X;
        public int Y;
    }

    public struct PointStruct
    {
        public int X;
        public int Y;
    }
    public class BechmarkClass
    {
        public static Random rand = new Random();
        public static int[] pointOneMass = new int[] { rand.Next(0, 100), rand.Next(0, 100), };
        public static int[] pointTwoMass = new int[] { rand.Next(0, 100), rand.Next(0, 100), };
        public PointClass pointOne = new PointClass
        {
            X = pointOneMass[0],
            Y = pointOneMass[1]
        };
        public PointClass pointTwo = new PointClass
        {
            X = pointTwoMass[0],
            Y = pointTwoMass[1]
        };
        public PointStruct pointOneStruct = new PointStruct
        {
            X = pointOneMass[0],
            Y = pointOneMass[1]
        };
        public PointStruct pointTwoStruct = new PointStruct
        {
            X = pointTwoMass[0],
            Y = pointTwoMass[1]
        };
        public static float PointDistanceClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
        [Benchmark]
        public void TestPointDistanceClass()
        {
            PointDistanceClass(pointOne, pointTwo);
        }
        [Benchmark]
        public void PointDistanceTect()
        {
            PointDistanceStruct(pointOneStruct, pointTwoStruct);
        }
        [Benchmark]
        public void PointDistanceDoubleTect()
        {
            PointDistanceDouble(pointOneStruct, pointTwoStruct);
        }
        [Benchmark]
        public void PointDistanceShortTect()
        {
            PointDistanceShort(pointOneStruct, pointTwoStruct);
        }
    }
}
