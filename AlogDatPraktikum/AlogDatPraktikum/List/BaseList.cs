using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class BaseList
    {
        #region Variablen Properties
        private LinkedListNode first = null, last = null;
        public LinkedListNode Root { get { return first; } } //enthält erstes Listenelement
        public LinkedListNode Last { get { return last; }
            protected set { last = value; } }                       //enthält letzes Listenelement
        #endregion

        #region MethodenH

        /// <summary>
        /// Hängt neues Element ans Ende der Liste
        /// </summary>
        /// <param name="Element">das neuhinzufügende Element</param>
        public virtual void Add(int Element)
        {
            LinkedListNode newListElem = new LinkedListNode { elem = new DictElement(Element)} ;

            if (first == null)
                first = last = newListElem;
            else
            {
                last.next = newListElem;    // neu wird Nachfolger vom bisherigen Ende
                newListElem.prev = last;    // bisheriges neu ist Vorgänger vom neuen Element
                last = newListElem;         // neues Element ist nun letztes Element
            }
        }
        
        /// <summary>
        /// Hängt neues Element an Anfang der Liste
        /// </summary>
        /// <param name="Element"></param>
        public void AddFirst(int Element)
        {
            LinkedListNode newListElem = new LinkedListNode { elem = new DictElement(Element) };

            if (first == null)
                first = last = newListElem;
            else
            {
                newListElem.next = first;       // der bisherige Anfang wird dem neuen Element als Nachfolger gegeben
                first.prev = newListElem;       // vom bisherigen Anfang wird das neue Element als Vorgänger gesetzt
                first = newListElem;            // neues Element wird als first Element deklariert
            }
        }

        /// <summary>
        /// Löscht das erste Element der Liste
        /// </summary>
        public bool DeleteFirst()
        {
            if (first != null)        // Gibt es eine Liste?
            {
                first = first.next;     // Erstes Element überspringen
                if (first == null)    // Ist nach dem Löschen die Liste leer?
                    last = null;    // --> dann auch Ende anpassen
                else
                    first.prev = null; //vom neuen Anfang den Vorgänger entfernen
                return true;
            }
            return false;
        }
       
        /// <summary>
        /// Löscht ein Element aus der Liste
        /// </summary>
        /// <param name="Element">das zulöschende Element</param>
        /// <returns>true, wenn Element gelöscht wurde, false falls nicht</returns>
        public bool Delete(int Element)
        {
            return privateDelete(privatesearch(Element));
        }

        /// <summary>
        /// Löschen des Elements; 
        /// </summary>
        /// <param name="Element">das zulöschende Element</param>
        /// <returns>true, wenn Element gelöscht wurde, false falls  nicht</returns>
        protected virtual bool privateDelete(LinkedListNode Element)
        {
            if (Element == null)
                return false;

            if (first != null && first.elem.elemValue == Element.elem.elemValue) //wenn first nicht null und es ist das zulöschendes Element => DeleteFirst
            {
               return DeleteFirst();
            }
            else
            {
                Element.prev.next = Element.next; //vom zulöschenden Element dessen Vorgänger bekommt als Nachfolger, den Nachfolger von zulöschenden Element 
                if (Element.prev.next == null)    //Wenn das zulöschende Element das letzte war so, muss die Property last neu gesetzt werden 
                    last = Element.prev;
                else
                    Element.next.prev = Element.prev; //vom zulöschenden Element dessen Nachfolger bekommt als Vorgänger den Vorgänger vom zulöschendne Element
                return true;
            }
        }

        
        /// <summary>
        /// sucht nach gewünschten Element in der Liste und gibt es zurück
        /// </summary>
        /// <param name="Element">zusuchende Element</param>
        /// <returns>LinkedListNode des zusuchenden Elements</returns>
        protected virtual LinkedListNode privatesearch(int Element)
        {
            LinkedListNode lfd = null; //hier noch keine Zuweisung von first, falls bei der while-Schleife nichtsgefunden wird, wird lfd als null zurückgeben
           
            if (first == null) //Liste leer return null
            {
                return lfd; 
            }

            lfd = first; //setze lfd auf das erste Element
            do
            {
                if (lfd.elem.elemValue == Element) //zusuchendes Element entspricht vom lfd dem Element, dann gebe es zurück
                {
                    return lfd;
                }
                   
                lfd = lfd.next;
                
            } while (lfd != null);

            return lfd;
        }

        /// <summary>
        /// Gibt die Elemente der Liste aus
        /// </summary>
        public void Print()
        {
            LinkedListNode lfd = first;
            while (lfd != null)
            {
                if (lfd.next != null)
                {
                    Console.Write(lfd.elem.elemValue + " -> ");
                }
                else
                    Console.Write(lfd.elem.elemValue);
                lfd = lfd.next;
            }
            Console.Write("\n\n");
        }

        /// <summary>
        /// sucht nach dem zusuchenden Element
        /// </summary>
        /// <param name="Element">zusuchendes Element</param>
        /// <returns>true falls gefunden ansonsten false</returns>
        public virtual bool search(int Element)
        {
            if (privatesearch(Element) != null)
                return true;
            else
                return false;
        }
        #endregion
    }
}

