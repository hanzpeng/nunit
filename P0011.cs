using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0011
    {
        public int MaxArea(int[] height) {
            var max = 0;
            var l = 0;
            var r = height.Length - 1;
            while (r > l) {
                max = Math.Max(max, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r]) l++;
                else if (height[l] > height[r]) r--;
                else {
                    l++;
                    r--;
                };
            }
            return max;
        }
    }
}
