using DataStructures.SinglyLinkedListD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DoublyLinkedListD
{
    public class DoublyLinkedList
    {
        private Node _head;
        private Node _tail;
        private int _count;

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public int? PeekFirst()
        {
            if (_head == null) return null;
            return _head.Value;
        }

        public int? PeekLast()
        {
            if (_tail == null) return null;
            return _tail.Value;
        }

        private int GetFromHead(int index)
        {
            int idx = 0;
            int value = 0;
            for (Node node = _head; node != null; node = node.Right)
            {
                if (index == idx)
                {
                    value = node.Value;
                    break;
                }
                idx++;
            }
            return value;
        }

        private int GetFromTail(int index)
        {
            int idx = _count - 1;
            int value = 0;
            for (Node node = _tail; node != null; node = node.Left)
            {
                if (index == idx)
                {
                    value = node.Value;
                    break;
                }
                idx--;
            }
            return value;
        }

        public int? Get(int index)
        {
            if (index >= _count) return null;
            int value;
            if (index > _count / 2)
            {
                value = GetFromTail(index);
            }
            else
            {
                value = GetFromHead(index);
            }
            return value;
        }

        public void InsertFirst(int value)
        {
            Node node = new Node(value);
            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                Node firstNode = _head;
                node.Right = firstNode;
                firstNode.Left = node;
                _head = node;
            }
            _count++;
        }

        public void InsertLast(int value)
        {
            Node node = new Node(value);
            if (_tail == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                Node lastNode = _tail;
                node.Left = lastNode;
                lastNode.Right = node;
                _tail = node;
            }
            _count++;
        }

        private void InsertFromHead(int index, int value)
        {
            int idx = 0;
            Node newNode = new Node(value);
            for (Node node = _head; node != null; node = node.Right)
            {
                if (index == idx)
                {
                    Node previousNode = node.Left;
                    newNode.Right = node;
                    newNode.Left = previousNode;
                    previousNode.Right = newNode;
                    node.Left = newNode;
                    break;
                }
                idx++;
            }
            _count++;
        }

        private void InsertFromTail(int index, int value)
        {
            int idx = _count - 1;
            Node newNode = new Node(value);
            for (Node node = _tail; node != null; node = node.Left)
            {
                if (index == idx)
                {
                    Node previousNode = node.Left;
                    newNode.Right = node;
                    newNode.Left = previousNode;
                    previousNode.Right = newNode;
                    node.Left = newNode;
                    break;
                }
                idx--;
            }
            _count++;
        }

        public bool InsertAt(int index, int value)
        {
            if (_head == null || index > _count) return false;
            if (index == 0)
            {
                InsertFirst(value);
            }
            else if (index == _count)
            {
                InsertLast(value);
            }
            else if (index > _count / 2)
            {
                InsertFromTail(index, value);
            }
            else
            {
                InsertFromHead(index, value);
            }
            return true;
        }

        private void RemoveNode(Node node)
        {
            Node lastNode = node.Left;
            Node nextNode = node.Right;
            lastNode.Right = nextNode;
            if (nextNode != null)
            {
                nextNode.Left = lastNode;
            }
            _count--;
        }

        public bool RemoveFirst()
        {
            if (_head == null) return false;
            _head.Left = null;
            _head = _head.Right;
            _head.Left = null;
            _count--;
            if (_count == 0) Empty();
            return true;
        }

        public bool RemoveLast()
        {
            if (_tail == null) return false;
            _tail.Right = null;
            _tail = _tail.Left;
            _tail.Right = null;
            _count--;
            if (_count == 0) Empty();
            return true;
        }

        private void RemoveFromHead(int index)
        {
            int idx = 0;
            for (Node node = _head; node != null; node = node.Right)
            {
                if (index == idx)
                {
                    RemoveNode(node);
                    break;
                }
                idx++;
            }
        }

        private void RemoveFromTail(int index)
        {
            int idx = _count - 1;
            for (Node node = _tail; node != null; node = node.Left)
            {
                if (index == idx)
                {
                    RemoveNode(node);
                    break;
                }
                idx--;
            }
        }

        public bool Remove(int value)
        {
            if (_head == null) return false;
            if (_head.Value == value) return RemoveFirst();
            if (_tail.Value == value) return RemoveLast();
            for (Node node = _head; node != null; node = node.Right)
            {
                if (node.Value == value)
                {
                    RemoveNode(node);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (_head == null || index >= _count) return false;
            if (index == 0) return RemoveFirst();
            if (index == _count - 1) return RemoveLast();
            if (index > _count / 2)
            {
                RemoveFromTail(index);
            } 
            else
            {
                RemoveFromHead(index);
            }
            return true;
        }

        public int Search(int value)
        {
            if (_head == null) return -1;
            int index = 0;
            for (Node node = _head; node != null; node = node.Right)
            {
                if (node.Value == value)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public bool Contains(int value)
        {
            if (_head == null) return false;
            for (Node node = _head; node != null; node = node.Right)
            {
                if (node.Value == value)
                {
                    return true;
                }
            }
            return false;
        }

        public void Empty()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }

        public override string ToString()
        {
            string result = "";
            for (Node node = _head; node != null; node = node.Right)
            {
                result += $"{node.Value}, ";
            }

            if (result.Length > 0)
            {
                result = $"[{result.Substring(0, result.Length - 2)}]";
            }
            else
            {
                result = "[]";
            }
            return result;
        }

        public int Count
        {
            get => _count;
        }
    }
}
