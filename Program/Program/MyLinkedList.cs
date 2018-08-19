using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class MyLinkedList : ILinkedList
    {
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public void Add(Node node)
        {
          if (Head == null)
            {
                Head = Tail = node;
            }
          else
            {
                Tail.Next = node;
                Tail = node;
            }
        }

       public void Remove(int value) //in case if there are 2 items with this value         //- remove first
       {
            if (Head == null)
                throw new ArgumentNullException("List is empty try again");

            if (Head.Value == value)
            {
                Head = Head.Next;
            }
            else if (Tail.Value == value)
            {
            }
            else
            {
               
            }

        }

        public void OutputAllNodes()
        {
            int iterator = 1;
            Node tempNode = new Node();
            tempNode = Head;
            do
            {
                Console.WriteLine($"Element {iterator} = {tempNode.Value}");
                tempNode = tempNode.Next;
                iterator++;
            }
            while (tempNode.Next != null);

            Console.WriteLine($"Element {iterator} = {tempNode.Value}");
        }
   }

    public class Node
    {
        public Node Next { get; set; }

        public int Value { get; set; }
    }

}
