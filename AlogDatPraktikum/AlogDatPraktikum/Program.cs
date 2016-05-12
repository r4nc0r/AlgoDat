using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseList List = new BaseList();
            for (int i = 0; i < 10; i++)
            {
                List.Add(i);
            }
            List.Print();

            List.Print();
            Console.WriteLine();
            Console.WriteLine(List.search(3));
            Console.WriteLine(List.search(99));
            List.Delete(5);
            Console.WriteLine();
            List.Print();
        }
    }
}
