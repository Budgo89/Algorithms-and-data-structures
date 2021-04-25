using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4._2
{
    
    public class TestWood : ITree
    {
        private TreeNode _node;
        private TreeNode _parent;

        public static TreeNode GetFreeNode(int value, TreeNode parent)
        {
            var _node = new TreeNode
            {
                Value = value
            };
            return _node;
        }

       
        public void AddItem(int value)
        {

            TreeNode tmp = null;
            if (_node == null)
            {
                _node = GetFreeNode(value, null);
                return;
            }
            tmp = _node;
            while (tmp != null)
            {
                if (value > tmp.Value)
                {
                    if (tmp.RightChild != null)
                    {
                        tmp = tmp.RightChild;
                        continue;
                    }
                    else
                    {
                        tmp.RightChild = GetFreeNode(value, tmp);
                        return;
                    }
                }
                else if (value < tmp.Value)
                {
                    if (tmp.LeftChild != null)
                    {
                        tmp = tmp.LeftChild;
                        continue;
                    }
                    else
                    {
                        tmp.LeftChild = GetFreeNode(value, tmp);
                        return;
                    }
                }
                else
                {
                    throw new Exception("Wrong tree state");                  // Дерево построено неправильно
                }

            }
        }

        public TreeNode GetNodeByValue(int value)
        {
           
            TreeNode current = _node;
            _parent = null;
            while (current != null)
            {
                if (current.Value > value)
                {
                    // Если искомое значение меньше, идем налево.
                    _parent = current;
                    current = current.LeftChild;
                }
                else if (current.Value < value)
                {
                    // Если искомое значение больше, идем направо.
                    _parent = current;
                    current = current.RightChild;
                }
                else
                {
                    // Если равны, то останавливаемся
                    break;
                }
            }
            return current;
        }
        public TreeNode GetNodeByValue(int value, TreeNode treeNode)
        {
            TreeNode result = new TreeNode();
            if (treeNode == null)
            {
                return null;
            }
            if (treeNode.Value == value)
            {
                return treeNode;
            }
            if (treeNode.Value > value)
            {
                return GetNodeByValue(value, treeNode.LeftChild);
            }
            else return GetNodeByValue(value, treeNode.RightChild);


        }

        public TreeNode GetRoot()
        {
            throw new NotImplementedException();
        }

        public void PrintTree()
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            PrintTree(x + 10, y, _node);
        }

        public void PrintTree(int x, int y, TreeNode root, int delta = 0)
        {
            if (root != null)
            {
                if (delta == 0) delta = x / 2;
                Console.SetCursorPosition(x, y);
                Console.Write(root.Value);
                PrintTree(x - delta, y + 3, root.LeftChild, delta / 2);
                PrintTree(x + delta, y + 3, root.RightChild, delta / 2);
            }
        }

        public void RemoveItem(int value)
        {
            
            var current = GetNodeByValue(value);

            if (current == null) return;

            if (current.RightChild == null && current.LeftChild == null)
            {
                _parent.RightChild = null;
                _parent.LeftChild = null;               
            }
            else if(current.LeftChild == null)
            {
                _parent.LeftChild = current.RightChild;
            }
            else if(current.RightChild == null)
            {
                _parent.LeftChild = current.LeftChild;
            }
            else if(current.RightChild != null && current.LeftChild != null)
            {
                if (_parent.Value > value)
                {
                    _parent.LeftChild = current.RightChild;
                    current.RightChild.LeftChild = current.LeftChild;
                }
                else
                {
                    _parent.RightChild = current.RightChild;
                    current.RightChild.LeftChild = current.LeftChild;
                }
            }
        }
        public NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = _node };
            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }


    }
}
