using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class MultiSetUnsortedArray : UnsortedArray, MultiSet
    {
        DictElement[] MultiSetUnsorted;
        private int ExistingElements, arrayLength;//ExistingElements ist ein Counter für die vorhandenen Elemente, arrayLength spiegelt die größe des Arrays wieder


        public MultiSetUnsortedArray()
        {
            Console.Write("Größe angeben:");
            arrayLength = Console.Read();
            MultiSetUnsorted = new DictElement[arrayLength];

            ExistingElements = 0;
            MultiSetUnsorted = initArray(MultiSetUnsorted);
        }

        public bool Delete(int elem)
        {
            while (Search(elem))
            {
                return base.Delete(elem, ref MultiSetUnsorted, ref ExistingElements);
            }
            return false;
            
        }

        public bool Insert(int elem)
        {
            return Insert(elem, ref MultiSetUnsorted, ref ExistingElements);
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
