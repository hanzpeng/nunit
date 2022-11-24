
using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
namespace P0090_SubsetsII
{
    public class P0078_Subsets
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1);
            var result = Subsets(new int[] { 1, 2, 3, 4 });

            foreach (var li in result)
            {
                foreach (var n in li)
                {
                    Console.Write(n + ", ");
                }
                Console.WriteLine();
            }
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            var res = new List<IList<int>>();
            if (nums?.Length == 0) return res;
            dfs(nums, res, new Stack<int>(), 0);
            return res;
        }
        public void dfs(int[] nums, IList<IList<int>> res, Stack<int> cur, int index)
        {
            if (index == nums.Length)
            {
                res.Add(new List<int>(cur));
                return;
            }

            cur.Push(nums[index]);
            dfs(nums, res, cur, index + 1);
            cur.Pop();

            if (index + 1 < nums.Length && nums[index + 1] == nums[index])
                index++;

            dfs(nums, res, cur, index + 1);
        }

    }
}
