using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class HashTabSepChain : BaseHash, Set
    {

        SetUnsortedLinkedList[] hashChain;
        private int TabLength;
        /// <summary>
        /// Problem noch mit basisklassen konstruktor, es wird immer ein basehash tabelle erstellt
        /// hab noch keine idee das zu umgehen
        /// </summary>
        public HashTabSepChain()
        {
            Console.WriteLine("wie groß soll die Hashtabelle sein?");
            Console.Write("Bitte geben Sie eine Primzahl ein ");
            int inp = Convert.ToInt32(Console.ReadLine());

            TabLength = calcNextPrim(inp);
            hashChain = new SetUnsortedLinkedList[TabLength];
        }

        public bool Delete(int elem)
        {
            int hashvalue = base.hashfuntion(elem, TabLength);
            if (hashChain[hashvalue] != null)
            {
                bool flag= hashChain[hashvalue].Delete(elem);
                //Falls Liste nach dem löschen eines Elements leer, dann Eintrag in HashChain auf Null setzten
                if (hashChain[hashvalue].Root == null)
                    hashChain[hashvalue] = null;
                return flag;
            }
                return false;
        }

        public override bool Insert(int elem)
        {
            int hashValue = base.hashfuntion(elem,TabLength);
            if (hashChain[hashValue]==null)
            {
                hashChain[hashValue] = new SetUnsortedLinkedList();
            }
            hashChain[hashValue].Insert(elem);
            return true;
        }

        public override void Print()
        {
            foreach (SetUnsortedLinkedList item in hashChain)
            {
                if (item != null)
                {
                    item.Print();
                    Console.WriteLine();
                }
            }
        }

        public bool Search(int elem)
        {
            int hashvalue = base.hashfuntion(elem,TabLength);
            if (hashChain[hashvalue] != null)
                return hashChain[hashvalue].Search(elem);
            return false;
        }
    }
}
