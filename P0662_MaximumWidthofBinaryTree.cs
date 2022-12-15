using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0662_MaximumWidthofBinaryTree
    {
        public class Solution
        {
            public int WidthOfBinaryTree(TreeNode root)
            {
                if (root == null) return 0;
                var max = 1;
                var l = new LinkedList<TreeNode>();
                root.val = 1;
                l.AddLast(root);
                while (l.Count > 0)
                {
                    max = Math.Max(max, l.Last.Value.val - l.First.Value.val + 1);
                    var l1 = new LinkedList<TreeNode>();
                    while (l.Count > 0)
                    {
                        if (l.First.Value.left != null)
                        {
                            l.First.Value.left.val = l.First.Value.val * 2 - 1;
                            l1.AddLast(l.First.Value.left);
                        }
                        if (l.First.Value.right != null)
                        {
                            l.First.Value.right.val = l.First.Value.val * 2; ;
                            l1.AddLast(l.First.Value.right);
                        }
                        l.RemoveFirst();
                    }
                    l = l1;
                }
                return max;
            }
        }
        public class Solution_Exceed_Time_Limit
        {
            public int WidthOfBinaryTree(TreeNode root)
            {
                if (root == null) return 0;
                var max = 1;
                var l = new LinkedList<TreeNode>();
                l.AddLast(root);
                while (l.Count > 0)
                {
                    var count = l.Count;
                    max = Math.Max(max, count);
                    while (l.First != null && l.First.Value.left == null && l.First.Value.right == null)
                    {
                        l.RemoveFirst();
                    }
                    while (l.Last != null && l.Last.Value.left == null && l.Last.Value.right == null)
                    {
                        l.RemoveLast();
                    }
                    var l1 = new LinkedList<TreeNode>();
                    if (l.Count == 0)
                    {
                        break;
                    }
                    else if (l.Count == 1)
                    {
                        if (l.First.Value.left != null)
                        {
                            l1.AddLast(l.First.Value.left);
                        }
                        if (l.First.Value.right != null)
                        {
                            l1.AddLast(l.First.Value.right);
                        }
                        l.RemoveFirst();
                    }
                    else
                    {
                        if (l.First.Value.left != null)
                        {
                            l1.AddLast(l.First.Value.left);
                        }
                        l1.AddLast(l.First.Value.right ?? new TreeNode());
                        l.RemoveFirst();
                        while (l.Count > 1)
                        {
                            l1.AddLast(l.First.Value.left ?? new TreeNode());
                            l1.AddLast(l.First.Value.right ?? new TreeNode());
                            l.RemoveFirst();
                        }
                        l1.AddLast(l.First.Value.left ?? new TreeNode());
                        if (l.First.Value.right != null)
                        {
                            l1.AddLast(l.First.Value.right);
                        }
                    }
                    l = l1;
                }
                return max;
            }
        }
    }
}
