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
            Dictionary Dict = null;
            int input=1;
            Console.WindowWidth = 121;
            Console.Clear();

            Menu.Ueberschrift(1);
            
            while (input != -1)
            {
                Dict = Menu.DataTypeMenu(Dict,ref input);
                Console.Clear();
                Menu.Ueberschrift(1);
                Menu.Ueberschrift(0, Dict.ToString());
                Dict.Print();

                Menu.InputMenu(Dict);
                while (Menu.EditMenu(Dict) != -1)
                {
                    Console.Clear();
                    Menu.Ueberschrift(1);
                    Menu.Ueberschrift(0, Dict.ToString());
                }
            }
            Console.WriteLine("Programm beendet.");
            Console.ReadLine();
        }
    }
}
