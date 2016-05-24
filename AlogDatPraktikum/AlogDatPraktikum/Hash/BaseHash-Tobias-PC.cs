using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class BaseHash 
    {
        public int TabLength=5;

        int[] HashTab;

        public BaseHash()
        {
            Console.WriteLine("wie groß soll die Hashtabelle sein?");
            Console.Write("Bitte geben Sie eine Primzahl ein ");
            int inp = Convert.ToInt32(Console.ReadLine());

            while (!isPrim(inp)) ;
            {
                Console.Write("Bitte geben Sie eine Primzahl ein ");
                inp = Convert.ToInt32(Console.ReadLine());
            }
            TabLength = inp;
            HashTab = new int[TabLength];
            initHashTab();
        }

        private void initHashTab()
        {
            for (int i = 0; i < HashTab.Length; i++)
            {
                HashTab[i] = -1;
            }
        }
        private bool isPrim(int Input)
        {
            bool flag = false;
            int i = Input;
            while (!flag)
            {
                int n = 2;
                // Schleife ueber alle moeglichen Teiler n des Primzahlkandidaten i:
                while (i % n != 0 && n <= i / 2)
                {
                    n++;
                }
                // Falls die Schleife bis zur Obergrenze i/2 durchlaufen wurde:
                if (n >= i / 2 + 1 && i != 1)
                {
                    flag = true;
                }
            }
            return flag;
        }
        protected int hashfuntion(int Element)
        {
            int hashKey = Element % TabLength;
            return hashKey;
        }

        public int DeleteAnItem(int Element)
        {
            int pos = hashfuntion(Element);
            if (pos != 0)
            {
                HashTab[pos] = 0;     
            }
            return pos;
        }

        /// <summary>
        /// Wenn eine Zelle schon belegt, wird sie bei einer Kollision nicht überschrieben
        /// </summary>
        /// <param name="Element"></param>
        /// <returns></returns>
        public bool Insert(int Element)
        {
            int hashvalue = hashfuntion(Element);
            if (HashTab[hashvalue] == -1)
            {
                HashTab[hashvalue] = Element;
                return true;
            }
            else
            {
                Console.WriteLine("Kollision beim einfügen von {0} an der Stelle {1}", Element, hashvalue);
                return false;
            }
        }

        public void PrintAll()
        {
            foreach (int item in HashTab)
            {
                Console.WriteLine(item);
            }
        }

        public void Print()
        {
            for (int i = 0; i < HashTab.Length; i++)
            {
                if(HashTab[i] >-1)
                Console.WriteLine("Key {0}, Index: {1}" ,HashTab[i],i);
            }
        }

    }
}
