using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0124_BinaryTreeMaxPathSum
    {
        public class Solution1
        {
            public int MaxPathSum(TreeNode root)
            {
                int answer = int.MinValue;
                PathSum(root, ref answer);
                return answer;
            }
            public int PathSum(TreeNode root, ref int answer)
            {
                if (root == null) return 0;
                var lSum = PathSum(root.left, ref answer);
                var rSum = PathSum(root.right, ref answer);
                answer = Math.Max(answer, lSum + rSum + root.val);
                return Math.Max(0, Math.Max(lSum, rSum) + root.val);
            }
        }

        public class Solution2
        {
            public int MaxPathSum(TreeNode root)
            {
                if (root == null) return 0;
                long max = int.MinValue;
                MaxPathSum(root, out long currentLegSum, ref max);
                return (int)max;
            }
            public void MaxPathSum(TreeNode root, out long currentLegSum, ref long max)
            {
                if (root == null)
                {
                    currentLegSum = 0;
                    return;
                }
                MaxPathSum(root.left, out long leftChildSum, ref max);
                MaxPathSum(root.right, out long rightChildSum, ref max);
                currentLegSum = root.val; // only current node
                currentLegSum = Math.Max(currentLegSum, leftChildSum + root.val); // current + left
                currentLegSum = Math.Max(currentLegSum, rightChildSum + root.val); // current + right
                max = Math.Max(max, leftChildSum + root.val + rightChildSum); // left + curent + right
                max = Math.Max(max, currentLegSum);
            }
        }

    }
}
