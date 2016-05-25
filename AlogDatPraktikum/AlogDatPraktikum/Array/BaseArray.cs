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
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length-1)
                {
                    Console.Write(" {0} ", array[i]);
                }
                else if (array[i] > -1)
                { 
                    Console.Write(" {0} |",array[i]);
                }
            }
            Console.Write("]\n\n");
        }
        public int[] ShiftArrayLeft(int[] array, int position)
        {
            int tempPosition = position;
            for (int i = 0; i < array.Length - position - 1; i++)
            {
                array[tempPosition] = array[tempPosition + 1];
                tempPosition = tempPosition + 1;
            }
            return array;
        }

        public int[] ShiftArrayRight(int[] array, int position)
        {
            int tempposition = position;
            for (int i = array.Length-1; i > position; i--)
            {
                array[i] = array[i - 1];
                tempposition--;
            }
            return array;
        }
        public bool IsSpaceAvailable(int[] array)
        {
            for (int i = 19; i >= 0; i--)
            {
                if (array[i] < 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
