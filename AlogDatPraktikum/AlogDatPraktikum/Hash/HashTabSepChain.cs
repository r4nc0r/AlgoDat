using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class HashTabSepChain : BaseHash, Set
    {
        
        SetUnsortedLinkedList[] hashChain = new SetUnsortedLinkedList[TabLength];

        public bool Delete(int elem)
        {
            throw new NotImplementedException();
        }

        public bool Insert(int elem)
        {
            int hashValue = base.hashfuntion(elem);
            if (hashChain[hashValue]==null)
            {
                hashChain[hashValue] = new SetUnsortedLinkedList();
            }
            hashChain[hashValue].Add(elem);
            return true;
        }

        public void Print()
        {
            
            throw new NotImplementedException();
        }

        public bool Search(int elem)
        {
            throw new NotImplementedException();
        }
        
    }
}
