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
            
            Console.WindowWidth = 121;

            Menu.Ueberschrift(1);
            int input=1;
			while (input != 0)
			{
				Dict = Menu.DataTypeMenu(Dict, ref input);
				Console.Clear();
				Menu.Ueberschrift(1);
				input = 1;
				if (Dict != null)
				{
					Menu.Ueberschrift(0, Dict.ToString());
					while ((Menu.EditMenu(Dict) != 0))
					{
						Console.Clear();
						Menu.Ueberschrift(1);
						Menu.Ueberschrift(0, Dict.ToString());
					}
				}
            }
            Console.WriteLine("Programm beendet.");
            Console.ReadLine();
        }
    }
}
