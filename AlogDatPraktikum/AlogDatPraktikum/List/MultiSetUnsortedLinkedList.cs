using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class MultiSetUnsortedLinkedList : UnsortedLinkedList, MultiSet
    {
        public new bool Delete(int elem)
        {
            return base.Delete(elem);
        }

        public bool Insert(int elem)
        {
            base.Add(elem);
            return true;
        }

        public new void Print()
        {
            base.Print();
        }

        public bool Search(int elem)
        {
            return base.search(elem);
        }

        protected override bool privateDelete(LinkedListNode Element)
        {
            bool flag = base.privateDelete(Element);

            LinkedListNode lfd = Element.next;

            while (lfd != null)
            {
                if (lfd.elem.elemValue == Element.elem.elemValue)
                {
                    privateDelete(lfd);
                    break;
                }

                lfd = lfd.next;
            }
            return flag;
        }
    }
}
