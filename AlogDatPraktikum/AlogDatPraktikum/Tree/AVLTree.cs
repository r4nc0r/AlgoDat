using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class AVLTree : BinTree
    {
        public override bool Insert(int elem)
        {
            TreeNodeRef searchRef = _SearchRef_(elem);
            if (searchRef.node != null) //Element bereits vorhanden
                return false;
            if (searchRef.parent == null) //Baum ist leer, Element wird RootNode
            {
                rootNode = new AVLTreeNode(elem, null);
                return true;
            }
            else if (searchRef.dir == Direction.left) //Neues Element wird linkes Kind
            {
                searchRef.parent.left = new AVLTreeNode(elem, searchRef.parent as AVLTreeNode);
                _InsertBalance_(searchRef.parent as AVLTreeNode, -1); //Elternknoten wird linkslastiger
            }
            else //Neues Element wird rechtes Kind
            {
                searchRef.parent.right = new AVLTreeNode(elem, searchRef.parent as AVLTreeNode);
                _InsertBalance_(searchRef.parent as AVLTreeNode, +1); //Elternknoten wird rechtslastiger
            }
            return true;
        }

        private void _InsertBalance_(AVLTreeNode node, int balance)
        {
            node.BalanceFaktor += balance;

            if (node.BalanceFaktor == 0) //(Teil)baum ist jetzt ausgeglichen --> Keine Änderungen weiter oben
                return; 

            else if (node.BalanceFaktor == -2) //(Teil)baum ist doppelt linkslastig (--> linkes Kind auf jeden Fall vorhanden)
            {
                if ((node.left as AVLTreeNode).BalanceFaktor == -1) //linker Teilbaum ist ebenfalls linkslastig
                {
                    //Balancefaktoren anpassen
                    node.BalanceFaktor = 0;
                    (node.left as AVLTreeNode).BalanceFaktor = 0;
                    //Rechts-Rotation
                    rotRight(node);
                }
                else //linker Teilbaum ist rechtslastig (--> rechtes Kind des linken Kindes auf jeden Fall vorhanden)
                {
                    //Balancefaktoren anpassen
                    if ((node.left.right as AVLTreeNode).BalanceFaktor == -1)
                    {
                        node.BalanceFaktor = 1;
                        (node.left as AVLTreeNode).BalanceFaktor = 0;                        
                    }
                    else if ((node.left.right as AVLTreeNode).BalanceFaktor == 0)
                    {
                        node.BalanceFaktor = 0;
                        (node.left as AVLTreeNode).BalanceFaktor = 0;
                    }
                    else // sonst +1
                    {
                        node.BalanceFaktor = 0;
                        (node.left as AVLTreeNode).BalanceFaktor = -1;
                    }
                    (node.left.right as AVLTreeNode).BalanceFaktor = 0;
                    //Links-Rechts-Rotation
                    rotLeft(node.left as AVLTreeNode);
                    rotRight(node);
                }
                return;
            }
            else if (node.BalanceFaktor == 2) //(Teil)baum ist doppelt rechtslastig (--> rechtes Kind auf jeden Fall vorhanden)
            {
                if ((node.right as AVLTreeNode).BalanceFaktor == 1) //rechter Teilbaum ist ebenfalls rechtslastig
                {   
                    //BalanceFaktoren anpassen
                    node.BalanceFaktor = 0;
                    (node.right as AVLTreeNode).BalanceFaktor = 0;
                    //Links-Rotation
                    rotLeft(node);
                }
                else //rechter Baum ist linkslastig (--> linkes Kind des rechten Kindes auf jeden Fall vorhanden)
                {
                    //BalanceFaktoren anpassen
                    if ((node.right.left as AVLTreeNode).BalanceFaktor == 1)
                    {
                        node.BalanceFaktor = -1;
                        (node.right as AVLTreeNode).BalanceFaktor = 0;
                    }
                    else if ((node.right.left as AVLTreeNode).BalanceFaktor == 0)
                    {
                        node.BalanceFaktor = 0;
                        (node.right as AVLTreeNode).BalanceFaktor = 0;
                    }
                    else // sonst -1
                    {
                        node.BalanceFaktor = 0;
                        (node.right as AVLTreeNode).BalanceFaktor = 1;
                    }
                    (node.right.left as AVLTreeNode).BalanceFaktor = 0;
                    //Rechts-Links-Rotation
                    rotRight(node.right as AVLTreeNode);
                    rotLeft(node);
                }
                return;
            }

            if (node == rootNode) //Gerade behandelter Knoten ist Wurzel --> Pfad beendet
                return;

            // Gerade behandelter Knoten ist leicht links- bzw rechtslastig geworden (Höhe des (Teil)baums ist 1 höher geworden
            if (node.parent.left == node) //Gerade behandelter Knoten ist linkes Kind
                _InsertBalance_(node.parent, -1); //Elternknoten wird linkslastiger
            else //Gerade behandelter Knoten ist rechtes Kind
                _InsertBalance_(node.parent, 1); //Elternknoten wird rechtslastiger
        }

        public override bool Delete(int elem)
        {
            TreeNodeRef searchRef = _SearchRef_(elem);

            if (searchRef.node == null) //Element nicht vorhanden
                return false;

            if (searchRef.node.left == null && searchRef.node.right == null) //Knoten ist ein Blatt
            {
                if (searchRef.node == rootNode) //Wurzel
                    rootNode = null;
                else if (searchRef.parent.right == searchRef.node) //rechtes Kind
                {
                    searchRef.parent.right = null;
                    _DeleteBalance_(searchRef.parent as AVLTreeNode, -1);
                }
                else //linkes Kind
                {
                    searchRef.parent.left = null;
                    _DeleteBalance_(searchRef.parent as AVLTreeNode, 1);
                }
            }
            else if (searchRef.node.left != null) //Linkes Kind vorhanden -> suche direkten Nachbar im linken Teilbaum
            {
                AVLTreeNode temp = searchRef.node.left as AVLTreeNode;
                while (temp.right != null)
                    temp = temp.right as AVLTreeNode;
                shiftNode(temp, searchRef.node as AVLTreeNode);                
            }
            else //Kein linkes Kind vorhanden -> suche direkten Nachbar im rechten Teilbaum !! node hat mindestens balancefaktor +1 (sogar genau, weil sonst wärs kein avlbaum)
            {
                AVLTreeNode temp = searchRef.node.right as AVLTreeNode;
                while (temp.left != null)
                    temp = temp.right as AVLTreeNode;
                shiftNode(temp, searchRef.node as AVLTreeNode);
            }

            return true;
        }

        private void shiftNode(AVLTreeNode source, AVLTreeNode target) //source hat entweder kein Kind oder nur ein Kind
        {
            target.elem.elemValue = source.elem.elemValue; //Element im target mit Element im source überschreiben

            if (source.left != null) //nur linkes Kind
            {
                if (source.parent.left == source) //source ist linkes Kind
                {
                    source.parent.left = source.left;
                    _DeleteBalance_(source.parent, 1);
                }
                else //source ist rechtes Kind
                {
                    source.parent.right = source.left;
                    _DeleteBalance_(source.parent, -1);
                }
            }
            else  //nur rechtes Kind oder kein Kind
            {
                if (source.parent.left == source) //source ist linkes Kind
                {
                    source.parent.left = source.right;
                    _DeleteBalance_(source.parent, 1);
                }
                else //source ist rechtes Kind
                {
                    source.parent.right = source.right;
                    _DeleteBalance_(source.parent, -1);
                }
            }
            //Ausbalancieren anstoßen
            
        }

        private void _DeleteBalance_(AVLTreeNode node, int balance)
        {
            node.BalanceFaktor += balance;

            if (node.BalanceFaktor == -1 || node.BalanceFaktor == 1) //(Teil)baum jetzt leicht links- oder rechtslastig
                return;                                              // --> Keine Änderungen weiter oben

            else if (node.BalanceFaktor != 0)
            {
                AVLTreeNode parent = node.parent; //parent und dir wird nach Rotationen benötigt
                Direction dir = Direction.left;
                if (parent != null && parent.right == node)
                    dir = Direction.right;

                if (node.BalanceFaktor == -2) //(Teil)baum ist doppelt linkslastig (--> linkes Kind auf jeden Fall vorhanden)
                {                   
                    if ((node.left as AVLTreeNode).BalanceFaktor == -1) //linker Teilbaum ist leicht linkslastig
                    {
                        //Balancefaktoren anpassen
                        node.BalanceFaktor = 0;
                        (node.left as AVLTreeNode).BalanceFaktor = 0;
                        //Rechts-Rotation
                        rotRight(node);
                    }
                    else if ((node.left as AVLTreeNode).BalanceFaktor == 0) //linker Teilbaum ist ausgeglichen
                    {
                        //Balancefaktoren anpassen
                        node.BalanceFaktor = -1;
                        (node.left as AVLTreeNode).BalanceFaktor = 1;
                        //Rechts-Rotation
                        rotRight(node);
                        return; //Höhe ändert sich hier nicht --> Abbruch
                    }
                    else //linker Teilbaum ist leicht rechtslastig (--> linkes Kind hat auf jeden Fall rechtes Kind)
                    {
                        //Balancefaktoren anpassen
                        node.BalanceFaktor = 0;
                        (node.left as AVLTreeNode).BalanceFaktor = 0;
                        if ((node.left.right as AVLTreeNode).BalanceFaktor == -1)
                            node.BalanceFaktor = +1;
                        else if ((node.left.right as AVLTreeNode).BalanceFaktor == 1)
                            (node.left as AVLTreeNode).BalanceFaktor = -1;
                        (node.left.right as AVLTreeNode).BalanceFaktor = 0;
                        //Links-Rechts-Rotation
                        rotLeft(node.left as AVLTreeNode);
                        rotRight(node);
                    }                    
                }

                else if (node.BalanceFaktor == 2) //(Teil)baum ist doppelt rechtslastig (--> rechter Nachbar auf jeden Fall vorhanden)
                {
                    if ((node.right as AVLTreeNode).BalanceFaktor == 1) //rechter Teilbaum ist leicht rechtslastig                        
                    {
                        //Balancefaktoren anpassen
                        node.BalanceFaktor = 0;
                        (node.right as AVLTreeNode).BalanceFaktor = 0;
                        //Links-Rotation
                        rotLeft(node);
                    }
                    else if ((node.right as AVLTreeNode).BalanceFaktor == 0) //rechter Teilbaum ist ausgeglichen
                    {
                        //Balancefaktoren anpassen
                        node.BalanceFaktor = +1;
                        (node.right as AVLTreeNode).BalanceFaktor = -1;
                        //Rechts-Rotation
                        rotLeft(node);
                        return; //Höhe ändert sich hier nicht --> Abbruch
                    }
                    else //rechter Baum ist leicht linkslastig (--> rechtes Kind hat auf jeden Fall linkes Kind)
                    {
                        //Balancefaktoren anpassen
                        node.BalanceFaktor = 0;
                        (node.right as AVLTreeNode).BalanceFaktor = 0;
                        if ((node.right.left as AVLTreeNode).BalanceFaktor == 1)
                            node.BalanceFaktor = -1;
                        else if ((node.right.left as AVLTreeNode).BalanceFaktor == -1)
                            (node.right as AVLTreeNode).BalanceFaktor = 1;
                        (node.right.left as AVLTreeNode).BalanceFaktor = 0;
                        //Rechts-Links-Rotation
                        rotRight(node.right as AVLTreeNode);
                        rotLeft(node);
                    }
                }
                //Höhe hat sich um 1 verringert -> nach oben weitergeben    
                if (parent != null)
                {
                    if (dir == Direction.left)
                        _DeleteBalance_(parent, 1);
                    else
                        _DeleteBalance_(parent, -1);
                }
            }
            else //(Teil)baum ist jetzt ausgeglichen
            {
                if (node == rootNode) //Knoten ist Wurzel
                    return;           // --> Pfad beendet
                else if (node.parent.left == node)   //Knoten ist linkes Kind von Parent
                    _DeleteBalance_(node.parent, 1); // --> Parent wird rechtslastiger
                else                                  //Knoten ist rechtes Kind von Parent
                    _DeleteBalance_(node.parent, -1); // --> Parent wird linkslastiger
            }                           
        }

        private void rotRight(AVLTreeNode node)
        {
            AVLTreeNode left = node.left as AVLTreeNode;
            AVLTreeNode leftRight = left.right as AVLTreeNode;
            AVLTreeNode parent = node.parent;

            if (node == rootNode) //Linkes Kind an die stelle des Knotens bringen
                rootNode = left;
            else if (parent.left == node)
                parent.left = left;
            else
                parent.right = left;
            left.parent = parent;

            node.left = leftRight; //Rechtes Kind des linken Kindes wird linkes Kind des Knotens
            if (leftRight != null)
                leftRight.parent = node;

            left.right = node; //Knoten wird rechtes Kind des linken Kindes
            node.parent = left;                      
        }

        private void rotLeft(AVLTreeNode node)
        {
            AVLTreeNode right = node.right as AVLTreeNode;
            AVLTreeNode rightLeft = right.left as AVLTreeNode;
            AVLTreeNode parent = node.parent;

            if (node == rootNode) //Rechtes Kind an die Stelle des Knotens bringen
                rootNode = node.right;
            else if (parent.right == node)
                parent.right = right;
            else
                parent.left = right;
            right.parent = parent;

            node.right = rightLeft; //Linkes Kind des rechten Kindes wird rechtes Kind des Knotens
            if (rightLeft != null)
                rightLeft.parent = node;

            right.left = node; //Knoten wird linkes Kind des rechten Kindes
            node.parent = right;            
        }
    }
}
