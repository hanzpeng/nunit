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
                bool[] taken = new bool[numCourses];
                HashSet<int> visiting = new();
                for (int i = 0; i < numCourses; i++)
                {
                    if (!taken[i] && !Dfs(i, prereq, visiting, taken)) return false;
                }
                return true;
            }

            bool Dfs(int i, List<int>[] prereq, HashSet<int> visiting, bool[] taken)
            {
                if (visiting.Contains(i)) return false;
                visiting.Add(i);
                foreach (int j in prereq[i])
                {
                    if (!taken[j] && !Dfs(j, prereq, visiting, taken)) return false;
                }
                taken[i] = true;
                visiting.Remove(i);
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
    }
}
