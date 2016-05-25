using System;
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
           return base.DeleteAllSameElements(elem);
        }

        public bool Insert(int elem)
        {
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
