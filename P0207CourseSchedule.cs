using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0207CourseSchedule
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
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
            for (int i = 0; i < numCourses; i++)
            {
                if (!visited[i] && !Dfs(i, g, parent, visited)) return false;
            }
            return true;
        }

        bool Dfs(int i, List<int>[] g, HashSet<int> parent, bool[] visited)
        {
            if (parent.Contains(i)) return false;
            parent.Add(i);
            foreach (int j in g[i])
            {
                if (!visited[j] && !Dfs(j, g, parent, visited)) return false;
            }
            visited[i] = true;
            parent.Remove(i);
            return true;
        }
    }
}
