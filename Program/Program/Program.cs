using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList myLinkedList = new MyLinkedList();

            for (var i=0; i<=4; i++)
            {
                myLinkedList.Add(new Node() { Value = i+1 });
            }


            myLinkedList.OutputAllNodes();

            myLinkedList.Remove(5);

            myLinkedList.OutputAllNodes();

            Console.ReadLine();
        }
    }
}
