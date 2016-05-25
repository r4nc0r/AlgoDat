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

                if (lfd.elem < Element)
                {
                    lfd = lfd.next;
                }
                else
                    return lfd;
            }
            
            return lfd;
        }

        public override bool DeleteAllSameElements(int elem)
        {
            bool delete = false;
            LinkedListNode lfd = base.privatesearch(elem);

            if (lfd == null)
            {
                return delete;
            }

            while (lfd.next != null && lfd.next.elem == elem)
            {
                delete = Delete(lfd);
                lfd = lfd.next;
            }

            delete = Delete(lfd);

            return delete;
        }


        public override bool search(int Element)
        {
            if (Root == null || Element < Root.elem || Element > Last.elem)
            {
                return false;
            }

            if (privatesearch(Element) != null)
                return true;
            else
                return false;
        }

        protected override LinkedListNode privatesearch(int Element)
        {
            LinkedListNode lfd = null;

            if (Root == null || Element < Root.elem || Element > Last.elem)
            {
                return lfd;
            }

            lfd = Root;
            do
            {
                if (lfd.elem < Element)
                {
                    if (lfd.next.next != null)
                    {
                        lfd = lfd.next.next;
                    }
                    else
                    {
                        if (lfd.next.elem == Element)
                        {
                            return lfd.next;
                        }
                    }
                }
                else
                {
                    if (lfd.elem == Element)
                        return lfd;
                    else if (lfd.prev.elem == Element)
                        return lfd.prev;
                    else
                        lfd = null;
                }
            } while (lfd != null);

            return lfd;
        }
    }
}
