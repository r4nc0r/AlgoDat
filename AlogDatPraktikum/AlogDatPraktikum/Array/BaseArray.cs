using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
   abstract class BaseArray
    {
        public void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > -1)
                {
                    Console.Write(array[i] + " ");
                }
            }
            Console.WriteLine();
        }
        public int[] ShiftArrayLeft(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                array[i] = array[i + 1];
            }
            return array;
        }
    }
}
