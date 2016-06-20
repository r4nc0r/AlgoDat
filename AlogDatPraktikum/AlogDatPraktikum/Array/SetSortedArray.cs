using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class SetSortedArray : SortedArray, SortedSet
    {
        private DictElement[] SetSorted;
        public SetSortedArray(int size)
        {
            SetSorted = new DictElement[size];

            SetSorted = initArray(SetSorted);
        }
    
        public bool Delete(int elem)
        {
            bool outcome = false;
            int position = base.PrivateSearch(elem, SetSorted);
            if (SetSorted[position].elemValue == elem)
            {
                outcome = PrivateDelete(ref SetSorted, position);
            }
            return outcome;
        }

        public bool Insert(int elem)
        {
            int position = PrivateSearch(elem, SetSorted);
            bool outcome = false;
            if (position < SetSorted.Length -1 && SetSorted[position].elemValue != elem)
            {
                outcome = PrivateInsert(elem,ref SetSorted, position);
            }
            return outcome;
            
        }

        public void Print()
        {
            base.Print(SetSorted);
        }
   
        public bool Search(int elem)
        {
            int position= base.PrivateSearch(elem, SetSorted);
            if ( position == -1)
            {
                return false;
            }
            else if (SetSorted[position].elemValue == elem)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
