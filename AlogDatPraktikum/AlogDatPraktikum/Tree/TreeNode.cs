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
    }
}
