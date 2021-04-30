using System;
using System.Collections.Generic;

namespace Lesson_6
{
    class Program
    {
        public class TestCase
        {
            public Graph.Node node { get; set; }
            public int X { get; set; }
            public int searchValueInt { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static void TestBFS(TestCase testCase)
        {
            try
            {
                var a = testCase.node.BFSGraph(testCase.X, testCase.node) ;
                if (a.Value == testCase.searchValueInt)                
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
                var a = testCase.node.DFSGraph(testCase.X, testCase.node);
                if (a.Value == testCase.searchValueInt)
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
        public static Graph.Node GenerGraph()
        {
            var s = new Graph();
            Graph.Node x = new Graph.Node()
            {
                Value = 66,
                Edges = new List<Graph.Edge>()
            };
            x.Edges.Add(new Graph.Edge
            {
                Weight = 7,
                Node = new Graph.Node
                {
                    Value = 8,
                    Edges = new List<Graph.Edge>()
                }
            });
            x.Edges.Add(new Graph.Edge
            {
                Weight = 8,
                Node = new Graph.Node
                {
                    Value = 1,
                    Edges = new List<Graph.Edge>()
                }
            });
            x.Edges.Add(new Graph.Edge
            {
                Weight = 2,
                Node = new Graph.Node
                {
                    Value = 10,
                    Edges = new List<Graph.Edge>()
                }
            });
            x.Edges[0].Node.Edges.Add(new Graph.Edge
            {
                Weight = 3,
                Node = new Graph.Node
                {
                    Value = 3,
                    Edges = new List<Graph.Edge>()
                }
            });
            x.Edges[1].Node.Edges.Add(new Graph.Edge
            {
                Weight = 4,
                Node = new Graph.Node
                {
                    Value = 4,
                    Edges = new List<Graph.Edge>()
                }
            });
            x.Edges[2].Node.Edges.Add(new Graph.Edge
            {
                Weight = 9,
                Node = new Graph.Node
                {
                    Value = 9,
                    Edges = new List<Graph.Edge>()
                }
            });
            x.Edges[2].Node.Edges.Add(new Graph.Edge
            {
                Weight = 2,
                Node = new Graph.Node
                {
                    Value = 2,
                    Edges = new List<Graph.Edge>()
                }
            });
            x.Edges[0].Node.Edges[0].Node.Edges.Add(new Graph.Edge
            {
                Weight = 3,
                Node = new Graph.Node
                {
                    Value = 3,
                    Edges = new List<Graph.Edge>()
                    {
                        new Graph.Edge
                        {
                            Node = x.Edges[1].Node.Edges[0].Node,
                            Weight = 20
                        }

                    }
                }
            });
            return x;
        }

        static void Main(string[] args)
        {
            var x = GenerGraph();


            var test1 = new TestCase
            {
                node = x,
                X = 4,
                searchValueInt = 4,
                ExpectedException = null,

            };
            TestBFS(test1);
            TestDFS(test1);
            var test2 = new TestCase
            {
                node = x.Edges[1].Node,
                X = 4,
                searchValueInt = 4,
                ExpectedException = null,

            };
            TestBFS(test2);
            TestDFS(test2);
            var test3 = new TestCase
            {
                node = x.Edges[2].Node,
                X = 4,
                searchValueInt = 4,
                ExpectedException = null,

            };
            TestBFS(test3);
            TestDFS(test3);
            Console.ReadKey();
        }
    }
}
