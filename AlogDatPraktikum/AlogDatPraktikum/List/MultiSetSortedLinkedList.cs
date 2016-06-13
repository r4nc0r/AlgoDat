using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class MultiSetSortedLinkedList : SortedLinkedList, SortedMultiSet
    {
        /// <summary>
        /// Löscht Element und greift auf das Löschen der Basis zurück
        /// </summary>
        /// <param name="elem">zulöschendes Element</param>
        /// <returns>true wenn gelöscht wurde ansonsten false</returns>
        public new bool Delete(int elem)
        {
            return base.Delete(elem);
        }

        /// <summary>
        /// fügt ein neues Element der Liste hinzu
        /// </summary>
        /// <param name="elem">hinzufügendes Element</param>
        /// <returns>true wenn hinzugefügt</returns>
        public bool Insert(int elem)
        {
            Add(elem); //Aufruf der überschriebenen Add Methode aus der Basis
            return true;
        }

        /// <summary>
        /// Gibt Element aus der Liste aus
        /// </summary>
        public new void Print()
        {
            base.Print();
        }

        /// <summary>
        /// Sucht das gewünschte Element in der Liste
        /// </summary>
        /// <param name="elem">zusuchendes Element</param>
        /// <returns>true wenn gefunden ansonsten false</returns>
        public bool Search(int elem)
        {
           return search(elem);
        }
    }
}
