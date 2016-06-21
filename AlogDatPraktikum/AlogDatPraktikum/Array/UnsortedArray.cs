using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    abstract class UnsortedArray : BaseArray
    {

        /// <summary>
        /// Searches the array for next free Element(inefficient and not recommended)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Searches an Array for an given Element
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="array"></param>
        /// <returns>Position or -1 if not found</returns>
        public virtual int privateSearch (int elem,  DictElement[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].elemValue == -1)
                {
                    return -1;
                }
                if (array[i].elemValue == elem)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Deletes an given Element out of an Array
        /// uses PrivateSearch for Position Search and if element is found
        /// it is replaced with the last Existin Element of the Array
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="array"></param>
        /// <param name="ExistingElements"></param>
        /// <returns>if Delete is successfull</returns>
        public bool Delete(int elem,ref DictElement[] array,ref int ExistingElements)
        {
            int deletePosition = privateSearch(elem, array);
            if (deletePosition != -1)
            {
                array[deletePosition].elemValue = array[ExistingElements-1].elemValue;
                array[ExistingElements-1].elemValue = -1;
                ExistingElements--;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Inserts an given Element into an Array
        /// If Array is full --> Unsuccesfull
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="array"></param>
        /// <param name="ExistingElements"></param>
        /// <returns>If Insert is successfull</returns>
        public bool Insert(int elem, ref DictElement[] array, ref int ExistingElements)
        {
			if (ExistingElements == array.Length)
			{
				return false;
			}
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
