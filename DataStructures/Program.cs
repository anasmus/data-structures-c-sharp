using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.SinglyLinkedListD;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.InsertFirst(1);
            list.InsertFirst(2);
            list.InsertFirst(3);
            Console.WriteLine(list.InsertAt(3,0));
            Console.WriteLine(list);
            Console.ReadLine();
        }
    }
}
