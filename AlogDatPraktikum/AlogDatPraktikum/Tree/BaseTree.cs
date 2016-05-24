using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    abstract class BaseTree
    {
        public TreeNode rootNode;

        public void Print()
        {
            if (rootNode != null)
                _Print_(rootNode);
            else
                Console.WriteLine("Baum ist leer.");
        }

        protected void _Print_(TreeNode node, int level = 0)
        {
            //Teilbaum rechts ausgeben
            if (node.right != null)
                _Print_(node.right, level + 1);
            //element ausgeben
            string output = new String(' ', 8 * level) + node.elem.elemValue;
            if (node.GetType() == typeof(AVLTreeNode))
                output += "[" + (node as AVLTreeNode).BalanceFaktor + "]";
            Console.WriteLine(output);
            //Teilbaum links ausgeben
            if (node.left != null)
                _Print_(node.left, level + 1);

        }
    }
}
