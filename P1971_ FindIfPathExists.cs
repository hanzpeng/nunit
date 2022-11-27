using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P1971__FindIfPathExists
    {
    }
    public class Solution1
    {
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            var pr = new int[n];
            for (int i = 0; i < n; i++)
            {
                pr[i] = i;
            }
            union(n, edges, pr);
            return find(source, pr) == find(destination, pr);
        }

        public void union(int n, int[][] edges, int[] pr)
        {
            foreach (var edge in edges)
            {
                var pr0 = find(edge[0], pr);
                var pr1 = find(edge[1], pr);
                if (pr0 != pr1)
                {
                    pr[pr0] = pr1;
                }
            }
        }

        public int find(int point, int[] pr)
        {
            if (pr[point] == point) return point;
            pr[point] = find(pr[point], pr);
            return pr[point];
        }
    }


}
