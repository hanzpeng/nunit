using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    class P0210_CourseSchedule2
    {
        // Use InDegree
        public int[] FindOrderInDegree_WithDependencyGraph(int numCourses, int[][] prerequisites)
        {
            int[] res = new int[numCourses];
            var g = new List<int>[numCourses];
            int[] inDegree = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                g[i] = new List<int>();
            }
            foreach (var pr in prerequisites)
            {
                g[pr[0]].Add(pr[1]);
                inDegree[pr[1]]++;
            }
            Queue<int> q = new();
            int index = numCourses - 1;
            for (int k = 0; k < numCourses; k++)
            {
                if (inDegree[k] == 0)
                {
                    q.Enqueue(k);
                    res[index--] = k;
                }
            }
            while (q.Count > 0)
            {
                foreach (int k in g[q.Dequeue()])
                {
                    if (--inDegree[k] == 0)
                    {
                        q.Enqueue(k);
                        res[index--] = k;
                    }
                }
            }
            if (index != -1) return Array.Empty<int>();
            return res;
        }

        // Use Reverse InDegree
        public int[] FindOrderInDegree_WithOrderGraph(int numCourses, int[][] prerequisites)
        {
            int[] res = new int[numCourses];
            var g = new List<int>[numCourses];
            int[] inDegree = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                g[i] = new List<int>();
            }
            foreach (var pr in prerequisites)
            {
                g[pr[1]].Add(pr[0]);
                inDegree[pr[0]]++;
            }
            Queue<int> q = new();
            int index = 0;
            for (int k = 0; k < numCourses; k++)
            {
                if (inDegree[k] == 0)
                {
                    q.Enqueue(k);
                    res[index++] = k;
                }
            }
            while (q.Count > 0)
            {
                foreach (int k in g[q.Dequeue()])
                {
                    if (--inDegree[k] == 0)
                    {
                        q.Enqueue(k);
                        res[index++] = k;
                    }
                }
            }
            if (index != numCourses) return Array.Empty<int>();
            return res;
        }


        // Topological Sort using stack
        public int[] FindOrderDfs_WithDependencyGraph(int numCourses, int[][] prerequisites)
        {
            {
                var g = new List<int>[numCourses];
                for (int i = 0; i < numCourses; i++)
                {
                    g[i] = new List<int>();
                }
                foreach (var pr in prerequisites)
                {
                    g[pr[0]].Add(pr[1]);
                }
                bool[] visited = new bool[numCourses];
                HashSet<int> parents = new();
                List<int> res = new();
                for (int i = 0; i < numCourses; i++)
                {
                    if (!visited[i] && !Dfs(i, g, parents, visited, res)) return Array.Empty<int>();
                }
                return res.ToArray();
            }

            bool Dfs(int i, List<int>[] g, HashSet<int> parents, bool[] visited, List<int> res)
            {
                if (parents.Contains(i)) return false;
                parents.Add(i);
                foreach (int j in g[i])
                {
                    if (!visited[j] && !Dfs(j, g, parents, visited, res)) return false;
                }
                visited[i] = true;
                parents.Remove(i);
                res.Add(i);
                return true;
            }
        }

        // Topological Sort using array
        public int[] FindOrderDfs_NoStack(int numCourses, int[][] prerequisites)
        {
            {
                var g = new List<int>[numCourses];
                for (int i = 0; i < numCourses; i++)
                {
                    g[i] = new List<int>();
                }
                foreach (var pr in prerequisites)
                {
                    g[pr[0]].Add(pr[1]);
                }
                bool[] visited = new bool[numCourses];
                HashSet<int> parent = new();
                int[] res = new int[numCourses];
                int index = 0;
                for (int i = 0; i < numCourses; i++)
                {
                    if (!visited[i] && !Dfs(i, g, parent, visited, res, ref index)) return Array.Empty<int>();
                }
                return res;
            }

            bool Dfs(int i, List<int>[] g, HashSet<int> parent, bool[] visited, int[] res, ref int index)
            {
                if (parent.Contains(i)) return false;
                parent.Add(i);
                foreach (int j in g[i])
                {
                    if (!visited[j] && !Dfs(j, g, parent, visited, res, ref index)) return false;
                }
                visited[i] = true;
                parent.Remove(i);
                res[index++] = i;
                return true;
            }
        }
    }
}
