using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0684_UnionFind_M
    {
        public class Solution
        {
            public int[] FindRedundantConnection(int[][] edges)
            {
                var par = new int[edges.Length + 1];
                var rank = new int[edges.Length + 1];
                for (int i = 0; i < par.Length; i++)
                {
                    par[i] = i;
                }
                foreach (var edge in edges)
                {
                    if (Union(edge[0], edge[1], par, rank) == false)
                    {
                        return edge;
                    }
                }
                return null;
            }

            bool Union(int p1, int p2, int[] par, int[] rank)
            {
                p1 = Find(p1, par);
                p2 = Find(p2, par);
                if (p1 == p2) return false;

                if (rank[p1] > rank[p2])
                {
                    par[p2] = p1;
                    rank[p1] += rank[p2];
                }
                else
                {
                    par[p1] = p2;
                    rank[p2] += rank[p1];
                }
                return true;
            }

            int Find(int p, int[] par)
            {
                while (par[p] != p)
                {
                    par[p] = par[par[p]];
                    p = par[p];
                }
                return p;
            }
        }
    }
}
