using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class HashTabQuadProb : BaseHash, Set
    {
        DictElement[] hashTab;
        int TabLength, freespace;
        public HashTabQuadProb()
        {
            Console.WriteLine("wie groß soll die Hashtabelle mindestens sein?");
            Console.Write("Bitte geben Sie eine Primzahl ein ");
            int inp = Convert.ToInt32(Console.ReadLine());


            TabLength = calcNextPrim(inp);
            hashTab = new DictElement[TabLength];
            Console.WriteLine(TabLength);
            initHashTab();
        }
        /// <summary>
        /// initiailisiert alle Einträge der Hashtabelle auf -1
        /// </summary>
        private void initHashTab()
        {
            for (int i = 0; i < hashTab.Length; i++)
            {
                hashTab[i] = new DictElement(-1);
            }
        }

        public bool Delete(int elem)
        {
            int pos = privSearch(elem);
            if (pos == -1 )
                return false;

            hashTab[pos].elemValue = -1;
                return true;
            
            
        }

        public override bool Insert(int elem)
        {
            for (int i = 0; i < TabLength; i++)
            {
                int pos = calcHash(elem, i, TabLength);
                if(pos < 0)
                {
                    Console.WriteLine("Kein Speicherplatz vorhanden");
                    return false;
                }
                if (hashTab[pos].elemValue == elem)
                { return false; }
                if (hashTab[pos].elemValue == -1)
                {
                    freespace--;
                    hashTab[pos].elemValue = elem;
                    return true;
                }
            }

            return false;
        }

        public override void Print()
        {
            for (int i = 0; i < hashTab.Length; i++)
            {
                if (hashTab[i].elemValue > -1)
                    Console.WriteLine("Key {0}, Index: {1}", hashTab[i].elemValue, i);
            }
        }

        public bool Search(int elem)
        {
            int pos = privSearch(elem);
            if (pos!=-1 && hashTab[pos].elemValue != -1)
                return true;
            return false;
        }

        private int privSearch(int elem)
        {
            for (int i = 0; i < TabLength; i++)
            {
             
                int pos = calcHash(elem, i, TabLength);
                if (pos < 0)
                {
                    return -1;
                }
                if (hashTab[pos].elemValue == elem)
                    return pos;
            }
            return -1;
        }

        public override int calcNextPrim(int Input)
        {

            Input = base.calcNextPrim(Input);
            while (Input % 4 != 3)
            {
                Input += 2;
                Input = base.calcNextPrim(Input);

            } 

            return Input;
        }
    
       

        private int calcHash(int Element, int j, int c)
        {

            int mult = (int)(Math.Ceiling(j  / 2.0));
            mult = mult * mult;
            int temp = hashfuntion(Element, c) + (int)(Math.Pow(-1, (j + 1)) * mult);

            if (temp <= -1)
            {
                int ring = (temp * -1 )/ c + 1;
                temp = temp + c*ring;
            }
            return temp = hashfuntion(temp ,TabLength);
     
        }
    }
}

