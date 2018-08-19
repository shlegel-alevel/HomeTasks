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
                Tail=Tail.Next = node;
            }
        }

       public void Remove(int value) //in case if there are 2 items with this value         //- remove first
       {
            Node tempNode = new Node();
            tempNode = Head;

            Node headNode, tailNode;

            if (Head == null)
                throw new ArgumentNullException("Element can not be deleted. The list is empty");

            if (Head.Value == value)
            {
                Head = Head.Next;
            }
            else if (Tail.Value == value)
            {
                headNode = tailNode= new Node() { Value = tempNode.Value };
                tempNode = tempNode.Next;
                while (tempNode.Next != null)
                {
                    tailNode.Next = new Node() { Value = tempNode.Value };
                    tailNode = tailNode.Next;
                    tempNode = tempNode.Next;
                }
                Head = headNode;
                Tail = tailNode;
            }
            else
            {
                headNode = tailNode = new Node() { Value = tempNode.Value };
                tempNode = tempNode.Next;
                while (tempNode.Next != null)
                {
                    if (tempNode.Value != value)
                    {
                        tailNode=tailNode.Next = new Node() { Value = tempNode.Value };
                        tempNode = tempNode.Next;
                    }
                    else
                    {
                        tempNode = tempNode.Next;
                    }
                }
                tailNode = tailNode.Next = new Node() { Value = tempNode.Value };
                Head = headNode;
            }
        }

        public void OutputAllNodes()
        {
            int iterator = 1;
            Node tempNode = new Node();
            tempNode = Head;

            if (tempNode == null)
                throw new NullReferenceException("The list can not be displayed. It is empty");
            
            while (tempNode.Next != null)
            {
                Console.WriteLine($"Element {iterator} = {tempNode.Value}");
                tempNode = tempNode.Next;
                iterator++;
            }
            Console.WriteLine($"Element {iterator} = {tempNode.Value}");
        }
   }

    public class Node
    {
        public Node Next { get; set; }

        public int Value { get; set; }
    }

}
