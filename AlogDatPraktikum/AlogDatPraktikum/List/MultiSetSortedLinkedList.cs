﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class MultiSetSortedLinkedList : SortedLinkedList, SortedMultiSet
    {
        public new bool Delete(int elem)
        {
           return base.Delete(elem);
        }

        public bool Insert(int elem)
        {
            //int index = 0;
            //LinkedListNode lfd = Root;
            
            ////Liste ist noch leer
            //if (lfd == null)
            //{
            //    AddFirst(elem);
            //    return true;
            //}
            
            ////durchlaufe liste und prüfe ob Element größer als neues Element, falls ja füge neues element davor hinzu
            //while (lfd != null)
            //{
            //    if (lfd.elem > elem)
            //    {
            //        AddAtInd(elem, index);
            //        return true;
            //    }
            //    lfd = lfd.next;
            //    index++;
            //}

            //wurde neues Element in der While-Schleife nicht hinzugefügt, dann ist es noch nicht vorhanden füge es am Ende hinzu
            Add(elem);
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
    }
}
