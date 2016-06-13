using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
   abstract class UnsortedLinkedList : BaseList
    {
        /// <summary>
        /// Fügt neues Element immer hinten an, da es sich um eine unsortierte Liste handelt
        /// </summary>
        /// <param name="Element">hinzufügendes Element</param>
        //public override void Add(int Element)
        //{
        //    if (Root == null) //Wenn liste leer, dann AddFirst
        //    {
        //        AddFirst(Element);
        //    }
        //    else
        //    {
        //        Last.next = new LinkedListNode { elem = new DictElement(Element) }; //Last sein next wird neues element
        //        Last.next.prev = Last;                                              //das neue Element bekommt den zuletzen Last als Vorgänger
        //        Last = Last.next;                                                   //das neue Element als Last setzen
        //    }
        //}
    }
}
