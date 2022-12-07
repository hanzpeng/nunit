using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0124_BinaryTreeMaxPathSum
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
            var rSum= PathSum(root.right, ref answer);
            answer = Math.Max(answer, lSum + rSum + root.val);
            return Math.Max(0, Math.Max(lSum, rSum) + root.val);
        }

    }
}
