using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson4
{

    public class BechmarkClass
    {
        public class User
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }

            public override bool Equals(object obj)
            {
                var user = obj as User;

                if (user == null)
                    return false;

                return FirstName == user.FirstName && SecondName == user.SecondName;
            }
            public override int GetHashCode()
            {
                int firtsNameHashCode = FirstName?.GetHashCode() ?? 0;
                int secondNameHashCode = SecondName?.GetHashCode() ?? 0;
                return firtsNameHashCode ^ secondNameHashCode;
            }
        }
        public static Random rand = new Random();
        public string[,] testMass = new string[10000,2];
        public string[,] testMassRand()
        {
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    testMass[i,j] = Convert.ToString(rand.Next(0, 1000));
                }
                
            }
            return testMass;
        }
        
        public HashSet<User> HashSetNaw()
        {
            var hashSetTest = new HashSet<User>();
            testMass = testMassRand();
            for (int i = 0, j=0; j < 10000; i++, j++)
            {
                var user = new User() { FirstName = testMass[i,0], SecondName = testMass[0,j] };
                hashSetTest.Add(user);
            }
            return hashSetTest;
        }
        public bool SearchHashSet(string a, string b, HashSet<User> HashSetNaw)
        {
            var searchUsser = new User() { FirstName = a, SecondName = b };
            return HashSetNaw.Contains(searchUsser);

        }
        public bool SearcMass(string a, string b, string[,] testMass)
        {
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (testMass[i, 0] == a && testMass[0, j] == b)
                        return true;
                }
                
            }
            return false;
        }

        [Benchmark]
        public void TestHashSet()
        {
            var a = HashSetNaw();
            SearchHashSet(Convert.ToString(10), Convert.ToString(20), a);
        }
        [Benchmark]
        public void TestMass()
        {
            var a = testMassRand();
            SearcMass(Convert.ToString(10), Convert.ToString(20), a);
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            //var hashSet = new HashSet<User>();

            //var user = new User() { FirstName = "Barbara", SecondName = "Santa" };

            //hashSet.Add(user);

            //var searchUsser = new User() { FirstName = "Barbara", SecondName = "Santa" };

            //Console.WriteLine($"contains user {hashSet.Contains(user)}, contains searchUsser {hashSet.Contains(searchUsser)}");
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
