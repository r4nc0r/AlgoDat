using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class MultiSetUnsortedArray : UnsortedArray, MultiSet
    {
        int arrayLength = 20;
        int[] MultiSetUnsorted;
        public MultiSetUnsortedArray()
        {
            MultiSetUnsorted = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                MultiSetUnsorted[i] = -1;
            }
        }

        public bool Delete(int elem)
        {
            return base.Delete(elem, MultiSetUnsorted);
        }

        public bool Insert(int elem)
        {
                int insertPosition = base.insertSearch(MultiSetUnsorted);
                if (insertPosition != -1)
                {
                    MultiSetUnsorted[insertPosition] = elem;
                    return true;
                }
                else
                    return false;
        }

        public void Print()
        {
            base.Print(MultiSetUnsorted);
        }

        public bool Search(int elem)
        {
            if (base.privateSearch(elem, MultiSetUnsorted) == elem)
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
