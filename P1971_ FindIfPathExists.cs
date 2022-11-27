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
    public class Solution_UnionFind
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

    public class Solution_BFS
    {
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            if (destination == source) return true;
            var children = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                children[i] = new List<int>();
            }
            foreach (int[] edge in edges)
            {
                children[edge[0]].Add(edge[1]);
                children[edge[1]].Add(edge[0]);
            }
            var q = new Queue<int>();
            var visited = new HashSet<int>();
            q.Enqueue(source);
            visited.Add(source);
            while (q.Count > 0)
            {
                var count = q.Count();
                for (int i = 0; i < count; i++)
                {
                    var cur = q.Dequeue();
                    foreach (var child in children[cur])
                    {
                        if (child == destination) return true;
                        if (!visited.Contains(child))
                        {
                            q.Enqueue(child);
                            visited.Add(child);
                        }
                    }
                }
            }
            return false;
        }
    }
}
