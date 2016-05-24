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
        private int[] SetSorted;
        public SetSortedArray()
        {
            int counter =-20;
            SetSorted = new int[ArraySize];
            for (int i = 0; i < ArraySize; i++)
            {
                SetSorted[i] = counter;
                counter++;
            }
        }
    
        public bool Delete(int elem)
        {
            int position = base.PrivateSearch(elem, SetSorted);
            if (position== elem)
            {
                int tempPosition = position;
                for (int i = 0; i < ArraySize - position - 1; i++)
                {
                    SetSorted[tempPosition] = SetSorted[tempPosition + 1];
                    tempPosition = tempPosition + 1;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Insert(int elem)
        {
            int position = base.PrivateSearch(elem, SetSorted);

            if (position+ 1 > ArraySize)
            {
                return false;
            }

            if (position == 19)
            {
                if (IsSpaceAvailable(SetSorted))
                {
                    SetSorted = ShiftArrayLeft(SetSorted);
                }
                else
                {
                    return false;
                }
            }

            if (position == -1 || SetSorted[position] == elem)
            {
                return false;
            }
            else
            {
                int tempposition = position;
                for (int i = ArraySize-position- 1; i > position; i--)
                {
                    SetSorted[i] = SetSorted[i-1];
                    tempposition--;
                }
                
                SetSorted[position] = elem;
                return true;

            }
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
