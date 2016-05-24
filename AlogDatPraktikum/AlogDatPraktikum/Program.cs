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
            Dictionary[] Dict = new Dictionary[6];
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
            Dict[0] = new HashTabSepChain();
            //Dict[5] = new HashTabQuadProb();

            Random rnd = new Random();
            int[] InputElemente = new int[20];
            for (int i = 0; i < 20; i++)
            {
                int temp = InputElemente[i] = rnd.Next(1, 15);
                Console.Write("Index:{0}:{1} ",i,temp );
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            foreach (Dictionary item in Dict)
            {
                Console.WriteLine();
                foreach (int random in InputElemente)
                {
                    Console.WriteLine(item.Insert(random));
                }

                Console.WriteLine(item.GetType().ToString());
                item.Print();

                int input; 
                do
                {
                    Console.WriteLine("WErt bitte zum löschen");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(item.Delete(input));
                    item.Print();

                } while (input != -1);

                
                
            }


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
