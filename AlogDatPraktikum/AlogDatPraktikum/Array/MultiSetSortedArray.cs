using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class MultiSetSortedArray : SortedArray, SortedMultiSet
    {
        private DictElement[] MultiSetSorted;

        /// <summary>
        /// Constructor
        /// Initiates Array
        /// </summary>
        /// <param name="size"></param>
        public MultiSetSortedArray(int size)
        {
            MultiSetSorted = new DictElement[size];

            MultiSetSorted = initArray(MultiSetSorted);
        }

        public bool Delete(int elem)
        {
            bool outcome = false;
            while(Search(elem))
            {
                int position = base.PrivateSearch(elem, MultiSetSorted);
                if (MultiSetSorted[position].elemValue == elem)
                {
                    outcome = PrivateDelete(ref MultiSetSorted, position);
                }
            }
            return outcome;
        }

        public bool Insert(int elem)
        {
            int position = PrivateSearch(elem, MultiSetSorted);
            bool outcome = false;
            outcome = PrivateInsert(elem,ref MultiSetSorted, position);
            return outcome;

        }

        public void Print()
        {
            base.Print(MultiSetSorted);
        }

        public bool Search(int elem)
        {
            int position = base.PrivateSearch(elem, MultiSetSorted);
            if (position == -1)
            {
                return false;
            }
            else if (MultiSetSorted[position].elemValue == elem)
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
