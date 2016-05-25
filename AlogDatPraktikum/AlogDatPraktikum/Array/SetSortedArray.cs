using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class SetSortedArray : SortedArray, SortedSet
    {
        static private int ArraySize = 20;
        int negative;
        private int[] SetSorted;

        public SetSortedArray(int size)
        {
            int counter = -size;
            negative = -size;
            SetSorted = new int[ArraySize];
            for (int i = 0; i < ArraySize; i++)
            {
                SetSorted[i] = counter;
                counter++;
            }
        }
    
        public bool Delete(int elem)
        {
            bool outcome = false;
            int position = base.PrivateSearch(elem, SetSorted);
            if (SetSorted[position]== elem)
            {
                negative--;
                outcome = PrivateDelete(ref SetSorted, position, negative);
            }
            return outcome;
        }

        public bool Insert(int elem)
        {
            int position = PrivateSearch(elem, SetSorted);
            bool outcome = false;
            if (SetSorted[position] != elem)
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
            else if (SetSorted[position] == elem)
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
