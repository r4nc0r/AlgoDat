using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class MultiSetUnsortedLinkedList : UnsortedLinkedList, MultiSet
    {
        /// <summary>
        /// Löscht Element und greift auf das Löschen der Basis zurück
        /// </summary>
        /// <param name="elem">zulöschendes Element</param>
        /// <returns>true wenn gelöscht wurde ansonsten false</returns>
        public new bool Delete(int elem)
        {
            return base.Delete(elem);
        }

        /// <summary>
        /// Fügt ein neues Element zur Liste hinzu
        /// </summary>
        /// <param name="elem">neues Element</param>
        /// <returns>true wenn eingefügt</returns>
        public bool Insert(int elem)
        {
            Add(elem); 
            return true;
        }

        /// <summary>
        /// Gibt Elemente der Liste aus
        /// </summary>
        public new void Print()
        {
            base.Print();
        }

        /// <summary>
        /// Sucht nach Element in der Liste
        /// </summary>
        /// <param name="elem">zusuchendes Element</param>
        /// <returns>True wenn gefunden ansonsten false</returns>
        public bool Search(int elem)
        {
            return search(elem);
        }

        /// <summary>
        /// Löscht alle Elemente des zulöschenden Elements; Überschreibt die privateDelete der Basisklasse
        /// </summary>
        /// <param name="Element">erstes Ergebnis aus der privateSearch zum zulöschenden Elements</param>
        /// <returns>true wenn gelöscht ansonsten False</returns>
        protected override bool privateDelete(LinkedListNode Element)
        {
            bool result = base.privateDelete(Element); //ruft privates Löschen von der Basis auf, dort wird löschvorgang erfolgen

            if (Element != null)
            {
                LinkedListNode lfd = Element.next; // setze meinen lfd auf das nächste Element

                while (lfd != null)
                {
                    if (lfd.elem.elemValue == Element.elem.elemValue)
                    {
                        privateDelete(lfd);     //wenn Element gefunden rekursiver Aufruf
                        break;
                    }

                    lfd = lfd.next;
                }
            }

            return result;
        }
    }
}
