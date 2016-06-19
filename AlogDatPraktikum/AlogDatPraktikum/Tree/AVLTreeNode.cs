using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class AVLTreeNode : TreeNode
    {
        public int BalanceFaktor;
        public AVLTreeNode parent;

        public AVLTreeNode(int value, AVLTreeNode parent) : base(value)
        {
            BalanceFaktor = 0;
            this.parent = parent;
        }

        new public void _Print_(int level, Direction dir)
        {
            string output = new String(' ', 5 * level);
            if (dir == Direction.left)
                output += "\\";
            else if (dir == Direction.right)
                output += "/";
            output += elem.elemValue;
            output += "[" + BalanceFaktor + "]";
            Console.WriteLine(output);
        }               
    }
}
