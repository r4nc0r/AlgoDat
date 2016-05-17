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
            int counter = 2000;
            SetSorted = new int[ArraySize];
            for (int i = 0; i < ArraySize; i++)
            {
                SetSorted[i] = counter;
                counter++;
            }
        }
    
        public bool Delete(int elem)
        {
            int position = PrivateSearch(elem);
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

            int position = PrivateSearch(elem);

            if (position+ 1 > ArraySize)
            {
                return false;
            }


            if (SetSorted[position]== elem)
            {
                return false;
            }
            else
            {
                int tempPosition = position;
                int tempInt;
                for (int i = 0; i < (ArraySize - position); i++)
                {
                    tempInt = SetSorted[i + 1];
                    SetSorted[i + 1] = SetSorted[i];

                }
                
                SetSorted[position] = elem;
                return true;

            }
        }

        public void Print()
        {
            for (int i = 0; i < SetSorted.Length; i++)
            {
                Console.WriteLine(SetSorted[i]);
            }
        }

        private int PrivateSearch(int elem)
        {
         
            int i;
            int l = 0;
            int r = ArraySize - 1;

            do
            {
                i = (l + r) / 2;
                if (SetSorted[i] < elem)
                {
                    l = i + 1;
                }
                else
                {
                    r = i - 1;
                }

            } while (SetSorted[i] != elem && l < r);
            
            
            if (SetSorted[i] == elem)
            {
                return i;
            }
            else
            { 
               
                while (i < r && SetSorted[i] < elem)
                    i++;
                i--;
                return i;
                
            }
           

        }
        public bool Search(int elem)
        {
            if (PrivateSearch(elem) == elem)
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
