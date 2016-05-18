using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class BaseHash 
    {
        public static int TabLength = 2048;

        //public int ChainLength { get { return TabLength; } }

        int[] HashTab = new int[TabLength];
 
        private double calculateC()
        {
            return  1/(0.5 * (1 + Math.Sqrt(5)));
        }

        protected int hashfuntion(int Element)
        {
            int hashKey;
            double c = calculateC();
            double temp = Element * c;
            hashKey = (int)((temp - Math.Truncate(temp)) *TabLength);

            return hashKey;
        }

        public bool Insert(int Element)
        {
            int temp = hashfuntion(Element);
            if (HashTab[temp] == 0)
            {
                HashTab[temp] = Element;
                return true;
            }
            else
                return false;

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
                if(HashTab[i]!=0)
                Console.WriteLine("Key {0}, Index: {1}" ,HashTab[i],i);
            }
        }
    }
}
