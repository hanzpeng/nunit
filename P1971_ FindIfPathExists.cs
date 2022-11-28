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
            var ids = new int[n];
            for (int i = 0; i < n; i++) ids[i] = i;           
            foreach (var edge in edges) Union(edge[0],edge[1], ids);
            return Find(source, ids) == Find(destination, ids);
        }

        public void Union(int p0, int p1, int[] ids)
        {
            var id0 = Find(p0, ids);
            var id1 = Find(p1, ids);
            ids[id0] = id1;
        }

        public int Find(int p, int[] ids)
        {
            if (ids[p] != p) ids[p] = Find(ids[p], ids);
            return ids[p];
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
