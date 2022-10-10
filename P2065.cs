using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace Leetcode
{
    public class P2065
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1);
            Assert.AreEqual(75, new Solution().MaximalPathQuality(new int[] { 0, 32, 10, 43 }, new int[][] { new int[] { 0, 1, 10 }, new int[] { 1, 2, 15 }, new int[] { 0, 3, 10 } }, 49));
            Assert.AreEqual(25, new Solution().MaximalPathQuality(new int[] { 5, 10, 15, 20 }, new int[][] { new int[] { 0, 1, 10 }, new int[] { 1, 2, 10 }, new int[] { 0, 3, 10 } }, 30));
            Assert.AreEqual(7, new Solution().MaximalPathQuality(new int[] { 1, 2, 3, 4 }, new int[][] { new int[] { 0, 1, 10 }, new int[] { 1, 2, 11 }, new int[] { 2, 3, 12 }, new int[] { 1, 3, 13 } }, 50));
            Assert.AreEqual(0, new Solution().MaximalPathQuality(new int[] { 0, 1, 2 }, new int[][] { new int[] { 1, 2, 10 } }, 10));
        }
        public class Solution
        {
            public int MaximalPathQuality(int[] values, int[][] edges, int maxTime)
            {
                Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();
                Dictionary<string, int> t = new Dictionary<string, int>();
                for (int i = 0; i < values.Length; i++)
                {
                    g[i] = new List<int>();
                }
                foreach (var e in edges)
                {
                    g[e[0]].Add(e[1]);
                    g[e[1]].Add(e[0]);
                    t[Key(e[0], e[1])] = e[2];
                }
                var hitCount = new int[values.Length];
                hitCount[0]++;
                int maxQuality = 0;
                Dfs(g, t, 0, 0, maxTime, edges, values, hitCount, ref maxQuality);
                return maxQuality;
            }
            void Dfs(Dictionary<int, List<int>> g, Dictionary<string, int> t, int node, int quality, int time, int[][] edges, int[] values, int[] hitCount, ref int maxQuality)
            {
                if (time < 0) return;
                if (hitCount[node] == 1) quality += values[node];
                if (node == 0) maxQuality = Math.Max(quality, maxQuality);
                foreach (int next in g[node])
                {
                    hitCount[next]++;
                    Dfs(g, t, next, quality, time - t[Key(node, next)], edges, values, hitCount, ref maxQuality);
                    hitCount[next]--; // backtracking
                }
            }
            string Key(int u, int v) => Math.Min(u, v) + "," + Math.Max(u, v);
        }
    }
}
