using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0105_ConstructBinaryTreefromPreorderandInorderTraversal
    {
        public class Solution
        {
            public TreeNode BuildTree(int[] preorder, int[] inorder)
            {
                var index = new Dictionary<int, int>();
                for (int i = 0; i < inorder.Length; i++)
                {
                    index[inorder[i]] = i;
                }
                return BuildTree(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1, index);
            }
            public TreeNode BuildTree(int[] preorder, int[] inorder, int pre1, int pre2, int in1, int in2, Dictionary<int, int> index)
            {
                if (pre1 > pre2 || pre1 >= preorder.Length || pre2 >= preorder.Length) return null;
                if (in1 > in2 || in1 >= inorder.Length || in2 >= inorder.Length) return null;
                var root = new TreeNode(preorder[pre1]);
                var mid = index[preorder[pre1]];
                var lLen = mid - in1;
                var rLen = in2 - mid;
                root.left = BuildTree(preorder, inorder, pre1 + 1, pre1 + lLen, in1, in1 + lLen - 1, index);
                root.right = BuildTree(preorder, inorder, pre1 + lLen + 1, pre1 + lLen + rLen, mid + 1, mid + rLen, index);
                return root;
            }
        }
    }
}
