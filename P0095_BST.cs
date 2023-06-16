using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0095_BST
    {
        class Solution
        {
            public List<TreeNode> GenerateTrees(int n)
            {
                if (n == 0)
                {
                    return new List<TreeNode>();
                }
                return Generate_trees(1, n);
            }

            public List<TreeNode> Generate_trees(int start, int end)
            {
                List<TreeNode> all_trees = new List<TreeNode>();
                if (start > end)
                {
                    all_trees.Add(null);
                    return all_trees;
                }

                // pick up a root
                for (int i = start; i <= end; i++)
                {
                    // all possible left subtrees if i is choosen to be a root
                    List<TreeNode> left_trees = Generate_trees(start, i - 1);

                    // all possible right subtrees if i is choosen to be a root
                    List<TreeNode> right_trees = Generate_trees(i + 1, end);

                    // connect left and right trees to the root i
                    foreach (TreeNode l in left_trees)
                    {
                        foreach (TreeNode r in right_trees)
                        {
                            TreeNode current_tree = new TreeNode(i);
                            current_tree.left = l;
                            current_tree.right = r;
                            all_trees.Add(current_tree);
                        }
                    }
                }
                return all_trees;
            }
        }
    }
}
