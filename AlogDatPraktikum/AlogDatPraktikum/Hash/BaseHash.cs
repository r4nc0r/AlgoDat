using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    abstract class BaseHash 
    {
        /// <summary>
        /// prüft ob eine Zeit eine Primzahl ist
        /// dazu wird die übergebene Zahl durch alle Teiler von 2 bis zur Wurzel der
        /// Zahl geteilt und geprüft ob der Rest der Division=0 ist
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        protected bool isPrim(int Input)
        {
            for (int i = 2; i <= Math.Sqrt(Input); i++)
                if (Input % i == 0)
                    return false;
            return true;
        }
        /// <summary>
        /// diese Methode berechnet die nächstgelegene Primzahl.
        /// 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public virtual int calcNextPrim(int Input)
        {
            if (Input % 2 == 0)
                Input++;
            while (!isPrim(Input))
                Input = Input + 2;
            return Input;
        }
        /// <summary>
        /// Hashfunktion mit Division,
        /// berechnet aus einem übergebene Wert und einem Modul den HashKey
        /// </summary>
        /// <param name="Element"></param>
        /// <param name="Modul"></param>
        /// <returns></returns>
        protected int hashfuntion(int Element, int Modul)
        {
            int hashKey = Element % Modul;
            return hashKey;
        }

        public abstract bool Insert(int Element);

        public abstract void Print();

    }
}
