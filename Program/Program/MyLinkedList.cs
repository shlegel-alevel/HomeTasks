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
                Tail =Tail.Next = node;
            }
        }

       public void Remove(int value) //in case if there are 2 items with this value         //- remove first
       {
            Node tempNode = new Node();
            Node current, previous;

            if (Head == null)
                throw new ArgumentNullException("Element can not be deleted. The list is empty");

            if (Head.Value == value)
            {
                Head = Head.Next;
            }
            else
            {
                current = Head.Next;
                previous = Head;
                while (current !=null)
                {
                    if (current.Value == value)
                    {
                        previous.Next = current.Next;
                        current = current.Next;
                        break;

                    }
                    else
                    {
                        current = current.Next;
                        previous = previous.Next;
                    }
                }
                if (current == null)
                    Tail = previous;
            }
        }

        public void OutputAllNodes()
        {
            int iterator = 1;
            Node tempNode = new Node();
            tempNode = Head;

            if (tempNode == null)
                throw new NullReferenceException("The list can not be displayed. It is empty");
            
            while (tempNode != null)
            {
                Console.WriteLine($"Element {iterator} = {tempNode.Value}");
                tempNode = tempNode.Next;
                iterator++;
            }
        }
   }

    public class Node
    {
        public Node Next { get; set; }

        public int Value { get; set; }
    }

}
