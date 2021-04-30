using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    public class Graph
    {
        public Node node;

    public class Node //Вершина
        {
            public int Value { get; set; }
            public List<Edge> Edges { get; set; } //исходящие связи

            public Node BFSGraph(int x, Node _node)
            {
                var bufer = new Queue<Node>();
                var knot = new Queue<Node>();
                bufer.Enqueue(_node);
                Console.WriteLine($"Добавляем стартовую ноду {_node.Value} в очередь");
                while (bufer.Count != 0)
                {
                    var root = bufer.Dequeue();
                    Console.WriteLine($"Вытягиваем ноду {root.Value} из начала очереди и удаляем из списка");

                    if (root != null)
                    {
                        Console.WriteLine($"Сравниваем с {x}");
                        if (root.Value == x)
                            return root;
                        Console.WriteLine($"Удаляем ноду {root.Value} из стэка");
                        knot.Enqueue(root);
                        Console.WriteLine($"Отмечаем ноду {root.Value} как проверенную");
                        for (int i = 0; i < root.Edges.Count; i++)
                        {
                            var a = root.Edges[i];
                            bufer.Enqueue(a.Node);
                            Console.WriteLine($"Добавляем в очередь ноду {a.Node.Value}");
                        }
                        if (bufer.Count != 0 && knot.Count != 0)
                        {
                            while (bufer.Peek() == knot.Peek())
                            {
                                bufer.Dequeue();
                            }
                            Console.WriteLine("Удаляем проверенные элементы из буфера");
                        }
                    }
                }
                Console.WriteLine("Элемент не найдев, возвращаю стартавый элемент: ");
                return _node;
            }

            public Node DFSGraph(int x, Node _node)
            {

                var stek = new Stack<Node>();
                var knot = new Queue<Node>();
                stek.Push(_node);
                Console.WriteLine($"Добавляем стартовую ноду {_node.Value} в стэк");
                while (stek.Count != 0)
                {
                    var root = stek.Pop();
                    Console.WriteLine($"Вытягиваем ноду {root.Value} и удалем из стека");
                    if (root != null)
                    {
                        Console.WriteLine($"Сравниваем с {x}");
                        if (root.Value == x)
                            return root;
                        knot.Enqueue(root);
                        Console.WriteLine($"Отмечаем ноду {root.Value} как проверенную");
                        for (int i = root.Edges.Count - 1; i >= 0; i--)
                        {
                            var a = root.Edges[i];
                            stek.Push(a.Node);
                            Console.WriteLine($"Добавляем в стек ноду {a.Node.Value}");
                        }
                        if (stek.Count != 0 && knot.Count != 0)
                        {
                            while (stek.Peek() == knot.Peek())
                            {
                                stek.Pop();
                            }
                            Console.WriteLine("Удаляем проверенные элементы из стека");
                        }
                    }
                }
                Console.WriteLine("Элемент не найдев, возвращаю стартавый элемент: ");
                return _node;
            }
        }

        public class Edge //Ребро
        {
            public int Weight { get; set; } //вес связи
            public Node Node { get; set; } // узел, на который связь ссылается            
        }
        

    }
}
