using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
   abstract class UnsortedLinkedList : BaseList
    {
        public override void Add(int Element)
        {
            if (Root == null)
            {
                AddFirst(Element);
            }
            else
            {
                Last.next = new LinkedListNode { elem = new DictElement(Element) };
                Last.next.prev = Last;
                Last = Last.next;
            }
        }

       
    }
}
