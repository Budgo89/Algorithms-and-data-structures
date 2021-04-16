using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class LinkedList : ILinkedList
    {
        private Node _srartNode;
        private Node _endNode;
        private int _count;

        // добавляет новый элемент списка
        public void AddNode(int value)
        {

            var newNode = new Node { Value = value };
            if (_count == 0)
            {
                newNode.NextNode = newNode;
                _srartNode = newNode;
                newNode.PrevNode = newNode;
                _endNode = newNode;
            }
            else
            {  
                newNode.PrevNode = _endNode;
                _endNode.NextNode = newNode;
                _endNode = newNode;
            }            
            _count++;

        }
        // добавляет новый элемент списка после определённого элемента
        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Value = value };
            var nextNode = node.NextNode;
            var previousNode = nextNode.PrevNode;
            node.NextNode = newNode;
            newNode.NextNode = nextNode;
            newNode.PrevNode = previousNode;
            nextNode.PrevNode = newNode;
            if (node == _endNode)
                _endNode = newNode;
            _count++;
        }
        // ищет элемент по его значению
        public Node FindNode(int searchValue)
        {
            Node current = _srartNode;
            while (current != null)
            {
                if (current.Value == searchValue)
                    return current;
                current = current.NextNode;
               
            }
            return null;
        }
        // возвращает количество элементов в списке
        public int GetCount()
        {
            return _count;
        }
        // удаляет элемент по порядковому номеру
        public void RemoveNode(int index)
        {
            Node current = _srartNode;
            int i = 0;
            if (index == 0)
            {
                var nextNode = current.NextNode;
                _srartNode = nextNode;
                current.NextNode = null;
                current.PrevNode = null;
                nextNode.PrevNode = null;

            }
            else if (index == _count)
            {
                var previousNode = _endNode.PrevNode;
                previousNode.NextNode = null;
                _endNode = previousNode;
            }
            else
                while (current != null)
                {                
                    if (i == index)
                    {
                        var nextNode = current.NextNode;
                        var previousNode = current.PrevNode;
                        previousNode.NextNode = nextNode;
                        nextNode.PrevNode = previousNode;
                    }
                    current = current.NextNode;
                    i++;
                }
            _count--;
        }
        // удаляет указанный элемент
        public void RemoveNode(Node node)
        {
            if (node == _srartNode) 
            {
                var nextNode = node.NextNode;
                nextNode.PrevNode = null;
                node.NextNode = null;
                _srartNode = nextNode;

            }
            else if (node == _endNode)
            {
                var previousNode = node.PrevNode;
                previousNode.NextNode = null;
                node.PrevNode = null;
                _endNode = previousNode;
            }
            else
            {
                var nextNode = node.NextNode;
                var previousNode = node.PrevNode;
                nextNode.PrevNode = previousNode;
                previousNode.NextNode = nextNode;
            }

            _count--;
        }
        
        public void print()
        {
            Node current = _srartNode;
            for (int i = 0; i < _count; i++)
            {                
                Console.WriteLine(current.Value);
                current = current.NextNode;
            }
            
        }
    }
}
