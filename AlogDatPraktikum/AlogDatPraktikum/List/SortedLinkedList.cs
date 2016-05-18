using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
   abstract class SortedLinkedList : BaseList
    {
        public override void Add(int Element)
        {
            if (Root == null)
                AddFirst(Element);
            else
            {
                LinkedListNode newElement = new LinkedListNode { elem = Element };
                LinkedListNode temp = lookingforbigger(Element);

                if (temp == null)
                {
                    base.Add(Element);
                }
                else
                {
                    newElement.next = temp;
                    newElement.prev = temp.prev;
                    temp.prev.next = newElement;
                    temp.prev = newElement;
                }
            }
        }

        private LinkedListNode lookingforbigger(int Element)
        {
            LinkedListNode lfd = Root;

            while (lfd != null)
            {

                if (lfd.elem < Element)
                {
                    lfd = lfd.next;
                }
                else
                    return lfd;
                
            }
            
            return lfd;
        }
    }
}
