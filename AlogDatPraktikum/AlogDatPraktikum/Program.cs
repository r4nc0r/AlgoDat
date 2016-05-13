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


            //Test für SetUnsortedLinkedList
            Dictionary SUsLL = new SetUnsortedLinkedList();
            SUsLL.Insert(2);
            SUsLL.Insert(6);
            SUsLL.Insert(3);
            SUsLL.Insert(2);
            SUsLL.Print();

            Console.WriteLine(SUsLL.Search(3));
            Console.WriteLine(SUsLL.Search(99));

            Console.WriteLine(SUsLL.Delete(2));
            SUsLL.Print();
            SUsLL.Insert(2);
            SUsLL.Print();

            //Test für basehash
            //BaseHash bh = new BaseHash();
            //bh.Insert(2503);
            //bh.Insert(23);
            //bh.Insert(21);
            //bh.Print();


        }
    }
}
