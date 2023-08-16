using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SinglyLinkedListD
{
    public class SinglyLinkedList
    {
        private Node _head;
        private int _count;
        public SinglyLinkedList()
        {
            _head = null;
        }

        public int Peek()
        {
            return _head.Value;
        }

        public int? Get(int index)
        {
            int idx = 0;
            for (Node node = _head; node != null; node = node.Next)
            {
                if (index == idx)
                {
                    return node.Value;
                }
                idx++;
            }
            return null;
        }

        public void InsertFirst(int value)
        {
            Node nextNode = new Node(value);
            nextNode.Next = _head;
            _head = nextNode;
            _count++;
        }

        public bool InsertAt(int index, int value)
        {
            if (index == 0)
            {
                InsertFirst(value);
                return true;
            }
            int idx = 0;
            for (Node node = _head; node != null; node = node.Next)
            {
                if (idx == index - 1)
                {
                    Node nextNode = new Node(value);
                    nextNode.Next = node.Next;
                    node.Next = nextNode;
                    _count++;
                    return true;
                }
                idx++;
            }
            return false;
        }

        public void RemoveFirst()
        {
            if (_head != null)
            {
                _head = _head.Next;
                _count--;
            }
        }

        public bool Remove(int value)
        {
            if (_head != null)
            {
                if (_head.Value == value)
                {
                    RemoveFirst();
                    return true;
                }
                Node node;
                for (Node previousNode = _head; previousNode.Next != null; previousNode = previousNode.Next)
                {
                    node = previousNode.Next;
                    if (node.Value == value)
                    {
                        previousNode.Next = node.Next;
                        _count--;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (_head != null)
            {
                if (index == 0)
                {
                    RemoveFirst();
                    return true;
                }
                int idx = 1;
                Node node;
                for (Node previousNode = _head; previousNode.Next != null; previousNode = previousNode.Next)
                {
                    node = previousNode.Next;
                    if (index == idx)
                    {
                        previousNode.Next = node.Next;
                        _count--;
                        return true;
                    }
                    idx++;
                }
            }
            return false;
        }

        public int Search(int value)
        {
            int index = 0;
            for (Node node = _head; node != null; node = node.Next)
            {
                if (node.Value == value)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public bool Contains(int  value)
        {
            for (Node node = _head; node != null; node = node.Next)
            {
                if (node.Value == value)
                {
                    return true;
                }
            }
            return false;
        }

        public void Reverse()
        {
            Node oldHead = _head;
            Empty();
            for (Node node = oldHead;  node != null; node = node.Next)
            {
                InsertFirst(node.Value);
            }
        }

        public bool IsEmpty()
        {
            return _head == null;
        }

        public void Empty()
        {
            _head = null;
            _count = 0;
        }

        public override string ToString()
        {
            string result = "";
            for (Node node = _head; node != null; node = node.Next)
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
