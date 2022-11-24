
using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
namespace P0090_SubsetsII
{
    public class P0090_Subsets
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1);
            var result = SubsetsWithDup(new int[] { 1, 2, 3, 4 });

            foreach (var li in result)
            {
                foreach (var n in li)
                {
                    Console.Write(n + ", ");
                }
                Console.WriteLine();
            }
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
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

    public class Solution2
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Dictionary<int, int> numsMap = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                numsMap[num] = numsMap.GetValueOrDefault(num, 0) + 1;
            }

            IList<IList<int>> result = new List<IList<int>>();
            Dfs(numsMap, new List<int>(numsMap.Keys), new Stack<int>(), result, 0);
            return result;
        }
        void Dfs(Dictionary<int, int> numsMap, List<int> keys, Stack<int> cur, IList<IList<int>> res, int index)
        {
            if (index == keys.Count)
            {
                res.Add(new List<int>(cur));
                return;
            }

            Dfs(numsMap, keys, cur, res, index + 1);

            var curKey = keys[index];
            var count = numsMap[curKey];

            for (int i = 1; i <= count; i++)
            {
                for (int j = 0; j < i; j++) cur.Push(curKey);
                Dfs(numsMap, keys, cur, res, index + 1);
                for (int j = 0; j < i; j++) cur.Pop();
            }

        }
    }
}
