using DataStructures.SinglyLinkedListD;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void InsertFromHead(int index, int value)
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

        public void InsertFromTail(int index, int value)
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
            if (index > _count) return false;
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

        public void Empty()
        {
            _head = null;
            _tail = null;
            _count = 0;
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
