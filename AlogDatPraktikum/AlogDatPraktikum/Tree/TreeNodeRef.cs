using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlogDatPraktikum
{
    enum Direction { undef, left, right };

    class TreeNodeRef
    {
        public TreeNode parent;
        public TreeNode node;
        public Direction dir;

        public TreeNodeRef(TreeNode parent, TreeNode node, Direction dir)
        {
            this.parent = parent;
            this.node = node;
            this.dir = dir;
        }
    }
}
