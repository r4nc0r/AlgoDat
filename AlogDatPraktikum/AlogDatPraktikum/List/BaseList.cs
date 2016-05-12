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
        private int anz = 0;

        public void Add(int Element)
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
                newListElem.next = prev.next;   // ntesElement(ind);
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
        public void DeleteAt(int ind)
        {
            if (first == null)        // Gibt es überhaupt eine Liste?
                return;

            if (ind == 0)           // Erstes Element löschen?
                DeleteFirst();
            else
            {
                LinkedListNode tmp = ntesElement(ind - 1);
                //LinkedListNode nachf = ntesElement(ind + 1);
                LinkedListNode nachf = tmp.next.next;
                tmp.next = nachf;       // tmp.next.next;
                if (tmp.next == null)   // Wurde das letzte Element gelöscht?
                    last = tmp;
            }
        }

        public bool Delete(int Element)
        {
            LinkedListNode toDelete = privatesearch(Element);
            if (toDelete == null)
                return false;
            else
            {
                toDelete.prev.next = toDelete.next;
                toDelete.next.prev = toDelete.prev;
                return true;
            }
        }

        private LinkedListNode privatesearch(int Element)
        {
            LinkedListNode lfd = first;
            while (lfd.elem != Element && lfd.next != null)
            {
                lfd = lfd.next;
            }
            return lfd;
        }
        public void Print()
        {
            LinkedListNode lfd = first;
            while (lfd != null)
            {
                Console.WriteLine(lfd.elem);
                lfd = lfd.next;
            }
        }

        public bool search(int Element)
        {
            if (privatesearch(Element).elem == Element)
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
    }
}

