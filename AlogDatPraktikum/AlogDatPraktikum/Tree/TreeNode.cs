using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    class TreeNode
    {
        public DictElement elem;
        public TreeNode right;
        public TreeNode left;

        public TreeNode(int value)
        {
            this.elem = new DictElement(value);
        }

        public void _Print_(int level, Direction dir)
        {
            string output = new String(' ', 5 * level);
            if (dir == Direction.left)
                output += "\\";
            else if (dir == Direction.right)
                output += "/";
            output += elem.elemValue;            
            Console.WriteLine(output);
        }
    }
}
