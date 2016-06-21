using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    abstract class SortedArray : BaseArray
    {
        /// <summary>
        /// Deletes an Element of an Array
        /// Shifts array to left so order remains preserved
        /// </summary>
        /// <param name="array"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool PrivateDelete(ref DictElement[] array, int position)
        {
            ShiftArrayLeft(array,array.Length-2, position);
            array[array.Length -1].elemValue = -1;
            return true;
        }

        /// <summary>
        /// Binary Search
        /// if Element is not found, insert position is returned
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public int PrivateSearch(int elem, DictElement[] array)
        {
            
            int i;
            int l = 0;
            int r = array.Length - 1;
            int position = -1;

            while(position == -1 && l <= r )
            {
                i = (l + r) / 2;
                if (array[i].elemValue < elem && array[i].elemValue != -1 )
                {
                    l = i + 1;
                }
                else if (array[i].elemValue > elem || array[i].elemValue == -1)
                {
                    r = i - 1;
                }
                if (array[i].elemValue == elem)
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

        /// <summary>
        /// Inserts an given Element into an Array at an given position
        /// If Existing Element at Position is bigger array will be shifted to right
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="array"></param>
        /// <param name="position"></param>
        /// <returns>if Insert is successfull</returns>
        public bool PrivateInsert(int elem,ref DictElement[] array, int position)
        {
            if (position == -1 || position + 1 > array.Length)
            {
                return false;
            }
            if (array[position].elemValue > elem || array[position].elemValue == elem)
            {
                array = ShiftArrayRight(array, array.Length -1,position);
            }
            
            array[position].elemValue = elem;
            return true;
        }

    }
    
}
