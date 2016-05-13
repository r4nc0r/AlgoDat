﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class SetUnsortedLinkedList : UnsortedLinkedList, Set
    {
        public bool Delete(int elem)
        {
            return base.Delete(elem);
        }

        public bool Insert(int elem)
        {
            if (privatesearch(elem) == null)
            {
                Add(elem);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            base.Print();
        }

        public bool Search(int elem)
        {
            return base.search(elem);
        }

        
    }
}
