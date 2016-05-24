using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    abstract class SortedArray : BaseArray
    {

        public int PrivateSearch(int elem, int[] array)
        {
            
            int i;
            int l = 0;
            int r = array.Length - 1;
            int position = -1;

            while(position == -1 && l <= r )
            {
                i = (l + r) / 2;
                if (array[i] < elem )
                {
                    l = i + 1;
                }
                else if (array[i] > elem)
                {
                    r = i - 1;
                }
                if (array[i] == elem)
                {
                    position = i;
                }
            }

            /*
                        if (position == -1)
                        {
                            position = l;
                            while (position < array.Length && array[position] < elem)
                                position++;

                            position--;
                            while (position >=0 && array[position] < 0)
                                position--;
                            position++;
                            if (array[position] > elem && array[position] > 0)
                            {
                                position--;
                                return position;
                            }

                        }
                        return position;
                        */

            if (position == -1)
            {
                int x;
                for (x= 0; x < array.Length-1; x++)
                {
                    if (array[x] < elem && array[x+1] > elem)
                    {
                        return x + 1;
                    }
                    if (x == array.Length -2)
                    {
                        return x + 1;
                    }
                }

            }
            return position;
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
