using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
   abstract class BaseArray
    {
        /// <summary>
        /// Prints all positive Elements of an Array
        /// </summary>
        /// <param name="array">Array that should be printed</param>
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
            Console.WriteLine("{0} von  {1} belegt",Count(array), array.Length);
        }

        /// <summary>
        /// Counts all positie Elements of an Array
        /// </summary>
        /// <param name="array">Array that should be counted</param>
        /// <returns></returns>
        public int Count(DictElement[] array)
        {
          int counter = 0;
          for (int i = 0; i < array.Length; i++)
          {
            if (array[i].elemValue != -1)
            {
              counter++;
            }
       
          }
          return counter;
        }

        /// <summary>
        /// Shifts Array Elements to the Left from Start- to Endposition where Start must be bigger than End
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="startPosition"></param>
        /// <param name="endPosition"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Shifts Array Elements to the Left from Start- to Endposition where Start must be bigger than End
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="startPosition"></param>
        /// <param name="endPosition"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if Space is available in an Array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Initiates an Array with -1 at every Position
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
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
