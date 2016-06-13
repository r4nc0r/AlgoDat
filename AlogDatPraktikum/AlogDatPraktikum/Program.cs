using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class Program
    {
        static int intRead()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Um schneller eine Überschrift generieren zu können. Diese werden automatisch mit ## aufgefüllt
        /// </summary>
        /// <param name="preset">Hier werden presets für "Dictionary" oder ähnliche oft gebrauchte Überschriften festgelegt</param>
        /// <param name="messages">Falls kein Preset gewünscht, hier die Custom Nachricht.</param>
        static void Ueberschrift(int preset, params string[] messages)
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
            
            int hashtags = ((breite - message.Length) - 4)/2;

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
            Console.Write("  "+message+"  ");
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
        static int LittleMenu(string message, params string[] _menuepunkte)
        {
            Console.WriteLine(message);
            string[] menuepunkte = _menuepunkte;
            for (int i = 0; i < menuepunkte.Length; i++)
            {
                Console.WriteLine("{0}: {1}",i+1,menuepunkte[i]);
            }
            Console.Write("\nAuswahl: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        /// <summary>
        /// Eingabemaske um Elemente einzufügen
        /// </summary>
        /// <param name="Dict"></param>
        static void ManualInsert(Dictionary Dict)
        {
            Console.Clear();

            Ueberschrift(1);
            Ueberschrift(0, Dict.ToString());

            Dict.Print();

            Console.WriteLine("Manuelle Eingabe: (-1 zum Abbrechen)");
            int input;
            do
            {
                input = Convert.ToInt32(Console.ReadLine());
                if (input == -1)
                {
                    Console.WriteLine("Eingabe beendet");
                    break;
                }
                if (Dict.Insert(input))
                {
                   // Console.WriteLine(Dict.Print());
                    Console.Clear();
                    Ueberschrift(1);
                    Ueberschrift(0, Dict.ToString());

                    Dict.Print();

                    Console.WriteLine("Manuelle Eingabe: (-1 zum Abbrechen)");
                }
                else
                {
                    Console.WriteLine("Einfügen fehlgeschlagen, nächste Zahl oder abbruch mit -1: ");
                }

            } while (input != -1);
        }
        /// <summary>
        /// Eingabemaske um Elemente zu suchen
        /// </summary>
        /// <param name="Dict"></param>
        static void Search(Dictionary Dict)
        {
            Console.Clear();

            Ueberschrift(1);
            Ueberschrift(0, Dict.ToString());

            Dict.Print();

            Console.WriteLine("Elemente Suchen: (-1 zum Abbrechen)");
            int input;
            do
            {
                input = Convert.ToInt32(Console.ReadLine());
                if (input == -1)
                {
                    Console.WriteLine("Eingabe beendet");
                    break;
                }
                if (Dict.Search(input) == true)
                {
                    //Console.WriteLine(Dict.Search(input));
                    Console.Clear();
                    Ueberschrift(1);
                    Ueberschrift(0, Dict.ToString());

                    Dict.Print();

                    Console.WriteLine("Elemente Suchen: (-1 zum Abbrechen)");
                }
                else
                {
                    Console.WriteLine("Suchen fehlgeschlagen, nächste Zahl oder abbruch mit -1: ");
                }

            } while (input != -1);
        }
        /// <summary>
        /// Eingabemaske um Elemente zu löschen
        /// </summary>
        /// <param name="Dict"></param>
        static void Delete(Dictionary Dict)
        {
            Console.Clear();

            Ueberschrift(1);
            Ueberschrift(0, Dict.ToString());

            Dict.Print();

            Console.WriteLine("Element Löschen: (-1 zum Abbrechen)");
            int input;
            do
            {
                input = Convert.ToInt32(Console.ReadLine());
                if (input == -1)
                {
                    Console.WriteLine("Eingabe beendet");
                    break;
                }
                if (Dict.Delete(input))
                {
                    //Console.WriteLine(Dict.Delete(input));
                    Console.Clear();
                    Ueberschrift(1);
                    Ueberschrift(0, Dict.ToString());

                    Dict.Print();

                    Console.WriteLine("Element Löschen: (-1 zum Abbrechen)");
                }
                else
                {
                    Console.WriteLine("Llöschen fehlgeschlagen, nächste Zahl oder abbruch mit -1: ");
                }

            } while (input != -1);
        }

        static void EditMenu(Dictionary Dict)
        {
            int nextStep = LittleMenu("Weitere Bearbeitungsmöglichkeiten: ", "Eingeben", "Suchen", "Löschen\n");
            switch (nextStep)
            {
                case 1:
                    ManualInsert(Dict);
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
        }

        static void Main(string[] args)
        {
            Dictionary Dict;

            Console.WindowWidth = 121;
            Console.Clear();

            Ueberschrift(1);

            AuswahlAbstrakterDatentyp:
            int abstrDatentyp = LittleMenu("Bitte wählen Sie einen abstrakten Datentyp:", "Set", "SortedSet", "Multiset", "SortedMultiSet");

            Console.Clear();
            Ueberschrift(1);

            string message = "Bitte wählen Sie einen konkr Datentyp:";
            int konkrDatentyp;

            
            switch (abstrDatentyp)
            {
                case 1:
                    Ueberschrift(0, "Set");
                    konkrDatentyp = LittleMenu(message, "SetUnsortedLinkedList", "SetUnsortedArray", "BinTree");
                    switch (konkrDatentyp)
                    {
                        case 1:
                            Dict = new SetUnsortedLinkedList();
                            break;
                        case 2:
                            Dict = new SetUnsortedArray();
                            break;
                        case 3:
                            Dict = new BinTree();
                            break;
                        default:
                            Dict = new SetSortedLinkedList();
                            break;
                    }
                    break;
                case 2:
                    Ueberschrift(0, "SortedSet");
                    konkrDatentyp = LittleMenu(message, "SetSortedLinkedList", "SetSortedArray", "AvlTree","HashTabQuadProb","HashTabSepChain");
                    switch (konkrDatentyp)
                    {
                        case 1:
                            Dict = new SetSortedLinkedList();
                            break;
                        case 2:
                            Console.WriteLine("Größe angeben: ");
                            Dict = new SetSortedArray(intRead());
                            break;
                        case 3:
                            Dict = new AVLTree();
                            break;
                        case 4:
                            Dict = new HashTabQuadProb();
                            break;
                        case 5:
                            Dict = new HashTabSepChain();
                            break;
                        default:
                            Dict = new SetSortedLinkedList();
                            break;
                    }
                    break;
                case 3:
                    Ueberschrift(0, "MultiSet");
                    konkrDatentyp = LittleMenu(message, "MultiSetUnsortedLinkedList", "MultiSetUnsortedArray");
                    switch (konkrDatentyp)
                    {
                        case 1:
                            Dict = new MultiSetUnsortedLinkedList();
                            break;
                        case 2:
                            Dict = new MultiSetUnsortedArray();
                            break;
                        default:
                            Dict = new MultiSetUnsortedLinkedList();
                            break;
                    }
                    break;
                case 4:
                    Ueberschrift(0, "SortedMultiSet");
                    konkrDatentyp = LittleMenu(message, "MultiSetSortedLinkedList", "MultiSetSortedArray");
                    switch (konkrDatentyp)
                    {
                        case 1:
                            Dict = new MultiSetSortedLinkedList();
                            break;
                        case 2:
                            Dict = new MultiSetSortedArray(20);
                            break;
                        default:
                            Dict = new MultiSetSortedLinkedList();
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Fehler");
                    Dict = new SetSortedLinkedList();
                    goto AuswahlAbstrakterDatentyp;                    
            }
            
            Console.Clear();

            Ueberschrift(1);
            Ueberschrift(0, Dict.ToString());

            /* ---------------------------------------------------------------------- Zufallsgenerierte Eingabe ---------------------------------------------------------------------- */

            if (LittleMenu("Werte manuell hinzufügen oder per Zufallsgenerator?", "Zufall", "Manuell") == 1)
            {
                Random rnd = new Random();
                Console.Write("\nWieviele Zahlen generieren? :");
                int menge = Convert.ToInt32(Console.ReadLine());
                int[] InputElements = new int[menge];

                Console.Clear();

                Ueberschrift(1);
                Ueberschrift(0, Dict.ToString());

                Console.WriteLine("zufallsgenerierte Zahlen: ");

                Console.WriteLine("\n--------------------------------------------------------------------------------");
                for (int i = 1; i < menge+1; i++)
                {   
                    int temp = InputElements[i-1] = rnd.Next(1, menge*2);
                    Console.Write("{0}:{1} ", i, temp);
                    if ((i % 10) == 0)
                    {
                        Console.WriteLine();
                    }
                }                
                Console.WriteLine("--------------------------------------------------------------------------------");

                for (int i = 1; i < InputElements.Length+1; i++)
                {
                    Console.Write("{0}={1}:{2} ", i, InputElements[i - 1],Dict.Insert(InputElements[i-1]));
                    if ((i % 10) == 0)
                    {
                        Console.WriteLine();
                    }
                }


                Console.WriteLine();
                Console.WriteLine(Dict.GetType().ToString());
                Console.WriteLine();

                Dict.Print();
            }

            /* ---------------------------------------------------------------------- Manuelle Eingabe ---------------------------------------------------------------------- */

            else
            {
                ManualInsert(Dict);
            }

            Console.Clear();

            Ueberschrift(1);
            Ueberschrift(0, Dict.ToString());
            Dict.Print();

            EditMenu(Dict);

            //Dictionary Dict = new HashTabSepChain();
            //Dictionary Dict = new HashTabQuadProb();

            //Dict[0] = new HashTabSepChain();
            //Dict[5] = new HashTabQuadProb();
            

            //Test für Trees
            //string input = "";
            //Dictionary tree = null;
            //while (input != "1" && input != "2")
            //{
            //    Console.WriteLine("[1]: BinaryTree");
            //    Console.WriteLine("[2]: AVLTree");
            //    input = Console.ReadLine();
            //}

            //if (input == "1")
            //    tree = new BinTree();
            //else
            //    tree = new AVLTree();

            //while (true)
            //{
            //    input = Console.ReadLine();
            //    if (input.ToLower().StartsWith("insert"))
            //        tree.Insert(Convert.ToInt32(input.Remove(0, 6).Trim()));
            //    else if (input.ToLower().StartsWith("delete"))
            //        tree.Delete(Convert.ToInt32(input.Remove(0, 6).Trim()));
            //    else if (input.ToLower().StartsWith("print"))
            //        tree.Print();
            //}


            //Test für basehash
            //BaseHash bh = new BaseHash();
            //bh.Insert(2503);
            //bh.Insert(23);
            //bh.Insert(92313);
            //bh.Insert(21);
            //bh.Print();
            //Console.WriteLine(bh.DeleteAnItem(23));
            //bh.Print();

            //Dictionary HTSC = new HashTabSepChain();
            //HTSC.Insert(2503);
            //HTSC.Insert(23);
            //HTSC.Insert(92313);
            //HTSC.Insert(21);
            //HTSC.Insert(0);
            //HTSC.Print();
            //Console.WriteLine(HTSC.Search(21));
            //Console.WriteLine(HTSC.Delete(23));
            //HTSC.Print();


            //Dictionary HTQP = new HashTabQuadProb();
            //HTQP.Insert(13);
            //HTQP.Insert(2);
            //HTQP.Insert(3);
            //HTQP.Insert(15);
            //HTQP.Insert(7);
            //HTQP.Insert(20);
            //HTQP.Insert(10);
            //HTQP.Insert(3);
            //HTQP.Print();

            

            /* Ablage alt - Löschen?? */

            //Dictionary[] Dict = new Dictionary[6];
            //Dictionary Dict = new MultiSetSortedLinkedList();
            //Dictionary Dict = new MultiSetUnsortedLinkedList();
            //Dictionary Dict = new SetSortedLinkedList();
            //Dictionary Dict = new SetUnsortedLinkedList();
            //Dictionary Dict = new HashTabSepChain();
            //Dictionary Dict = new HashTabQuadProb();

            //Dict[0] = new MultiSetSortedLinkedList();
            //Dict[1] = new MultiSetUnsortedLinkedList();
            //Dict[2] = new SetSortedLinkedList();
            //Dict[3] = new SetUnsortedLinkedList();
            //Dict[0] = new HashTabSepChain();
            //Dict[5] = new HashTabQuadProb();

            //Random rnd = new Random();
            //int[] InputElemente = new int[20];
            //for (int i = 0; i < 20; i++)
            //{
            //    int temp = InputElemente[i] = rnd.Next(1, 15);
            //    Console.Write("Index:{0}:{1} ",i,temp );
            //}
            //Console.WriteLine();
            //Console.WriteLine("--------------------------------");
            //foreach (Dictionary item in Dict)
            //{
            //    Console.WriteLine();
            //    foreach (int random in InputElemente)
            //    {
            //        Console.WriteLine(item.Insert(random));
            //    }

            //    Console.WriteLine(item.GetType().ToString());
            //    item.Print();

            //    int input; 
            //    do
            //    {
            //        Console.WriteLine("WErt bitte zum löschen");
            //        input = Convert.ToInt32(Console.ReadLine());
            //        Console.WriteLine(item.Delete(input));
            //        item.Print();

            //    } while (input != -1);



            //}


            //foreach (Dictionary item in DictArray)
            //{
            //    Console.WriteLine("Next item");
            //    item.Print();
            //    Console.WriteLine();
            //}

            //BaseList List = new BaseList();
            //List.Print();
            //List.Delete(5);
            //for (int i = 0; i < 10; i++)
            //{
            //    List.Add(i);
            //}
            //List.Print();


            //List.Print();
            //Console.WriteLine();
            //Console.WriteLine(List.search(3));
            //Console.WriteLine(List.search(99));
            //List.Delete(5);
            //Console.WriteLine();
            //List.Print();


            //Test für MultiSetUnsortedLinkedList
            //Dictionary MSUsLL = new MultiSetUnsortedLinkedList();
            //MSUsLL.Insert(2);
            //MSUsLL.Insert(19);
            //MSUsLL.Insert(4);
            //MSUsLL.Insert(2);
            //MSUsLL.Insert(87);
            //MSUsLL.Insert(1);
            //MSUsLL.Print();
            //Console.WriteLine(MSUsLL.Search(1));
            //Console.WriteLine(MSUsLL.Search(5));
            //Console.WriteLine(MSUsLL.Delete(87));
            //MSUsLL.Print();
            //Console.WriteLine(MSUsLL.Delete(5));          //Null ReferenceException, privatesearch funktioniert noch nicht richtig
            //Console.WriteLine("----------------");
            //MSUsLL.Print();


            //Test für SetUnsortedLinkedList
            //Dictionary SUsLL = new SetUnsortedLinkedList();
            //SUsLL.Insert(2);
            //SUsLL.Insert(6);
            //SUsLL.Insert(3);
            //SUsLL.Insert(2);
            //SUsLL.Print();

            //Console.WriteLine(SUsLL.Search(3));
            //Console.WriteLine(SUsLL.Search(99));

            //Console.WriteLine(SUsLL.Delete(6));
            //SUsLL.Print();
            //SUsLL.Insert(2);
            //Console.WriteLine(SUsLL.Delete(94));

            //SUsLL.Print();

            //Test für MulitSetSortedLinkedList
            //Dictionary MssLL = new MultiSetSortedLinkedList();
            //Console.WriteLine(MssLL.Search(0));

            //MssLL.Delete(1);
            //MssLL.Delete(30);

            //MssLL.Insert(1);
            //MssLL.Insert(9);
            //MssLL.Insert(4);
            //MssLL.Insert(2);
            //MssLL.Insert(8);
            //MssLL.Insert(5);
            //MssLL.Insert(2);
            //MssLL.Insert(30);
            //MssLL.Print();

            //Console.WriteLine(MssLL.Search(2));

            //MssLL.Delete(5);
            //MssLL.Print();

            //Dictionary SSLL = new SetSortedLinkedList();
            //SSLL.Insert(1);
            //SSLL.Insert(9);
            //SSLL.Insert(4);
            //SSLL.Insert(2);
            //SSLL.Insert(8);
            //SSLL.Insert(5);
            //SSLL.Insert(2);
            //SSLL.Insert(30);
            //SSLL.Print();
            //Console.WriteLine("--------------------");
            //Console.WriteLine(SSLL.Delete(2424));
            //Console.WriteLine(SSLL.Delete(1));
            //Console.WriteLine(SSLL.Delete(4));
            //Console.WriteLine(SSLL.Delete(30));
            //SSLL.Print();


            //Test für Trees
            //string input = "";
            //Dictionary tree = null;
            //while (input != "1" && input != "2")
            //{
            //    Console.WriteLine("[1]: BinaryTree");
            //    Console.WriteLine("[2]: AVLTree");
            //    input = Console.ReadLine();
            //}

            //if (input == "1")
            //    tree = new BinTree();
            //else
            //    tree = new AVLTree();

            //while (true)
            //{
            //    input = Console.ReadLine();
            //    if (input.ToLower().StartsWith("insert"))
            //        tree.Insert(Convert.ToInt32(input.Remove(0, 6).Trim()));
            //    else if (input.ToLower().StartsWith("delete"))
            //        tree.Delete(Convert.ToInt32(input.Remove(0, 6).Trim()));
            //    else if (input.ToLower().StartsWith("print"))
            //        tree.Print();
            //}


            //Test für basehash
            //BaseHash bh = new BaseHash();
            //bh.Insert(2503);
            //bh.Insert(23);
            //bh.Insert(92313);
            //bh.Insert(21);
            //bh.Print();
            //Console.WriteLine(bh.DeleteAnItem(23));
            //bh.Print();

            //Dictionary HTSC = new HashTabSepChain();
            //HTSC.Insert(2503);
            //HTSC.Insert(23);
            //HTSC.Insert(92313);
            //HTSC.Insert(21);
            //HTSC.Insert(0);
            //HTSC.Print();
            //Console.WriteLine(HTSC.Search(21));
            //Console.WriteLine(HTSC.Delete(23));
            //HTSC.Print();


            //Dictionary HTQP = new HashTabQuadProb();
            //HTQP.Insert(13);
            //HTQP.Insert(2);
            //HTQP.Insert(3);
            //HTQP.Insert(15);
            //HTQP.Insert(7);
            //HTQP.Insert(20);
            //HTQP.Insert(10);
            //HTQP.Insert(3);
            //HTQP.Print();
        }
    }
}
