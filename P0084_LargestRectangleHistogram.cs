using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0084_LargestRectangleHistogram
    {
        public int LargestRectangleArea(int[] heights)
        {
            var valIndex = new Stack<(int, int)>();
            int max = 0;
            for (int i = 0; i <= heights.Length; i++)
            {
                int val = (i == heights.Length) ? 0 : heights[i];
                int topVal = (valIndex.Count == 0) ? 0 : valIndex.Peek().Item1;
                if (val > topVal)
                {
                    valIndex.Push((val, i));
                }
                else if (val < topVal)
                {
                    (int, int) valIndexTop = (0, 0);
                    while (valIndex.Count > 0 && val < valIndex.Peek().Item1)
                    {
                        valIndexTop = valIndex.Pop();
                        max = Math.Max(max, valIndexTop.Item1 * (i - valIndexTop.Item2));
                    }
                    valIndex.Push((val, valIndexTop.Item2));
                }
            }
            return max;
        }
    }
}
