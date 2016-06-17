using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
   abstract class BaseArray
    {
        public void Print(DictElement[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].elemValue > -1)
                { 
                    Console.Write(" {0} |",array[i].elemValue);
                }
            }
            Console.Write("]\n\n");
        }
        public DictElement[] ShiftArrayLeft(DictElement[] array, int startPosition,  int endPosition)
        {
            int tempPosition = endPosition;
            for (int i = startPosition; i >= endPosition; i--)
            {
                array[tempPosition].elemValue = array[tempPosition + 1].elemValue;
                tempPosition = tempPosition + 1;
            }
            return array;
        }

        public DictElement[] ShiftArrayRight(DictElement[] array, int startPosition, int endPosition)
        {
            int tempposition = endPosition;
            for (int i = startPosition; i > endPosition; i--)
            {
                array[i].elemValue = array[i - 1].elemValue;
                tempposition--;
            }
            return array;
        }
        public bool IsSpaceAvailable(DictElement[] array)
        {
            for (int i = array.Length -1; i >= 0; i--)
            {
                if (array[i].elemValue < 0)
                {
                    return true;
                }
            }
            return false;
        }

        public DictElement[] initArray(DictElement[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new DictElement(-1);
            }
            return array;
        }

    }
}
