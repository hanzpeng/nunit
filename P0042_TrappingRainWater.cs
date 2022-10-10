using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0042_TrappingRainWater
    {
        public int Trap(int[] height)
        {
            if (height == null || height.Length <= 2)
            {
                return 0;
            }
            int[] lTop = new int[height.Length];
            int[] rTop = new int[height.Length];
            int lMax = 0;
            int rMax = 0;
            for (int i = 0; i < height.Length; i++)
            {
                lMax = Math.Max(height[i], lMax);
                lTop[i] = lMax;
            }
            for (int j = height.Length - 1; j >= 0; j--)
            {
                rMax = Math.Max(height[j], rMax);
                rTop[j] = rMax;
            }
            int sum = 0;
            for (int i = 1; i <= height.Length - 2; i++)
            {
                int cap = Math.Min(lTop[i - 1], rTop[i + 1]) - height[i];
                if (cap > 0)
                {
                    sum += cap;
                }
            }
            return sum;
        }
    }
}
