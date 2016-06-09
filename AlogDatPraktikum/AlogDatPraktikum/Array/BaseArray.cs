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
        public int[] ShiftArrayLeft(int[] array, int startPosition,  int endPosition)
        {
            int tempPosition = endPosition;
            for (int i = startPosition; i >= endPosition; i--)
            {
                array[tempPosition] = array[tempPosition + 1];
                tempPosition = tempPosition + 1;
            }
            return array;
        }

        public int[] ShiftArrayRight(int[] array, int startPosition, int endPosition)
        {
            int tempposition = endPosition;
            for (int i = startPosition; i > endPosition; i--)
            {
                array[i] = array[i - 1];
                tempposition--;
            }
            return array;
        }
        public bool IsSpaceAvailable(int[] array)
        {
            for (int i = array.Length -1; i >= 0; i--)
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
