using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public interface ILinkedList
    {
        Node Head { get; set; }

        Node Tail { get; set; }

        void Add(Node node);

        void Remove(int value); //in case if there are 2 items with this value         //- remove first

        void OutputAllNodes();
    }

}
