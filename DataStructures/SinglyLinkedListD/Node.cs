using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SinglyLinkedListD
{
    public class Node
    {
        private int _value;
        private Node _next;

        public Node(int value)
        {
            _value = value;
            _next = null;
        }

        public int Value
        {
            get => _value;
            set => _value = value;
        }

        public Node Next
        {
            get => _next; 
            set => _next = value;
        }
    }
}
