using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class MultiSetUnsortedLinkedList : UnsortedLinkedList, MultiSet
    {
        public bool Delete(int elem)
        {
            return base.Delete(elem);
        }

        public bool Insert(int elem)
        {
            base.Add(elem);
            return true;
        }

        public void Print()
        {
            base.Print();
        }

        public bool Search(int elem)
        {
            return base.search(elem);
        }
    }
}
