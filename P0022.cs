using NUnit.Framework;
using System.Collections.Generic;

namespace Leetcode
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
}
