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
        /// Diese Methode testet ob es sich bei der eingegebene Zahl um eine Primzahl handelt
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        protected bool isPrim(int Input)
        {
            //überprüft ob Input Modulo i als Rest 0 ist, von i=0  bis i=Wurzel(Input), wurde ein Teiler gefunden wird false returned
            for (int i = 2; i <= Math.Sqrt(Input); i++) 
                if (Input % i == 0)
                    return false;
            return true;
        }
        /// <summary>
        /// Diese Methode sucht die nächstgelegene Primzahl zu zu Input
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

        //Diese Methode berechnet die Hashfunktion nach dem Divisionsverfahren
        protected int hashfuntion(int Element, int Modul)
        {
            int hashKey = Element % Modul;
            return hashKey;
        }

        public abstract bool Insert(int Element);

        public abstract void Print();

    }
}
