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
            if (searchRef.node != null)
                return false;
            if (searchRef.parent == null)
            {
                rootNode = new AVLTreeNode(elem, null);
                return true;
            }
            else if (searchRef.dir == Direction.left)
            {
                searchRef.parent.left = new AVLTreeNode(elem, searchRef.parent as AVLTreeNode);
                _InsertBalance_(searchRef.parent as AVLTreeNode, -1);
            }
            else
            {
                searchRef.parent.right = new AVLTreeNode(elem, searchRef.parent as AVLTreeNode);
                _InsertBalance_(searchRef.parent as AVLTreeNode, +1);
            }
            return true;
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
                _DeleteBalance_(temp.parent, 1);
            }
            else //Kein linkes Kind vorhanden -> suche direkten Nachbar im rechten Teilbaum
            {
                AVLTreeNode temp = searchRef.node.right as AVLTreeNode;
                while (temp.left != null)
                    temp = temp.right as AVLTreeNode;
                shiftNode(temp, searchRef.node as AVLTreeNode);
                _DeleteBalance_(temp.parent, -1);
            }

            return true;
        }

        private void shiftNode(AVLTreeNode source, AVLTreeNode target) //source hat entweder kein Kind oder nur ein Kind
        {
            target.elem.elemValue = source.elem.elemValue; //Wert umschreiben

            if (source.left != null) //nur linkes Kind
            {
                if (source.parent.left == source)
                    source.parent.left = source.left;
                else
                    source.parent.right = source.left;
            }
            else  //nur rechtes Kind oder kein Kind
            {
                if (source.parent.left == source)
                    source.parent.left = source.right;
                else
                    source.parent.right = source.right;
            }
        }

        private void _DeleteBalance_(AVLTreeNode node, int balance)
        {
            while (node != null)
            {
                node.BalanceFaktor += balance;
                if (node.BalanceFaktor == -2)
                {
                    if ((node.left as AVLTreeNode).BalanceFaktor >= 0)
                    {
                        rotLeft(node);
                        if (node.BalanceFaktor == 1)
                            return;
                    }
                    else
                        rotLeftRight(node);
                }
                else if (node.BalanceFaktor == 2)
                {
                    if ((node.right as AVLTreeNode).BalanceFaktor <= 0)
                    {
                        rotRight(node);
                        if (node.BalanceFaktor == -1)
                            return;
                    }
                    else
                        rotRightLeft(node);
                }
                else if (node.BalanceFaktor != 0)
                    return;

                AVLTreeNode parent = node.parent;
                if (parent != null)
                {
                    if (parent.left == node)
                        balance = 1;
                    else
                        balance = -1;
                }
                node = parent;
            }
        }

        private void _InsertBalance_(AVLTreeNode node, int balance)
        {
            while (node != null)
            {
                node.BalanceFaktor += balance;
                if (node.BalanceFaktor == 0)
                    return;
                else if (node.BalanceFaktor == -2)
                {
                    if ((node.left as AVLTreeNode).BalanceFaktor == 1)
                        rotLeftRight(node);
                    else
                        rotRight(node);
                    return;
                }
                else if (node.BalanceFaktor == 2)
                {
                    if ((node.right as AVLTreeNode).BalanceFaktor == -1)
                        rotRightLeft(node);
                    else
                        rotLeft(node);
                    return;
                }

                AVLTreeNode parent = node.parent;
                if (parent != null)
                {
                    if (parent.left == node)
                        balance = -1;
                    else
                        balance = 1;
                }
                node = parent;
            }
        }

        private void rotRight(AVLTreeNode node)
        {
            //Console.WriteLine("Rechtsrot um " + node.elem.elemValue);

            AVLTreeNode left = node.left as AVLTreeNode;
            AVLTreeNode leftRight = left.right as AVLTreeNode;
            AVLTreeNode parent = node.parent;

            left.parent = parent;
            left.right = node;
            node.left = leftRight;
            node.parent = left;

            if (leftRight != null)
                leftRight.parent = node;

            if (node == rootNode)
                rootNode = left;
            else if (parent.left == node)
                parent.left = left;
            else
                parent.right = left;

            left.BalanceFaktor += 1;
            node.BalanceFaktor = -left.BalanceFaktor;
        }

        private void rotLeft(AVLTreeNode node)
        {
            //Console.WriteLine("Linksrot um " + node.elem.elemValue);

            AVLTreeNode right = node.right as AVLTreeNode;
            AVLTreeNode rightLeft = right.left as AVLTreeNode;
            AVLTreeNode parent = node.parent;

            right.parent = parent;
            right.left = node;
            node.right = rightLeft;
            node.parent = right;

            if (rightLeft != null)
                rightLeft.parent = node;

            if (node == rootNode)
                rootNode = right;
            else if (parent.right == node)
                parent.right = right;
            else
                parent.left = right;

            right.BalanceFaktor -= 1;
            node.BalanceFaktor = -right.BalanceFaktor;
        }

        private void rotRightLeft(AVLTreeNode node)
        {
            rotRight(node.right as AVLTreeNode);
            ++(node.right.right as AVLTreeNode).BalanceFaktor;
            rotLeft(node);
        }

        private void rotLeftRight(AVLTreeNode node)
        {
            rotLeft(node.left as AVLTreeNode);
            --(node.left.left as AVLTreeNode).BalanceFaktor;
            rotRight(node);
        }


    }
}
