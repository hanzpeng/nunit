﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P1145_BinaryTreeColoringGame
    {
        //1145. Binary Tree Coloring Game
        public bool BtreeGameWinningMove(TreeNode root, int n, int x)
        {
            if (root == null) return false;
            return BtreeGameWinningMove(root, n, x, null);
        }

        public bool BtreeGameWinningMove(TreeNode cur, int n, int x, TreeNode p)
        {
            if (cur == null) return false;
            if (cur.val == x)
            {
                if (Count(cur.left) > n / 2) return true;
                if (Count(cur.right) > n / 2) return true;
                if (p != null && Count(cur) <= n / 2) return true;
                return false;
            }
            return BtreeGameWinningMove(cur.left, n, x, cur) || BtreeGameWinningMove(cur.right, n, x, cur);
        }

        public int Count(TreeNode cur)
        {
            if (cur == null) return 0;
            return 1 + Count(cur.left) + Count(cur.right);
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
