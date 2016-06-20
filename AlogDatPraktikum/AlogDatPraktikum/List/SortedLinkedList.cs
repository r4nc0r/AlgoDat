using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    abstract class SortedLinkedList : BaseList
    {
        /// <summary>
        /// Überschreibt Add Methode aus der Basis
        /// </summary>
        /// <param name="Element">hinzufügendes Element</param>
        public override void Add(int Element)
        {
            if (Root == null) // Liste leer, dannn erstes Element
                AddFirst(Element);
            else
            {
                LinkedListNode newElement = new LinkedListNode { elem = new DictElement(Element) };
                LinkedListNode temp = lookingForNextBiggerElement(Element); //temp enthält das nächstgrößere Element vom neuen Element

                if (temp == null) //neues Element wird zu letzten Element der Liste
                {
                    base.Add(Element);
                }
                else
                {
                    if (temp.prev == null) //neues Element wird zum ersten Element der Liste
                        AddFirst(Element);
                    else
                    {
                        newElement.next = temp;         //neues Element bekommt als Nachfolger das nächstgrößeres Element
                        newElement.prev = temp.prev;    //neues Element bekommt als Vorgänger den Vorgänger vom nächstgrößeren Element
                        temp.prev.next = newElement;    //der Vorgänger des nächstgrößeren Element bekommt nun das neue Element als Nachfolger
                        temp.prev = newElement;         //vom nächstgrößeren Element wird der Vorgänger nun das neue Element
                    }
                }
            }
        }

        /// <summary>
        /// Sucht nach den nächstgrößeren Element in der Liste
        /// </summary>
        /// <param name="Element"></param>
        /// <returns>Element</returns>
        private LinkedListNode lookingForNextBiggerElement(int Element)
        {
            LinkedListNode lfd = Root; //lfd wird auf Startelement gesetzt

            while (lfd != null)
            {
                if (lfd.elem.elemValue < Element)   //wenn Elemend von lfd kleiner das zähle weiter 
                {
                    lfd = lfd.next;
                }
                else
                    return lfd;
            }

            return lfd;
        }

        /// <summary>
        /// Löschen eines Elements, überschreibt privateDelete von der Basis
        /// </summary>
        /// <param name="Element">zulöschendes Element</param>
        /// <returns>true wenn gelöscht ansonsten false</returns>
        protected override bool privateDelete(LinkedListNode Element)
        {
            bool result = base.privateDelete(Element);

            if (Element != null)
            {
                if (Element.next != null && Element.next.elem.elemValue == Element.elem.elemValue) //wenn nächstes Element wieder das zulöschende Element ist, dann löschen
                {
                    privateDelete(Element.next); //rekursiver Aufruf
                }

                if ((Element.prev != null && Element.prev.elem.elemValue == Element.elem.elemValue)) //wenn vorheriges Element auch zulöschendes Element ist, dann löschen
                {
                    privateDelete(Element.prev); //rekursiver Aufruf
                }
            }

            return result;
        }


        /// <summary>
        /// Sucht nach dem Element in der Liste, betrachtet dabei nur jedes zweites Element
        /// </summary>
        /// <param name="Element">zusuchendes Element</param>
        /// <returns>true  falls gefunden, ansonsten false</returns>
        protected override LinkedListNode privatesearch(int Element)
        {
            LinkedListNode lfd = null;

            if (Root == null || Element < Root.elem.elemValue || Element > Last.elem.elemValue) //Liste leer oder Element ist kleiner als erstes Element oder Element ist größer als das letzte Element
            {
                return null;
            }

            if (Root.elem.elemValue == Element) //Element ist Startelement
                return Root;

            if (Last.elem.elemValue == Element) //Element ist letztes Element
                return Last;

            lfd = Root;
            do
            {
                if (lfd.elem.elemValue < Element)   //Element des lfd ist kleiner als gesuchtes Element
                {
                    if (lfd.next.next != null)  //prüfen ob das übernächste element nicht leer ist
                    {
                        lfd = lfd.next.next; //dann den lfd aufs übernächste Element setzen
                    }
                    else
                    {
                        lfd = lfd.next;
                    }
                }
                else  //lfd sein Element ist nicht kleiner als gesuchtes Element
                {
                    if (lfd.elem.elemValue == Element)  //prüfen ob lfd sein element gleich den zusuchenden element ist
                        return lfd;
                    else if (lfd.prev.elem.elemValue == Element) //falls nicht prüfen ob das elemnt davor den zusuchenden elemnt entspricht
                        return lfd.prev;
                    else
                        lfd = null;     //falls auch nicht lfd auf null setzen
                }
            } while (lfd != null);

            return lfd;
        }
    }
}
