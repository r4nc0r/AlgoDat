using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class SetSortedLinkedList : SortedLinkedList, SortedSet
    {
        /// <summary>
        /// löscht Element aus der Liste
        /// </summary>
        /// <param name="elem">zulöschendes  Element</param>
        /// <returns>true wenn gelöscht ansonsten false</returns>
        public new  bool Delete(int elem)
        {
            return base.Delete(elem);
        }

        /// <summary>
        /// hinzufügen eines neues Elements
        /// </summary>
        /// <param name="elem">neues Element</param>
        /// <returns>true wenn noch nicht in Liste vorhanden, falls vorhanden false</returns>
        public bool Insert(int elem)
        {
            if (!base.search(elem))
            {
                Add(elem); //Ruft überschriebene Add Methode auf von SortedLinkedList
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Gibt Element der Liste aus
        /// </summary>
        public new void Print()
        {
            base.Print();
        }

        /// <summary>
        /// Sucht ein element in der Liste
        /// </summary>
        /// <param name="elem">zusuchende element</param>
        /// <returns>wenn gefunden dann true ansonsten false</returns>
        public bool Search(int elem)
        {
           return search(elem);
        }
    }
}
