using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
   interface  Dictionary
    {
        bool Search(int elem);

        bool Insert(int elem);

        bool Delete(int elem);

        void Print();
    }
}
