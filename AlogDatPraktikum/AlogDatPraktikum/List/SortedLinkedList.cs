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
                LinkedListNode newElement = new LinkedListNode { elem = new DictElement(Element) };
                LinkedListNode temp = lookingforbigger(Element);

                if (temp == null)
                {
                    base.Add(Element);
                }
                else
                {
                    if (temp.prev == null)
                        AddFirst(Element);
                    else
                    {
                        newElement.next = temp;
                        newElement.prev = temp.prev;
                        temp.prev.next = newElement;
                        temp.prev = newElement;
                    }
                }
            }
        }

        private LinkedListNode lookingforbigger(int Element)
        {
            LinkedListNode lfd = Root;

            while (lfd != null)
            {

                if (lfd.elem.elemValue < Element)
                {
                    lfd = lfd.next;
                }
                else
                    return lfd;
            }
            
            return lfd;
        }

        protected override bool privateDelete(LinkedListNode Element)
        {
            if (Element == null)
                return false;
           bool flag = base.privateDelete(Element);

            if (Element.next != null && Element.next.elem.elemValue == Element.elem.elemValue) 
            {
                privateDelete(Element.next);
            }

            if ((Element.prev != null && Element.prev.elem.elemValue == Element.elem.elemValue))
            {
                privateDelete(Element.prev);
            }

            return flag;
        }

        public override bool search(int Element)
        {
            if (this.privatesearch(Element) != null)
                return true;
            else
                return false;
        }

        protected override LinkedListNode privatesearch(int Element)
        {
            LinkedListNode lfd = null;

            if (Root == null || Element < Root.elem.elemValue || Element > Last.elem.elemValue)
            {
                return null;
            }

            if (Root.elem.elemValue == Element)
                return Root;

            if (Last.elem.elemValue == Element)
                return Last;

            lfd = Root;
            do
            {
                if (lfd.elem.elemValue < Element)
                {
                    if (lfd.next.next != null)
                    {
                        lfd = lfd.next.next;
                    }
                    else
                    {
                        if (lfd.next.elem.elemValue == Element)
                        {
                            return lfd.next;
                        }

                       
                    }
                }
                else
                {
                    if (lfd.elem.elemValue == Element)
                        return lfd;
                    else if (lfd.prev.elem.elemValue == Element)
                        return lfd.prev;
                    else
                        lfd = null;
                }
            } while (lfd != null);

            return lfd;
        }
    }
}
