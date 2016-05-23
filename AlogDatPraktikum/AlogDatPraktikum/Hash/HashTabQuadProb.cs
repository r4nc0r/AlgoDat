using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class HashTabQuadProb : BaseHash, Set
    {
        int[] hashTab;
        int TabLength;
        public HashTabQuadProb()
        {
            Console.WriteLine("wie groß soll die Hashtabelle mindestens sein?");
            Console.Write("Bitte geben Sie eine Primzahl ein ");
            int inp = Convert.ToInt32(Console.ReadLine());

            TabLength = calcNextPrim(inp);
            hashTab = new int[TabLength];
            Console.WriteLine(TabLength);
            initHashTab();
        }
        private void initHashTab()
        {
            for (int i = 0; i < hashTab.Length; i++)
            {
                hashTab[i] = -1;
            }
        }

        public bool Delete(int elem)
        {
            int pos = hashTab[privSearch(elem)];
            if (hashTab[pos] != -1)
            {
                hashTab[pos] = -1;
                return true;
            }
                return false;
        }

        public override bool Insert(int elem)
        {
            for (int i = 0; i < TabLength; i++)
            {
                int pos = calcHash(elem, i, TabLength);
                if (hashTab[pos] == elem)
                { return false; }
                if (hashTab[pos] == -1)
                {
                    hashTab[pos] = elem;
                    return true;
                }
            }

            return false;
        }

        public override void Print()
        {
            for (int i = 0; i < hashTab.Length; i++)
            {
                if (hashTab[i] > -1)
                    Console.WriteLine("Key {0}, Index: {1}", hashTab[i], i);
            }
        }

        public bool Search(int elem)
        {
            if (hashTab[privSearch(elem)] != -1) 
                return true;
            return false;
        }

        private int privSearch(int elem)
        {
            for (int i = 0; i < TabLength; i++)
            {
                int pos = calcHash(elem, i, TabLength);
                if (hashTab[pos] == elem)
                    return pos;
                else if (hashTab[pos] == -1)
                    return -1;
            }
            return -1;
        }

        public override int calcNextPrim(int Input)
        {
            bool flage = false;
            if (Input % 2 == 0)
                Input++;
            while (!flage)//(isPrim(Input)!=true && !(Input % 4 != 3))
            {
                if(isPrim(Input))
                {
                    if (Input % 4 == 3)
                    {
                        flage = true;
                        return Input;
                    }
                }
               
                    Input = Input + 2;
            }
                return Input;
        }
    
        //private int calculateC(int Min)
        //{
        //    bool flag = false;
        //    int i = Min;
        //    while (!flag)
        //    {
        //        int n = 2;

        //        // Schleife ueber alle moeglichen Teiler n des Primzahlkandidaten i:
        //        while (i % n != 0 && n <= i / 2 && i % 4 == 3)
        //        {
        //            n++;
        //        }
        //        // Falls die Schleife bis zur Obergrenze i/2 durchlaufen wurde:
        //        if (n >= i / 2 + 1 && i != 1)
        //        {
        //            Console.WriteLine(" Tabellenlänge=" + i);
        //            flag = true;
        //            return i;
        //        }
        //        i++;
        //    }
        //    throw new NullReferenceException("keine Primzahl der gewünschten Form berechenbar");
        //}

        private int calcHash(int Element, int j, int c)
        {
            int mult = (int)(Math.Ceiling(j / 2.0));
            int temp = hashfuntion(Element, c) + (int)(Math.Pow(-1, (j + 1)) * mult);
         
            if(temp<=-1)
            {
                temp = temp + c;
            }
            return temp = hashfuntion(temp ,TabLength);
     
        }
    }
}

