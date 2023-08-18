using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.DoublyLinkedListD;
using DataStructures.SinglyLinkedListD;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);
            list.InsertLast(4);
            list.RemoveLast();
            Console.WriteLine(list);
            Console.ReadLine();
        }
    }
}
