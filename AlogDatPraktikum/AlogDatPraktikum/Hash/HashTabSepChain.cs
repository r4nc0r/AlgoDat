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
        /// Konstruktor fragt naach anzulegender Tabellengröße und prüft ob es sich um eine Primzahl handelt.
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
                //sucht an der Stelle wo der Wert stehen sollte und löscht diesen falls vorhanden, 
                //nutzt dazu die Methoden der SetUnsortedLinkedList
                bool flag= hashChain[hashvalue].Delete(elem);
                //Falls Liste nach dem löschen eines Elements leer, dann Eintrag in HashChain auf Null setzten
                if (hashChain[hashvalue].Root == null)
                    hashChain[hashvalue] = null;
                return flag;
            }
                return false;
        }

        /// <summary>
        /// 1.Hashwert anhand des Keys berechene
        /// 2.  und in Array einfügen, wenn an der Stelle schon ein Wert steht
        ///     wird eine Liste SetUnsortedLinkedList an diesem Platz erstellt und der einzufügende Wert
        ///     am Ende der jeweiligen Liste angehängt
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
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
            for (int i = 0; i < hashChain.Length; i++)
            {
                if (hashChain[i] != null)
                {
                    Console.Write("Key: {0} Values: ",i);
                    hashChain[i].Print();
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// berechent den Hashwert, und sucht an dieser Stelle
        /// sollten mehrere Werte unter dem gleichen Key abgelgt worden sein 
        /// wird die Liste für diesen Key durchsucht
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public bool Search(int elem)
        {
            int hashvalue = base.hashfuntion(elem,TabLength);
            if (hashChain[hashvalue] != null)
                return hashChain[hashvalue].Search(elem);
            return false;
        }
    }
}
