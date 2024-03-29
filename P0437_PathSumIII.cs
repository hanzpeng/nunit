﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0437_PathSumIII
    {
        public class Solution
        {
            public int PathSum(TreeNode root, int targetSum)
            {
                if (root == null) return 0;
                return PathSum(root.left, targetSum) + PathSum(root.right, targetSum) + StartPathSum(root, targetSum);
            }
            public int StartPathSum(TreeNode root, long target)
            {
                if (root == null) return 0;
                return StartPathSum(root.left, target - root.val) + StartPathSum(root.right, target - root.val) + (target == root.val ? 1 : 0);
            }
        }
    }
}
