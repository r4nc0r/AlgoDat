using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    abstract class UnsortedArray : BaseArray
    {
        public virtual int insertSearch(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == -1)
                {
                    return i;
                }
            }
            return -1;
        }
        public virtual int privateSearch (int elem,  int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == elem)
                {
                    return i;
                }
            }
            return -1;
        }
        public bool Delete(int elem, int[] array)
        {
            int deletePosition = privateSearch(elem, array);
            if (deletePosition != -1)
            {
                array[deletePosition] = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
