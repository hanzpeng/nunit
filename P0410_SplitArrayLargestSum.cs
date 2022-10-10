using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace P0410_SplitArrayLargestSum
{
    internal class P0410_SplitArrayLargestSum
    {
        class Program
        {
            [Test]
            public void Test()
            {
                var p = new Program();
                var res = p.SplitArray(new int[] { 1, 4, 4 }, 3);
                Console.WriteLine(res);
                res = p.SplitArray(new int[] { 0, 8, 1, 4 }, 4);
                Console.WriteLine(res);
            }
            public int SplitArray(int[] nums, int m)
            {
                int n = nums.Length;
                int[] sums = new int[n];
                sums[0] = nums[0];
                for (int i = 1; i < n; i++)
                {
                    sums[i] = sums[i - 1] + nums[i];
                }
                int[][] dp = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    dp[i] = new int[m + 1];
                    dp[i][1] = sums[i];
                    for (int j = 2; j <= m; j++)
                    {
                        dp[i][j] = int.MaxValue;
                    }
                }
                for (int j = 2; j <= m; j++)
                {
                    for (int i = j - 1; i < n; i++)
                    {
                        for (int k = 0; k < i && k >= 0; k++)
                        {
                            int curMax = Math.Max(dp[k][j - 1], sums[i] - sums[k]);
                            dp[i][j] = Math.Min(dp[i][j], curMax);
                        }
                    }
                }
                return dp[n - 1][m];
            }
        }
    }
}
