using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    abstract class SortedArray : BaseArray
    {
        public bool PrivateDelete(ref int[] array, int position)
        {
            ShiftArrayLeft(array,array.Length-2, position);
            array[array.Length -1] = -1;
            return true;
        }

        /// <summary>
        /// Binär Suche 
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public int PrivateSearch(int elem, int[] array)
        {
            
            int i;
            int l = 0;
            int r = array.Length - 1;
            int position = -1;

            while(position == -1 && l <= r )
            {
                i = (l + r) / 2;
                if (array[i] < elem && array[i] != -1 )
                {
                    l = i + 1;
                }
                else if (array[i] > elem || array[i] == -1)
                {
                    r = i - 1;
                }
                if (array[i] == elem)
                {
                    if (i != array.Length-1)
                    {
                        while (array[i + 1] == array[i])
                        {
                            if (i == array.Length - 2)
                            {
                                break;
                            }
                            i++;
                        }
                    }

                    position = i;
                }
            }


            if (position == -1)
            {
                position = r + 1;
            }
            return position;
        }

        public bool PrivateInsert(int elem,ref int[] array, int position)
        {
            if (position == -1 || position + 1 > array.Length)
            {
                return false;
            }
            
            if (array[position] > elem || array[position] == elem)
            {
                array = ShiftArrayRight(array, array.Length -1,position);
            }
            
            array[position] = elem;
            return true;
        }

    }
    
}
