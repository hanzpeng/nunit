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
            var id = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
            }
            union(edges, id);
            return find(source, id) == find(destination, id);
        }

        public void union(int[][] edges, int[] id)
        {
            foreach (var edge in edges)
            {
                var id0 = find(edge[0], id);
                var id1 = find(edge[1], id);
                if (id0 != id1)
                {
                    id[id0] = id1;
                }
            }
        }

        public int find(int p, int[] id)
        {
            if (id[p] == p) return p;
            id[p] = find(id[p], id);
            return id[p];
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

    public class Solution_DFS
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
            bool found = false;
            Dfs(children, source, destination, new bool[n], ref found);
            return found;
        }

        public void Dfs(List<int>[] children, int cur, int destination, bool[] visited, ref bool found)
        {
            foreach (var child in children[cur])
            {
                if (child == destination)
                {
                    found = true;
                    return;
                }
                if (!visited[child])
                {
                    visited[child] = true; ;
                    Dfs(children, child, destination, visited, ref found);
                    if (found) return;
                }
            }
        }
    }
}
