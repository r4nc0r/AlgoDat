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

        /// <summary>
        /// existiert das zu löschende Element wird das Value mit -1 überschrieben
        /// und true returned
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public bool Delete(int elem)
        {
            int pos = privSearch(elem);
            if (pos == -1 )
                return false;
            
            hashTab[pos].elemValue = -1;
                return true;  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public override bool Insert(int elem)
        {
            for (int i = 0; i < TabLength; i++)
            {
                int pos = calcHash(elem, i, TabLength);
                if(pos < 0)
                {
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

        /// <summary>
        /// brechent den Key eines Elements und prüft ob das zu suchende Element 
        /// sich an dieser Position befindet. Dabei wird die Sondierfolge durchschritten
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private int privSearch(int elem)
        {
            for (int i = 0; i < TabLength; i++)
            {
                int pos = calcHash(elem, i, TabLength);
                if (pos < 0)
                {
                    //ist die gesamte Sondierfolge durchlaufen ohne dass das ELement
                    //gefunden wurde, wird -1 returnt
                    return -1;
                }
                if (hashTab[pos].elemValue == elem)
                    //wenn sich das gesuchte Element an der Position befindet wird die Position zurückgeliefert
                    return pos;
            }
            return -1;
        }
        /// <summary>
        /// Überschreibt die calcNextPrim aus der BaseHash Klasse in der 
        /// Form dass die resultierende Primzahl Konkurent 4mod 3 ist
        /// dadurch kann sichergestellt werden dass alle Plätze sondiert werden
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
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
    
       
        /// <summary>
        /// Berechent den HashKey, 
        /// h(Element,j)=(h`(ELement)+(-1)^i+1*(round i*i/2) mod c
        /// brechent den nächsten hashkey
        /// </summary>
        /// <param name="Element"></param>
        /// <param name="j">mit j, der Anzahl der Sondierschritte wird quasi entschieden ob eine positive oder 
        /// negatives Quadrart verwendet wird</param>
        /// <param name="c">mit dem Parameter c kann die Sondierfolge beeinflusst werden. Hier wird nur Tablength verwendet
        /// Theoretisch könnte man aber auch eine andere Zahl angeben</param>
        /// <returns></returns>
        private int calcHash(int Element, int j, int c)
        {
            //hier wird berechenet ob das positive oder negative Quadrat verwendet wird
            int mult = (int)(Math.Ceiling(j  / 2.0));
            //quadrieren
            mult = mult * mult;
             
            int temp = hashfuntion(Element, c) + (int)(Math.Pow(-1, (j + 1)) * mult);
            
            //
            if (temp <= -1)
            {
                int ring = (temp * -1 )/ c + 1;
                temp = temp + c*ring;
            }
            return temp = hashfuntion(temp ,TabLength);
     
        }
    }
}

