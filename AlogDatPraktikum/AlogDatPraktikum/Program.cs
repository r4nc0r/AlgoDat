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


            //Test für basehash
            BaseHash bh = new BaseHash();
            bh.Insert(2503);
            bh.Insert(23);
            bh.Insert(21);
            bh.Print();

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

        }
    }
}
