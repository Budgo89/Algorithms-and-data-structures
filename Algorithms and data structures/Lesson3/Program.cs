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
        //public int[] pointOneMass;
        public static int[] pointOneMass = new int[10000];// { rand.Next(0, 100), rand.Next(0, 100), };
        public static int[] pointTwoMass = new int[10000];// { rand.Next(0, 100), rand.Next(0, 100), };
        PointClass pointOne = new PointClass { };
        PointClass pointTwo = new PointClass { };
        PointStruct pointOneStruct = new PointStruct { };
        PointStruct pointTwoStruct = new PointStruct { };
        public int[] forPointOneMas()
		{
            for (int i = 0; i < pointOneMass.Length; i++)
            {
                pointOneMass[i] = rand.Next(0, 1000);
            }
            return pointOneMass;
        }
        public int[] forPointTwoMas()
        {
            for (int i = 0; i < pointOneMass.Length; i++)
            {               
                pointTwoMass[i] = rand.Next(0, 1000);
            }
            return pointOneMass;
        }
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
            pointOneMass = forPointOneMas();
            pointTwoMass = forPointTwoMas();
            for (int i = 0; i < pointOneMass.Length - 1; i++)
            {

                pointOne.X = pointOneMass[i];
                pointOne.Y = pointOneMass[i + 1];
                pointTwo.X = pointTwoMass[i];
                pointTwo.Y = pointTwoMass[i + 1];
                PointDistanceClass(pointOne, pointTwo);
            }

        }

        [Benchmark]
        public void PointDistanceTect()
        {
            pointOneMass = forPointOneMas();
            pointTwoMass = forPointTwoMas();
            for (int i = 0; i < pointOneMass.Length - 1; i++)
            {

                pointOneStruct.X = pointOneMass[i];
                pointOneStruct.Y = pointOneMass[i + 1];
                pointTwoStruct.X = pointTwoMass[i];
                pointTwoStruct.Y = pointTwoMass[i + 1];
                PointDistanceStruct(pointOneStruct, pointTwoStruct);
            }

        }
        [Benchmark]
        public void PointDistanceDoubleTect()
        {
            pointOneMass = forPointOneMas();
            pointTwoMass = forPointTwoMas();
            for (int i = 0; i < pointOneMass.Length - 1; i++)
            {

                pointOneStruct.X = pointOneMass[i];
                pointOneStruct.Y = pointOneMass[i + 1];
                pointTwoStruct.X = pointTwoMass[i];
                pointTwoStruct.Y = pointTwoMass[i + 1];
                PointDistanceDouble(pointOneStruct, pointTwoStruct);
            }
        }
        [Benchmark]
        public void PointDistanceShortTect()
        {
            pointOneMass = forPointOneMas();
            pointTwoMass = forPointTwoMas();
            for (int i = 0; i < pointOneMass.Length - 1; i++)
            {

                pointOneStruct.X = pointOneMass[i];
                pointOneStruct.Y = pointOneMass[i + 1];
                pointTwoStruct.X = pointTwoMass[i];
                pointTwoStruct.Y = pointTwoMass[i + 1];
                PointDistanceShort(pointOneStruct, pointTwoStruct);
            }
        }
    }
}
