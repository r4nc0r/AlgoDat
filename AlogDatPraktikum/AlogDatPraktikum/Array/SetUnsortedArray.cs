using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class SetUnsortedArray : UnsortedArray, Set
    {
        DictElement[] SetUnsorted;
        private int ExistingElements;

        public SetUnsortedArray(int size)
        {
            SetUnsorted = new DictElement[size];

            ExistingElements = 0;

            SetUnsorted = initArray(SetUnsorted);
        }
        
        public bool Delete(int elem)
        {
            return base.Delete(elem, ref SetUnsorted, ref ExistingElements);
        }

        public bool Insert(int elem)
        {
            if (base.privateSearch(elem, SetUnsorted) == -1)
            {
                return Insert(elem, ref SetUnsorted, ref ExistingElements);
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
