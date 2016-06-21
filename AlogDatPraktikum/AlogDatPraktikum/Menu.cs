using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class Menu
    {

        public static int intRead()
        {
            int input;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Falsche Eingabe, bitte Eingabe wiederholen");
                input = intRead();
            }
            if (input < 0)
            {
                Console.WriteLine("Negative Zahlen nicht erlaubt. Absolutwert eingefügt");
                input = Math.Abs(input);
            }
            return input;
        }

        /// <summary>
        /// Um schneller eine Überschrift generieren zu können. Diese werden automatisch mit ## aufgefüllt
        /// </summary>
        /// <param name="preset">Hier werden presets für "Dictionary" oder ähnliche oft gebrauchte Überschriften festgelegt</param>
        /// <param name="messages">Falls kein Preset gewünscht, hier die Custom Nachricht.</param>
        public static void Ueberschrift(int preset, params string[] messages)
        {
            string message = "";
            if (preset == 0 && messages.Length >= 1)
            {
                message = messages[0];
            }

            switch (preset)
            {
                case 1:
                    message = "Dictionary";
                    break;
                default:
                    break;
            }
            int breite = 120;

            int hashtags = ((breite - message.Length) - 4) / 2;

            if (preset == 1)
            {
                Console.WriteLine();
                for (int i = 0; i < breite; i++)
                {
                    Console.Write("#");
                }
                Console.Write("\n");
            }


            for (int i = 0; i < hashtags; i++)
            {
                Console.Write("#");
            }
            Console.Write("  " + message + "  ");
            for (int i = 0; i < hashtags; i++)
            {
                Console.Write("#");
            }

            if (preset == 1)
            {
                Console.Write("\n");
                for (int i = 0; i < breite; i++)
                {
                    Console.Write("#");
                }
            }

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Ein schnelles TUI Menü, dass den gewählten Punkt als int zurückgibt.
        /// </summary>
        /// <param name="message">Nachricht vor der Auswahl</param>
        /// <param name="_menuepunkte">Die verschiedenen gewünschten Menüpunkte. Werden der Reihe nach aufgelistet.</param>
        /// <returns></returns>
        public static int LittleMenu(string message, params string[] _menuepunkte)
        {
            Console.WriteLine(message);
            string[] menuepunkte = _menuepunkte;
            for (int i = 0; i < menuepunkte.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, menuepunkte[i]);
            }
            Console.Write("\nAuswahl: ");
            return intRead();
        }

        /// <summary>
        /// Eingabemaske um Elemente einzufügen
        /// </summary>
        /// <param name="Dict"></param>
        public static void Input(Dictionary Dict)
        {
            Console.Clear();

            Ueberschrift(1);
            Ueberschrift(0, Dict.ToString());

            Dict.Print();

            Console.WriteLine("Manuelle Eingabe: (0 zum Abbrechen)");

            int input = intRead();
            if (input == 0)
            {
                return;
            }

            var result = Dict.Insert(input);

            if (result)
            {
                Console.WriteLine(result);
                Console.Clear();
                Ueberschrift(1);
                Ueberschrift(0, Dict.ToString());

                Dict.Print();
            }
            else
            {
                Console.WriteLine("Einfügen fehlgeschlagen");
            }
            Console.WriteLine("Weiter eingeben? (1/0)");
            if (intRead() != 0)
            {
                Input(Dict);
            }
        }

        /// <summary>
        /// Eingabemaske um Elemente zu suchen
        /// </summary>
        /// <param name="Dict"></param>
        public static void Search(Dictionary Dict)
        {
            Console.Clear();

            Ueberschrift(1);
            Ueberschrift(0, Dict.ToString());

            Dict.Print();

            Console.WriteLine("Elemente Suchen: (0 zum Abbrechen)");
            int input = intRead();
            if (input == 0)
                return;

            var result = Dict.Search(input);
            if (result)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Suchen fehlgeschlagen");
            }
            Console.WriteLine("Weiter Suchen? (1/0)");
            if (intRead() != 0)
            {
                Search(Dict);
            }
        }

        /// <summary>
        /// Eingabemaske um Elemente zu löschen
        /// </summary>
        /// <param name="Dict"></param>
        public static void Delete(Dictionary Dict)
        {
            Console.Clear();

            Ueberschrift(1);
            Ueberschrift(0, Dict.ToString());

            Dict.Print();

            Console.WriteLine("Element Löschen: (0 zum Abbrechen)");
            int input = intRead();
            if (input == 0)
            {
                return;
            }
            var result = Dict.Delete(input);
            if (result)
            {
                Console.WriteLine(result);
                Console.Clear();
                Ueberschrift(1);
                Ueberschrift(0, Dict.ToString());

                Dict.Print();

            }
            else
            {
                Console.WriteLine("Löschen fehlgeschlagen");
            }
            Console.WriteLine("Weiter löschen? (1/0)");
            if (intRead() != 0)
            {
                Delete(Dict);
            }

        }

        public static int EditMenu(Dictionary Dict)
        {
			if (Dict != null)
			{
				Dict.Print();
			}
            int nextStep = LittleMenu("\nWeitere Bearbeitungsmöglichkeiten: (0 zum abbrechen)", "Eingeben", "Suchen", "Löschen\n");
            switch (nextStep)
            {
                case 1:
                    InputMenu(Dict);
                    break;
                case 2:
                    Search(Dict);
                    break;
                case 3:
                    Delete(Dict);
                    break;
                default:
                    break;
            }
            return nextStep;
        }

        public static Dictionary DataTypeMenu(Dictionary Dict, ref int input)
        {
            Console.Clear();
            Menu.Ueberschrift(1);

            int abstrDatentyp = Menu.LittleMenu("Bitte wählen Sie einen abstrakten Datentyp:", "Set", "SortedSet", "Multiset", "SortedMultiSet");

            string message = "Bitte wählen Sie einen konkreten Datentyp:";
            int konkrDatentyp;

            Console.Clear();
            Menu.Ueberschrift(1);

            switch (abstrDatentyp)
            {
                case 1:
                    Menu.Ueberschrift(0, "Set");
                    konkrDatentyp = Menu.LittleMenu(message, "SetUnsortedLinkedList", "SetUnsortedArray", "HashTabQuadProb", "HashTabSepChain");
                    switch (konkrDatentyp)
                    {
                        case 1:
                            Dict = new SetUnsortedLinkedList();
                            break;
                        case 2:
                            Console.Write("Größe angeben:");
                            Dict = new SetUnsortedArray(intRead());
                            break;
                        case 3:
                            Dict = new HashTabQuadProb();
                            break;
                        case 4:
                            Dict = new HashTabSepChain();
                            break;
                        default:
							Console.WriteLine("Fehler");
							input = 0;
							break;
                    }
                    break;

                case 2:
                    Menu.Ueberschrift(0, "SortedSet");
                    konkrDatentyp = Menu.LittleMenu(message, "SetSortedLinkedList", "SetSortedArray", "AvlTree", "BinTree");
                    switch (konkrDatentyp)
                    {
                        case 1:
                            Dict = new SetSortedLinkedList();
                            break;
                        case 2:
                            Console.Write("Größe angeben:");
                            Dict = new SetSortedArray(Menu.intRead());
                            break;
                        case 3:
                            Dict = new AVLTree();
                            break;
                        case 4:
                            Dict = new BinTree();
                            break;
                        default:
							Console.WriteLine("Fehler");
							input = 0;
							break;
                    }
                    break;

                case 3:
                    Menu.Ueberschrift(0, "MultiSet");
                    konkrDatentyp = Menu.LittleMenu(message, "MultiSetUnsortedLinkedList", "MultiSetUnsortedArray");
                    switch (konkrDatentyp)
                    {
                        case 1:
                            Dict = new MultiSetUnsortedLinkedList();
                            break;
                        case 2:
                            Console.Write("Größe angeben:");
                            Dict = new MultiSetUnsortedArray(intRead());
                            break;
                        default:
							Console.WriteLine("Fehler");
							input = 0;
							break;
                    }
                    break;

                case 4:
                    Menu.Ueberschrift(0, "SortedMultiSet");
                    konkrDatentyp = Menu.LittleMenu(message, "MultiSetSortedLinkedList", "MultiSetSortedArray");
                    switch (konkrDatentyp)
                    {
                        case 1:
                            Dict = new MultiSetSortedLinkedList();
                            break;
                        case 2:
                            Console.Write("Größe angeben:");
                            Dict = new MultiSetSortedArray(intRead());
                            break;
                        default:
							Console.WriteLine("Fehler");
							input = 0;
							break;
                    }
                    break;

                default:
                    Console.WriteLine("Fehler");
                    input = 0;
                    break;
            }
            return Dict;
        }

        public static void InputMenu(Dictionary Dict)
        {
            if (Menu.LittleMenu("Werte manuell hinzufügen oder per Zufallsgenerator?", "Zufall", "Manuell") == 1)
            {
                Random rnd = new Random();
                Console.Write("\nWieviele Zahlen generieren? ");
                int menge = intRead();
                int[] InputElements = new int[menge];

                Console.Clear();

                Menu.Ueberschrift(1);
                Menu.Ueberschrift(0, Dict.ToString());

                Console.WriteLine("zufallsgenerierte Zahlen: ");

                Console.WriteLine("\n--------------------------------------------------------------------------------");
                for (int i = 1; i < menge + 1; i++)
                {
                    int temp = InputElements[i - 1] = rnd.Next(1, menge * 2);
                    Console.Write("{0}:{1} ", i, temp);
                    if ((i % 10) == 0)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("--------------------------------------------------------------------------------");

                for (int i = 1; i < InputElements.Length + 1; i++)
                {
                    Console.Write("{0}={1}:{2} ", i, InputElements[i - 1], Dict.Insert(InputElements[i - 1]));
                    if ((i % 10) == 0)
                    {
                        Console.WriteLine();
                    }
                }

                Console.WriteLine();
                Console.WriteLine(Dict.GetType().ToString());
                Console.WriteLine();
            }

            /* ---------------------------------------------------------------------- Manuelle Eingabe ---------------------------------------------------------------------- */

            else
            {
                Menu.Input(Dict);
            }
        }

        public static void TestMenu(Dictionary Dict)
        {
            int testNr = Menu.LittleMenu("Testen auf...", "...doppelte Einträge", "...zu viele Einträge");
            Console.Clear();

            Menu.Ueberschrift(1);
            Menu.Ueberschrift(0, Dict.ToString());


            Console.WriteLine();
            Console.WriteLine(Dict.GetType().ToString());
            Console.WriteLine();
            /*
                        switch (testNr)
                        {
                            case 1:
                                // doppelte Einträge
                                foreach (var item in input)
                                {
                                    Dict.Insert(item);
                                }
                                break;
                            case 2:
                                //zu viele Einträge
                                int[] input = { 1, 4, 6, 33, 44, 25, 27, 28, 44, 28 };
                                foreach (var item in input)
                                {
                                    Dict.Insert(item);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    */
        }
    }
}