using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class MultiSetSortedArray : SortedArray, SortedMultiSet
    {
        private int[] MultiSetSorted;

        public MultiSetSortedArray(int size)
        {
            MultiSetSorted = new int[size];
            for (int i = 0; i < size; i++)
            {
                MultiSetSorted[i] = -1;
            }
        }

        public bool Delete(int elem)
        {
            bool outcome = false;
            while(Search(elem))
            {
                int position = base.PrivateSearch(elem, MultiSetSorted);
                if (MultiSetSorted[position] == elem)
                {
                    outcome = PrivateDelete(ref MultiSetSorted, position);
                }
            }
            return outcome;
        }

        public bool Insert(int elem)
        {
            int position = PrivateSearch(elem, MultiSetSorted);
            bool outcome = false;
            outcome = PrivateInsert(elem,ref MultiSetSorted, position);
            return outcome;

        }

        public void Print()
        {
            base.Print(MultiSetSorted);
        }

        public bool Search(int elem)
        {
            int position = base.PrivateSearch(elem, MultiSetSorted);
            if (position == -1)
            {
                return false;
            }
            else if (MultiSetSorted[position] == elem)
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
