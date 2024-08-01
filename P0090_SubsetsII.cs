
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
            Array.Sort(nums);
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

            // select current value to the set, and then try next value
            cur.Push(nums[index]);
            dfs(nums, res, cur, index + 1);
            cur.Pop();

            // while next value is a dup, skip next value
            while (index + 1 < nums.Length && nums[index + 1] == nums[index])
                index++;

            // not select current value and try next different value
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

    public class Solution_DP_Iter_A
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var dp = new List<IList<int>>();
            var frequency = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
            }
            dp.Add(new List<int>());
            foreach (var num in frequency.Keys)
            {
                var dpCount = dp.Count;
                for (int j = 0; j < dpCount; j++)
                {
                    for (int freq = 1; freq <= frequency[num]; freq++)
                    {
                        var list = new List<int>(dp[j]);
                        for (int k = 1; k <= freq; k++)
                        {
                            list.Add(num);
                        }
                        dp.Add(list);
                    }
                }
            }
            return dp;
        }
    }
    public class Solution_DP_Iter_B
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var dp = new List<IList<int>>();
            dp.Add(new List<int>());
            var frequency = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
            }
            foreach (var num in frequency.Keys)
            {
                var count = dp.Count;
                for (int i = 0; i < count; i++)
                {
                    var list = new List<int>(dp[i]);
                    for (int freq = 0; freq < frequency[num]; freq++)
                    {
                        list.Add(num);
                        dp.Add(list);
                        list = new List<int>(list);
                    }
                }
            }
            return dp;
        }
    }

    public class Solution_DP_Iter_C
    {
        public class Solution
        {
            public IList<IList<int>> SubsetsWithDup(int[] nums)
            {
                Array.Sort(nums);
                var dp = new List<IList<int>>();
                dp.Add(new List<int>());
                var dpCount = dp.Count();
                for (int i = 0; i < nums.Length; i++)
                {
                    var start = i > 0 && nums[i] == nums[i - 1] ? dpCount : 0;
                    dpCount = dp.Count;
                    for (int j = start; j < dpCount; j++)
                    {
                        var list = new List<int>(dp[j]);
                        list.Add(nums[i]);
                        dp.Add(list);
                    }
                }
                return dp;
            }
        }
    }

    public class Solution_DP_Iter_D {
        public IList<IList<int>> SubsetsWithDup(int[] nums) {
            var res = new List<IList<int>>();
            res.Add(new List<int>());
            if (nums == null || nums.Length == 0) return res;
            Array.Sort(nums);
            int? prevNum = null;
            var res1 = new List<IList<int>>();
            var res2 = new List<IList<int>>();
            for (var i = 0; i < nums.Length; i++) {
                var num = nums[i];
                if (prevNum == num) {
                    res2 = new List<IList<int>>(res1);
                } else {
                    res2 = res;
                }
                prevNum = num;
                res1 = new List<IList<int>>();
                foreach (var li in res2) {
                    var li1 = new List<int>(li);
                    li1.Add(num);
                    res1.Add(li1);
                }
                res.AddRange(res1);
            }
            return res;
        }
    }
}
