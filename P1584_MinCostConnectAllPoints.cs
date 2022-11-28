using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P1584_Min_CostConnectAllPoints
    {
    }
    public class Solution
    {
        public int MinCostConnectPoints(int[][] points)
        {
            int res = 0;
            var n = points.Length;
            var ids = new int[n];
            var ranks = new int[n];
            for (int i = 0; i < n; i++)
            {
                ids[i] = i;
            }
            var q = new PriorityQueue<(int, int), int>();
            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = 1; j < points.Length; j++)
                {
                    q.Enqueue((i, j), Distance(i, j, points));
                }
            }
            while (q.Count > 0)
            {
                var edge = q.Dequeue();
                Union(edge.Item1, edge.Item2, ids, ref res, points, ranks);
            }
            return res;
        }
        public int Distance(int i, int j, int[][] points)
        {
            return Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
        }
        public void Union(int i, int j, int[] ids, ref int res, int[][] points, int[] ranks)
        {
            var id1 = Find(i, ids);
            var id2 = Find(j, ids);
            if (id1 != id2)
            {
                res += Distance(i, j, points);
                if (ranks[id1] > ranks[id2])
                {
                    ids[id2] = id1;
                }
                else if (ranks[id1] < ranks[id2])
                {
                    ids[id1] = id2;
                }
                else
                {
                    ids[id1] = id2;
                    ranks[id2]++;
                }
            }
        }
        public int Find(int p, int[] ids)
        {
            if (ids[p] != p)
            {
                ids[p] = Find(ids[p], ids);
            }
            return ids[p];
        }
    }
}
