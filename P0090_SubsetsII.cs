
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

    public class SolutionB
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Dictionary<int, int> numCount = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                numCount[num] = numCount.GetValueOrDefault(num, 0) + 1;
            }
            IList<IList<int>> res = new List<IList<int>>();
            Dfs(numCount, new List<int>(numCount.Keys), new Stack<int>(), res, 0);
            return res;
        }
        void Dfs(Dictionary<int, int> numCount, List<int> keys, Stack<int> cur, IList<IList<int>> res, int index)
        {
            if (index == keys.Count)
            {
                res.Add(new List<int>(cur));
                return;
            }
            for (int i = 1; i <= numCount[keys[index]]; i++)
            {
                for (int j = 0; j < i; j++) cur.Push(keys[index]);
                Dfs(numCount, keys, cur, res, index + 1);
                for (int j = 0; j < i; j++) cur.Pop();
            }
            Dfs(numCount, keys, cur, res, index + 1);
        }
    }
}
