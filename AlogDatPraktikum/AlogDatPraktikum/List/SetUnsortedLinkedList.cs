using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class SetUnsortedLinkedList : UnsortedLinkedList, Set
    {
        /// <summary>
        /// Löscht Element aus der Liste
        /// </summary>
        /// <param name="elem">zulöschendes Element</param>
        /// <returns>true wenn gelöscht ansonsten false</returns>
        public new bool Delete(int elem)
        {
            return base.Delete(elem);
        }

        /// <summary>
        /// Fügt neues Element in die Liste
        /// </summary>
        /// <param name="elem">neues Element</param>
        /// <returns>true wenn eingefügt false wenn schon vorhanden</returns>
        public bool Insert(int elem)
        {
            if (!search(elem))
            {
                Add(elem);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Gibt Element der Liste aus
        /// </summary>
        public new void Print()
        {
            base.Print();
        }

        /// <summary>
        /// Sucht Element in der Liste
        /// </summary>
        /// <param name="elem">zusuchendes Element</param>
        /// <returns>true wenn gefunden ansonsten false</returns>
        public bool Search(int elem)
        {
            return search(elem);
        }
    }
}
