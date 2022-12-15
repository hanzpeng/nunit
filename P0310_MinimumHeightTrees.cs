using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0310_MinimumHeightTrees
    {
        public class Solution_ExcedingTimeList

        {
            public IList<int> FindMinHeightTrees(int n, int[][] edges)
            {
                var connects = new HashSet<int>[n];
                for (int i = 0; i < n; i++)
                {
                    connects[i] = new HashSet<int>();
                }
                foreach (var edge in edges)
                {
                    connects[edge[0]].Add(edge[1]);
                    connects[edge[1]].Add(edge[0]);
                }
                var heights = new int[n];
                var minHeight = n;
                for (int i = 0; i < n; i++)
                {
                    heights[i] = GetHeight(connects, i, new bool[n]);
                    minHeight = Math.Min(minHeight, heights[i]);
                }
                var res = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    if (heights[i] == minHeight)
                    {
                        res.Add(i);
                    }
                }
                return res;
            }
            public int GetHeight(HashSet<int>[] connects, int i, bool[] visited)
            {
                var maxHeight = 1;
                visited[i] = true;
                foreach (var conn in connects[i])
                {
                    if (!visited[conn])
                    {
                        maxHeight = Math.Max(maxHeight, 1 + GetHeight(connects, conn, visited));
                    }
                }
                return maxHeight;
            }
        }
    }
}
