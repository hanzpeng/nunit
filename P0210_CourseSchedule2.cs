using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    class P0210_CourseSchedule2
    {
        public class Solution
        {
            public int[] FindOrder(int numCourses, int[][] prerequisites)
            {
                var prereqDict = new Dictionary<int, HashSet<int>>();
                for (int course = 0; course < numCourses; course++)
                {
                    prereqDict[course] = new HashSet<int>();
                }
                foreach (var prereq in prerequisites)
                {
                    prereqDict[prereq[0]].Add(prereq[1]);
                }
                var visited = new bool[numCourses];
                var callStack = new HashSet<int>();
                var result = new List<int>();
                for (int course = 0; course < numCourses; course++)
                {
                    if (!visited[course])
                    {
                        bool ret = Dfs(course, prereqDict, visited, callStack, result);
                        if (ret == false) return new int[] { };
                    }
                }
                return result.ToArray();
            }

            public bool Dfs(int course, Dictionary<int, HashSet<int>> prereqDict, bool[] visited, HashSet<int> callStack, List<int> result)
            {
                if (callStack.Contains(course))
                {
                    return false;
                }
                callStack.Add(course);
                foreach (var requiredCourse in prereqDict[course])
                {
                    if (!visited[requiredCourse])
                    {
                        var ret = Dfs(requiredCourse, prereqDict, visited, callStack, result);
                        if (ret == false) return false;
                    }
                }
                result.Add(course);
                visited[course] = true;
                callStack.Remove(course);
                return true;
            }
        }

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
            var res = new List<int>();
            var prereq = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                prereq[i] = new List<int>();
            }
            foreach (var pr in prerequisites)
            {
                prereq[pr[0]].Add(pr[1]);
            }
            var visited = new bool[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                if (!visited[i])
                {
                    var par = new HashSet<int>();
                    if (!Dfs(i, prereq, visited, par, res))
                    {
                        return new int[0];
                    }
                }
            }
            return res.ToArray();


            bool Dfs(int i, List<int>[] prereq, bool[] visited, HashSet<int> par, List<int> res)
            {
                if (par.Contains(i)) return false;
                par.Add(i);
                foreach (int j in prereq[i])
                {
                    if (!visited[j])
                    {
                        if (!Dfs(j, prereq, visited, par, res)) return false;
                    }
                }
                // make sure set visited after done with DFS
                visited[i] = true;
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
