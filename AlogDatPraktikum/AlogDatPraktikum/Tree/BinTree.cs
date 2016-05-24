using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class BinTree : BaseTree, SortedSet
    {
        public bool Search(int elem)
        {
            TreeNode node = _Search_(elem);
            if (node == null)
                return false;
            return true;
        }

        public virtual bool Insert(int elem)
        {
            TreeNodeRef searchRef = _SearchRef_(elem);
            if (searchRef.node != null)
                return false;
            if (searchRef.parent == null)
                rootNode = new TreeNode(elem);
            else if (searchRef.dir == Direction.left)
                searchRef.parent.left = new TreeNode(elem);
            else
                searchRef.parent.right = new TreeNode(elem);
            return true;
        }

        public virtual bool Delete(int elem)
        {
            TreeNodeRef searchRef = _SearchRef_(elem);

            if (searchRef.node == null) //Element nicht vorhanden
                return false;

            TreeNode shiftNode = null;
            if (searchRef.node.left != null && searchRef.node.right != null)
            {
                _Delete_(searchRef.node);
                return true;
            }
            else if (searchRef.node.left == null)
                shiftNode = searchRef.node.right;
            else
                shiftNode = searchRef.node.left;

            if (rootNode == searchRef.node)
                rootNode = shiftNode;
            else if (searchRef.dir == Direction.left)
                searchRef.parent.left = shiftNode;
            else
                searchRef.parent.right = shiftNode;

            return true;
        }


        private TreeNode _Search_(int elem)
        {
            TreeNode a = rootNode;
            while (a != null && a.elem.elemValue != elem)
            {
                if (elem < a.elem.elemValue)
                    a = a.left;
                else
                    a = a.right;
            }
            return a;
        }

        protected TreeNodeRef _SearchRef_(int elem)
        {
            TreeNode node = rootNode;
            TreeNode parent = null;
            Direction dir = Direction.undef;

            while (node != null)
            {
                if (elem < node.elem.elemValue)
                {
                    parent = node;
                    node = node.left;
                    dir = Direction.left;
                }
                else if (elem > node.elem.elemValue)
                {
                    parent = node;
                    node = node.right;
                    dir = Direction.right;
                }
                else
                    break;
            }
            TreeNodeRef searchRef = new TreeNodeRef(parent, node, dir);
            return searchRef;
        }

        private void _Delete_(TreeNode node) //Wird nur aufgerufen, wenn node zwei Kinder hat
        {
            TreeNode temp = node;
            TreeNode shiftNode = null;

            if (temp.left.right != null)
            {
                temp = temp.left;
                while (temp.right.right != null)
                    temp = temp.right;
            }
            if (temp == node)
            {
                shiftNode = temp.left;
                temp.left = shiftNode.left;
            }
            else
            {
                shiftNode = temp.right;
                temp.right = shiftNode.left;
            }
            node.elem.elemValue = shiftNode.elem.elemValue;
        }
    }
}
