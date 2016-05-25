using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class BaseList
    {
        private LinkedListNode first = null, last = null;

        public LinkedListNode Root { get { return first; } }
        public LinkedListNode Last { get { return last; }
            protected set { last = value; } }

        public virtual void Add(int Element)
        {
            LinkedListNode newListElem = new LinkedListNode();
            newListElem.elem = Element;

            if (first == null)
                first = last = newListElem;
            else
            {
                last.next = newListElem;    // neu wird Nachfolger vom bisherigen Ende
                newListElem.prev = last;    // bisheriges neu ist Vorgänger vom neuen Element
                last = newListElem;         // neues Element ist nun zum letztes Element
            }
        }
        public void AddFirst(int Element)
        {
            LinkedListNode newListElem = new LinkedListNode();
            newListElem.elem = Element;

            if (first == null)
                first = last = newListElem;
            else
            {
                newListElem.next = first;
                first.prev = newListElem;
                first = newListElem;
            }
        }
        public void AddAtInd(int Element, int ind)
        {
            if (ind == 0)
                AddFirst(Element);
            else
            {
                LinkedListNode newListElem = new LinkedListNode();
                newListElem.elem = Element;

                LinkedListNode prev = ntesElement(ind - 1);
                //LinkedListNode prev = ntesElement(ind);

                newListElem.next = prev.next;   // ntesElement(ind);
                newListElem.prev = prev;
                prev.next.prev = newListElem;
                prev.next = newListElem;        // ntesElement(ind-1).next = ...

                if (prev == last)       // Ist das neue Elem. nun das letzte Elem.?
                    last = newListElem;         // --> dann Ende anpassen
            }
        }

        public void DeleteFirst()
        {
            if (first != null)        // Gibt es eine Liste?
            {
                first = first.next;     // Erstes Element überspringen
                if (first == null)    // Ist nach dem Löschen die Liste leer?
                    last = null;    // --> dann auch Ende anpassen
            }
        }
       
        public virtual bool Delete(int Element)
        {
            if (first != null && first.elem == Element)
            {
                DeleteFirst();
                return true;
            }
            else
            {
                LinkedListNode toDelete = privatesearch(Element);
                if (toDelete == null)
                    return false;

                toDelete.prev.next = toDelete.next;
                if (toDelete.prev.next == null)
                    last = toDelete.prev;
                else
                    toDelete.next.prev = toDelete.prev;
                return true;
            }
        }

        public virtual bool Delete(LinkedListNode Element)
        {
            if (first != null && first.elem == Element.elem)
            {
                DeleteFirst();
                return true;
            }
            else
            {
                LinkedListNode toDelete = Element;
                if (toDelete == null)
                    return false;

                toDelete.prev.next = toDelete.next;
                if (toDelete.prev.next == null)
                    last = toDelete.prev;
                else
                    toDelete.next.prev = toDelete.prev;
                return true;
            }
        }

        //Suche liefert für nicht gefundene das falsche ergebniss. 
        protected virtual LinkedListNode privatesearch(int Element)
        {
            LinkedListNode lfd = null;
           
            if (first == null)
            {
                return lfd; 
            }

            lfd = first;
            do
            {
                if (lfd.elem == Element)
                {
                    return lfd;
                }
                   
                lfd = lfd.next;
                
            } while (lfd != null ) ;

            return lfd;
        }


        public void Print()
        {
            LinkedListNode lfd = first;
            while (lfd != null)
            {
                if (lfd.next != null)
                {
                    Console.Write(lfd.elem + " -> ");
                    
                }
                else
                    Console.Write(lfd.elem);
                lfd = lfd.next;
                
            }
            Console.Write("\n\n");
        }

        public virtual bool search(int Element)
        {
            if (privatesearch(Element) != null)
                return true;
            else
                return false;
        }

        public IEnumerator<int> GetEnumerator()
        {
            LinkedListNode lfd = first;
            while (lfd != null)
            {
                yield return lfd.elem;
                lfd = lfd.next;
            }
        }

        private LinkedListNode ntesElement(int ind)
        {
            LinkedListNode lfd = first;
            while (ind > 0)
            {
                lfd = lfd.next;
                ind--;
            }
            return lfd;
        }
        public int this[int ind]
        {
            get
            {
                return ntesElement(ind).elem;
            }
            set
            {
                ntesElement(ind).elem = value;
            }
        }

        public virtual bool DeleteAllSameElements(int elem)
        {
            bool delete = false;
            LinkedListNode lfd = privatesearch(elem);

            while (lfd != null)
            {
                if (lfd.elem == elem)
                {
                    delete = Delete(lfd);
                }
                lfd = lfd.next;
            }

            return delete;
        }
    }
}

