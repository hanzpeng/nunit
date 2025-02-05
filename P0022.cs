using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace P0022
{
    public class P0022
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1);
        }
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            backtrack(result, n, 0, 0, "");
            return result;
        }
        //c# string is passed by value
        void backtrack(List<string> result, int n, int left, int right, string str)
        {
            if (left == n)
            {
                for (int i = 1; i <= n - right; i++)
                {
                    str += ")";
                }
                result.Add(str);
                return;
            }
            else if (left == right)
            {
                backtrack(result, n, left + 1, right, str + "(");
            }
            else if (left > right)
            {
                backtrack(result, n, left + 1, right, str + "(");
                backtrack(result, n, left, right + 1, str + ")");
            }
            else{
                //should not come here
            }
        }
    }

    public class Solution {
        public IList<string> GenerateParenthesis(int n) {
            var res = new List<string>();
            Bt(n, 1, res, new Stack<char>(), 0, 0);
            return res;
        }

        void Bt(int n, int index, List<string> res, Stack<char> stack, int l, int r) {
            if (index == 2 * n + 1) {
                res.Add(new string(stack.Reverse().ToArray()));
                return;
            }
            // add (
            if (l < n) {
                stack.Push('(');
                Bt(n, index + 1, res, stack, l + 1, r);
                stack.Pop();
            }

            if (r < l) {
                stack.Push(')');
                Bt(n, index + 1, res, stack, l, r + 1);
                stack.Pop();
            }
        }
    }
}
