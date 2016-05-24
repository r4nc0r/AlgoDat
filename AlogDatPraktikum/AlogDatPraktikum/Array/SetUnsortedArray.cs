using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class SetUnsortedArray : UnsortedArray, Set
    {
        int arrayLength = 20;
        int[] SetUnsorted;
        public SetUnsortedArray()
        {
            SetUnsorted = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                SetUnsorted[i] = -1;
            }
        }
        
        public bool Delete(int elem)
        {
           return base.Delete(elem, SetUnsorted);
        }

        public bool Insert(int elem)
        {
            if (base.privateSearch(elem, SetUnsorted) == -1)
            {
                int insertPosition = base.insertSearch(SetUnsorted);
                if (insertPosition != -1)
                {
                    SetUnsorted[insertPosition] = elem;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }

            

        }

        public void Print()
        {
            base.Print(SetUnsorted);
        }

        public bool Search(int elem)
        {
            if (base.privateSearch(elem, SetUnsorted) == elem)
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
