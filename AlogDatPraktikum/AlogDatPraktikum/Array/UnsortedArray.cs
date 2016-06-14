using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    abstract class UnsortedArray : BaseArray
    {

        public virtual int insertSearch(DictElement[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].elemValue == -1)
                {
                    return i;
                }
            }
            return -1;
        }
        public virtual int privateSearch (int elem,  DictElement[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].elemValue == elem)
                {
                    return i;
                }
            }
            return -1;
        }
        public bool Delete(int elem,ref DictElement[] array,ref int ExistingElements)
        {
            int deletePosition = privateSearch(elem, array);
            if (deletePosition != -1)
            {
                array[deletePosition].elemValue = array[ExistingElements].elemValue;
                array[ExistingElements].elemValue = -1;
                ExistingElements--;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Insert(int elem, ref DictElement[] array, ref int ExistingElements)
        {
            if (array[ExistingElements].elemValue == -1)
            {
                array[ExistingElements].elemValue = elem;
                ExistingElements++;
                return true;
            }
            else
                return false;
        }
    }
}
