using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson4
{

    public class BechmarkClass
    {

        public static Random rand = new Random();
        public string[] testMass = new string[10000];
        public string[] testMassRand()
        {
            for (int i = 0; i < 10000; i++)
            {               
                    testMass[i] = Convert.ToString(rand.Next(0, 1000));                
            }
            return testMass;
        }
        public HashSet<string> HashSetNaw = new HashSet<string>();
        public HashSet<string> HashSetNawRand()
        {
            var hashSetTest = new HashSet<string>();
            testMass = testMassRand();
            for (int i = 0; i < 10000; i++)
            {
                var user = Convert.ToString(rand.Next(0, 1000));
                hashSetTest.Add(user);
            }
            return hashSetTest;
        }
        public bool SearchHashSet(string a, HashSet<string> HashSetNaw)
        {
            return HashSetNaw.Contains(a);
        }
        public bool SearcMass(string a, string[] testMass)
        {
            for (int i = 0; i < 10000; i++)
            {               
                    if (testMass[i] == a)
                        return true;      
            }
            return false;
        }
        [Benchmark]
        public void TestHashSet()
        {            
            SearchHashSet(Convert.ToString(10), HashSetNaw);
        }
        [Benchmark]
        public void TestMass()
        {            
            SearcMass(Convert.ToString(10), testMass);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
