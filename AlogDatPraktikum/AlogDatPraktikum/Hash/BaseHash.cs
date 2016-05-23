using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    abstract class BaseHash 
    {
        //public int TabLength;


        //public BaseHash()
        //{
        //    Console.WriteLine("wie groß soll die Hashtabelle sein?");
        //    Console.Write("Bitte geben Sie eine Primzahl ein ");
        //    int inp= Convert.ToInt32(Console.ReadLine());

        //    while(!isPrim(inp));
        //    {
        //        Console.Write("Bitte geben Sie eine Primzahl ein ");
        //        inp = Convert.ToInt32(Console.ReadLine());
        //    }
        //    TabLength = inp;
        //    HashTab = new int[TabLength];
        //    initHashTab();
        //}

        //private void initHashTab()
        //{
        //    for (int i = 0; i < HashTab.Length; i++)
        //    {
        //        HashTab[i] = -1;
        //    }
        //}
        protected bool isPrim(int Input)
        {
            for (int i = 2; i <= Math.Sqrt(Input); i++)
                if (Input % i == 0)
                    return false;
            return true;
        }
        public virtual int calcNextPrim(int Input)
        {
            if (Input % 2 == 0)
                Input++;
            while (!isPrim(Input))
                Input = Input + 2;
            return Input;
        }

        protected int hashfuntion(int Element, int Modul)
        {
            int hashKey = Element % Modul;
            return hashKey;
        }

        //public int DeleteAnItem(int Element)
        //{
        //    int pos = hashfuntion(Element);
        //    if (pos != 0)
        //    {
        //        HashTab[pos] = 0;     
        //    }
        //    return pos;
        //}

        /// <summary>
        /// Wenn eine Zelle schon belegt, wird sie bei einer Kollision nicht überschrieben
        /// </summary>
        /// <param name="Element"></param>
        /// <returns></returns>
        //public bool Insert(int Element)
        //{
        //    int hashvalue = hashfuntion(Element);
        //    if (HashTab[hashvalue] == -1)
        //    {
        //        HashTab[hashvalue] = Element;
        //        return true;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Kollision beim einfügen von {0} an der Stelle {1}", Element, hashvalue);
        //        return false;
        //    }
        //}
        public abstract bool Insert(int Element);

        //public void PrintAll()
        //{
        //    foreach (int item in HashTab)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        //public void Print()
        //{
        //    for (int i = 0; i < HashTab.Length; i++)
        //    {
        //        if(HashTab[i] >-1)
        //        Console.WriteLine("Key {0}, Index: {1}" ,HashTab[i],i);
        //    }
        //}
        public abstract void Print();

    }
}
