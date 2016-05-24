using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class MultiSetSortedArray : SortedArray, SortedMultiSet
    {
        static private int ArraySize = 20;
        int negative;
        private int[] MultiSetSorted;

        public MultiSetSortedArray(int size)
        {
            int counter = -size;
            negative = -size;
            MultiSetSorted = new int[ArraySize];
            for (int i = 0; i < ArraySize; i++)
            {
                MultiSetSorted[i] = counter;
                counter++;
            }
        }

        public bool Delete(int elem)
        {
            bool outcome = false;
            int position = base.PrivateSearch(elem, MultiSetSorted);
            if (MultiSetSorted[position] == elem)
            {
                negative--;
                outcome = PrivateDelete(MultiSetSorted, position, negative);
            }
            return outcome;
        }

        public bool Insert(int elem)
        {
            int position = PrivateSearch(elem, MultiSetSorted);
            bool outcome = false;
            outcome = PrivateInsert(elem, MultiSetSorted, position);
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
