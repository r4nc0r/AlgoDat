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
            Dictionary Dict = new SetSortedLinkedList();

            Console.WindowWidth = 121;
            Console.Clear();

            Menu.Ueberschrift(1);

            Dict = Menu.DataTypeMenu(Dict);

            Console.Clear();

            Menu.Ueberschrift(1);
            Menu.Ueberschrift(0, Dict.ToString());

            Menu.InputMenu(Dict);
            
            Console.Clear();

            Menu.Ueberschrift(1);
            Menu.Ueberschrift(0, Dict.ToString());
            Dict.Print();

            Menu.EditMenu(Dict);
        }
    }
}
