using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    abstract class SortedArray : BaseArray
    {
        public bool PrivateDelete(ref int[] array, int position, int negative)
        {
            ShiftArrayRight(array,position, 0);
            array[0] = negative;
            return true;
        }

        public int PrivateSearch(int elem, int[] array)
        {
            
            int i;
            int l = 0;
            int r = array.Length - 1;
            int position = -1;

            while(position == -1 && l <= r )
            {
                i = (l + r) / 2;
                if (array[i] < elem )
                {
                    l = i + 1;
                }
                else if (array[i] > elem)
                {
                    r = i - 1;
                }
                if (array[i] == elem)
                {
                    while (array[i + 1] == array[i])
                    {
                        if (i == array.Length-2)
                        {
                            break;
                        }
                        i++;
                    }
                    position = i;
                }
            }


            if (position == -1)
            {
                int x;
                for (x= 0; x < array.Length-1; x++)
                {
                    if (elem <0 && array[x+1]>elem )
                    {
                        return x;
                    }
                    if (array[x] < elem && array[x+1] > elem)
                    {

                        return x;
                    }
                    if (x == array.Length -2)
                    {
                        return x + 1;
                    }
                }

            }
            return position;
        }

        public bool PrivateInsert(int elem,ref int[] array, int position)
        {
            if (position == -1 || position + 1 > array.Length)
            {
                return false;
            }

            if (IsSpaceAvailable(array))
            {
                array = ShiftArrayLeft(array, 0,0);
            }
            
            if (array[position] > elem)
            {
                array = ShiftArrayRight(array, array.Length -1,position);
            }
            
            array[position] = elem;
            return true;
        }

    }
    
}
