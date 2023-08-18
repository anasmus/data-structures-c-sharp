using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DoublyLinkedListD
{
    public class Node
    {
        private int _value;
        private Node _right;
        private Node _left;

        public Node(int value)
        {
            _value = value;
            _left = null;
            _right = null;
        }

        public int Value
        {
            get => _value;
            set => _value = value;
        }

        public Node Right
        {
            get => _right;
            set => _right = value;
        }

        public Node Left
        {
            get => _left;
            set => _left = value;
        }
    }
}
