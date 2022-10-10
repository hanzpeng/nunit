using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace Leetcode
{
    public class P0098_ValidBST
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1);
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public bool IsValidBST(TreeNode root, int? min = null, int? max = null)
        {
            if (root == null) return true;
            if ((min.HasValue && root.val <= min) || (max.HasValue && root.val >= max)) return false;
            return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
        }
    }
}