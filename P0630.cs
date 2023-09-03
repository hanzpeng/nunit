using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0630
    {
        public class Solution
        {
            public int ScheduleCourse(int[][] courses)
            {
                List<int[]> courseList = courses.ToList().Where(x => x[1] >= x[0]).OrderBy(x => x[1]).ToList();
                Stack<int[]> selected = new Stack<int[]>();
                int maxCt = 0;
                Bt(0, courseList, ref maxCt, selected);
                return maxCt;
            }
            public void Bt(int i, List<int[]> courseList, ref int maxCt, Stack<int[]> selected)
            {
                if (i == courseList.Count)
                {
                    maxCt = Math.Max(maxCt, selected.Count);
                    return;
                }
                //  selecte courseList[index]
                if (selected.Count == 0 || CanAddClass(selected, courseList[i]))
                {
                    selected.Push(courseList[i]);
                    Bt(i + 1, courseList, ref maxCt, selected);
                    selected.Pop();
                }
                // not select courseList[index]
                Bt(i + 1, courseList, ref maxCt, selected);
            }
            public bool CanAddClass(Stack<int[]> selected, int[] course)
            {
                var end = selected.Select(x => x[0]).Sum() + course[0];
                return end <= course[1];
            }
        }
    }
}
