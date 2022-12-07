using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0297_SerializeandDeserializeBinaryTree
    {
    }
    //public class TreeNode
    //{
    //    public int val;
    //    public TreeNode left;
    //    public TreeNode right;
    //    public TreeNode(int x) { val = x; }
    //}
    public class Codec
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return "*";
            var lStr = serialize(root.left);
            var rStr = serialize(root.right);
            return "" + root.val + "v" + lStr.Length + "l" + rStr.Length + "r" + lStr + rStr;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == "*") return null;
            int vEnd = data.IndexOf('v');
            int lEnd = data.IndexOf('l');
            int rEnd = data.IndexOf('r');
            string vS = data.Substring(0, vEnd);
            string lS = data.Substring(vEnd + 1, lEnd - vEnd - 1);
            string rS = data.Substring(lEnd + 1, rEnd - lEnd - 1);
            int v = int.Parse(vS);
            int l = int.Parse(lS);
            int r = int.Parse(rS);
            string leftS = data.Substring(rEnd + 1, l);
            string righS = data.Substring(rEnd + 1 + l, r);
            return new TreeNode(v)
            {
                left = deserialize(leftS),
                right = deserialize(righS)
            };
        }
    }
}
