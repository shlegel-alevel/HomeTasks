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

            for (var i=0; i<=2; i++)
            {
                myLinkedList.Add(new Node() { Value = i+1 });
            }

            myLinkedList.Add(new Node() { Value = 1 });
            myLinkedList.Add(new Node() { Value = 2 });
            myLinkedList.Add(new Node() { Value = 3 });

            try
            {
                Console.WriteLine("InitialList");
                myLinkedList.OutputAllNodes();

                Console.WriteLine($"Remove element with value {1 + 1}");
                myLinkedList.Remove(2);

                myLinkedList.OutputAllNodes();

                for (int i = 1; i <= 5; i++)
                {
                    myLinkedList.Remove(10);
                    Console.WriteLine($"Remove element with value {i + 1}");
                    myLinkedList.Remove(i + 1);
                    myLinkedList.OutputAllNodes();
                }

                Console.WriteLine($"Remove element with value {1}");
                myLinkedList.Remove(1);
                myLinkedList.OutputAllNodes();

            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine (ae.Message);
            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine(ne.Message);
            }


            Console.ReadLine();
        }
    }
}
