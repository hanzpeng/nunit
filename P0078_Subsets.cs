
using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
namespace P0078_Subsets
{
    public class P0078_Subsets
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1);
            List<List<int>> result = Subsets_dp(new int[] { 1, 2, 3, 4 });

            foreach (var li in result)
            {
                foreach (var n in li)
                {
                    Console.Write(n + ", ");
                }
                Console.WriteLine();
            }
            /*
                1,
                
                2, 
                1, 2, 

                3, 
                1, 3, 
                2, 3, 
                1, 2, 3, 

                4, 
                1, 4, 
                2, 4, 
                1, 2, 4, 
                3, 4, 
                1, 3, 4, 
                2, 3, 4, 
                1, 2, 3, 4, 
             */

        }
        public List<List<int>> Subsets_dp(int[] nums)
        {
            List<List<int>> dp = new List<List<int>>();
            dp.Add(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                int curCount = dp.Count;
                for (int j = 0; j < curCount; j++)
                {
                    var newList = new List<int>(dp[j]);
                    newList.Add(nums[i]);
                    dp.Add(new List<int>(newList));
                }
            }
            return dp;
        }

        public IList<IList<int>> Subsets_regression(int[] nums)
        {
            var res = new List<IList<int>>();
            if (nums?.Length == 0) return res;
            regression(nums, res, new Stack<int>(), 0);
            return res;
        }
        public void regression(int[] nums, IList<IList<int>> res, Stack<int> cur, int index)
        {
            if (index == nums.Length)
            {
                res.Add(new List<int>(cur));
                return;
            }

            regression(nums, res, cur, index + 1);

            cur.Push(nums[index]);
            regression(nums, res, cur, index + 1);
            cur.Pop();
        }

    }
}
