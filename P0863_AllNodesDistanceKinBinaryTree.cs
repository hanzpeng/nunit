using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0863_AllNodesDistanceKinBinaryTree
    {
        public class Solution
        {
            public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
            {
                var res = new List<int>();
                FindTarget(root, target, k, res);
                return res;
            }
            public int FindTarget(TreeNode root, TreeNode target, int k, List<int> res)
            {
                if (root == null || k < 0) return -1;
                if (root == target)
                {
                    if (k > 0)
                    {
                        printChildren(root.left, k - 1, res);
                        printChildren(root.right, k - 1, res);
                        return k;
                    }
                    if (k == 0)
                    {
                        res.Add(root.val);
                        return 0;
                    }
                }
                bool targetInLeft = true;
                var childRes = FindTarget(root.left, target, k, res);
                if (childRes == -1)
                {
                    childRes = FindTarget(root.right, target, k, res);
                    targetInLeft = false;
                }
                if (childRes == 0)
                {
                    return 0;
                }
                if (childRes == 1)
                {
                    res.Add(root.val);
                    return 0;
                }
                if (childRes > 1)
                {
                    if (targetInLeft) printChildren(root.right, childRes - 2, res);
                    else printChildren(root.left, childRes - 2, res);
                    return childRes - 1;
                }
                if (childRes < 0)
                {
                    return -1;
                }
                return -1;
            }
            public void printChildren(TreeNode root, int k, List<int> res)
            {
                if (root == null || k < 0) return;
                if (k == 0)
                {
                    res.Add(root.val);
                    return;
                }
                if (k > 0)
                {
                    printChildren(root.left, k - 1, res);
                    printChildren(root.right, k - 1, res);
                }
                return;
            }
        }
    }
}
