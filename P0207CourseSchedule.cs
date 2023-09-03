using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0207CourseSchedule
    {
        public class Solution1
        {
            public bool CanFinish(int numCourses, int[][] prerequisites)
            {
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
                        if (!Dfs(i, prereq, visited, par)) return false;
                    }
                }
                return true;
            }
            bool Dfs(int i, List<int>[] prereq, bool[] visited, HashSet<int> par)
            {
                if (par.Contains(i)) return false;
                par.Add(i);
                foreach (int j in prereq[i])
                {
                    if (!visited[j])
                    {
                        if (!Dfs(j, prereq, visited, par)) return false;
                    }
                }
                // make sure set visited after done with DFS
                visited[i] = true;
                return true;
            }
        }

        public class Solution2
        {
            public bool CanFinish(int numCourses, int[][] prerequisites)
            {
                var prereq = new List<int>[numCourses];
                for (int i = 0; i < numCourses; i++)
                {
                    prereq[i] = new List<int>();
                }
                foreach (var pr in prerequisites)
                {
                    prereq[pr[0]].Add(pr[1]);
                }
                HashSet<int> visiting = new();
                for (int i = 0; i < numCourses; i++)
                {
                    if (!Dfs(i, prereq, visiting)) return false;
                }
                return true;
            }

            bool Dfs(int i, List<int>[] prereq, HashSet<int> visiting)
            {
                if (visiting.Contains(i)) return false;
                if (prereq[i].Count == 0) return true;
                visiting.Add(i);
                foreach (int j in prereq[i])
                {
                    if (!Dfs(j, prereq, visiting)) return false;
                }
                prereq[i] = new List<int>();
                visiting.Remove(i);
                return true;
            }
        }

        public class Solution3
        {
            public bool CanFinish(int numCourses, int[][] prerequisites)
            {
                var prereq = new List<int>[numCourses];
                for (int i = 0; i < numCourses; i++)
                {
                    prereq[i] = new List<int>();
                }
                foreach (var pr in prerequisites)
                {
                    prereq[pr[0]].Add(pr[1]);
                }
                var visiting = new bool[numCourses];
                for (int i = 0; i < numCourses; i++)
                {
                    if (!Dfs(i, prereq, visiting)) return false;
                }
                return true;
            }

            bool Dfs(int i, List<int>[] prereq, bool[] visiting)
            {
                if (visiting[i]) return false;
                if (prereq[i].Count == 0) return true;
                visiting[i] = true;
                foreach (int j in prereq[i])
                {
                    if (!Dfs(j, prereq, visiting)) return false;
                }
                prereq[i] = new List<int>();
                visiting[i] = false;
                return true;
            }
        }
    }
}
