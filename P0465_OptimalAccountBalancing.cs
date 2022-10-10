using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0465_OptimalAccountBalancing
    {
        public class Solution
        {
            public int MinTransfers(int[][] transactions)
            {
                Dictionary<int, int> map = new();
                List<int> list = new();
                foreach (var trans in transactions)
                {
                    map[trans[0]] = map.GetValueOrDefault(trans[0], 0) + trans[2];
                    map[trans[1]] = map.GetValueOrDefault(trans[1], 0) - trans[2];
                }
                foreach (var val in map.Values)
                    if (val != 0) list.Add(val);

                return dfs(0, list);
            }

            public int dfs(int k, List<int> list)
            {
                if (k == list.Count) return 0;
                if (list[k] == 0) return dfs(k + 1, list);

                int cur = list[k];
                int min = int.MaxValue;
                for (int i = k + 1; i < list.Count; i++)
                {
                    int next = list[i];
                    if (cur * next < 0)
                    {
                        list[i] = cur + next;
                        min = Math.Min(min, 1 + dfs(k + 1, list));
                        list[i] = next;
                        if (cur + next == 0) break;
                    }

                }
                return min;
            }
        }
    }
}
