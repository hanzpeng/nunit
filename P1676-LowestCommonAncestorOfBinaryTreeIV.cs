using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P1676_LowestCommonAncestorOfBinaryTreeIV
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes)
        {
            var values = nodes.Select(n => n.val).ToList().ToHashSet();
            return TopNOde(root, values);
        }

        public TreeNode TopNOde(TreeNode cur, HashSet<int> values)
        {
            if (cur == null) return null;

            if (values.Contains(cur.val)) return cur;

            var topLeft = TopNOde(cur.left, values);
            var topRight = TopNOde(cur.right, values);

            if (topLeft != null && topRight != null) return cur;
            if (topLeft != null) return topLeft;
            if (topRight != null) return topRight;
            return null;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
