using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0103_BinaryTreeZigzagLevelOrderTraversal
    {
        public class Solution
        {
            public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
            {
                var res = new List<IList<int>>();
                if (root == null) return res;
                var q = new Queue<TreeNode>();
                q.Enqueue(root);
                bool leftToRight = true;
                while (q.Count > 0)
                {
                    var list = new LinkedList<int>();
                    for (int i = q.Count; i > 0; i--)
                    {
                        var cur = q.Dequeue();
                        if (cur.left != null) q.Enqueue(cur.left);
                        if (cur.right != null) q.Enqueue(cur.right);
                        if (leftToRight) list.AddLast(cur.val);
                        else list.AddFirst(cur.val);
                    }
                    res.Add(list.ToList());
                    leftToRight = !leftToRight;
                }
                return res;
            }
        }
    }
}
