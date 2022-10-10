using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0149_MaxPointsOnALine_Sloap
    {
        public int MaxPoints(int[][] points)
        {
            if (points.Length < 3) return points.Length;
            int max = 2;
            for (int i = 2; i < points.Length; i++)
            {
                var slopeCount = new Dictionary<double, int>();
                for (int k = 0; k < i; k++)
                {
                    var slope = double.PositiveInfinity;
                    if (points[k][0] != points[i][0])
                    {
                        slope = (points[k][1] - points[i][1]) / (double)(points[k][0] - points[i][0]);
                    }
                    slopeCount[slope] = slopeCount.GetValueOrDefault(slope, 1) + 1;
                    max = Math.Max(max, slopeCount[slope]);
                }
            }
            return max;
        }
    }
    internal class P0149_MaxPointsOnALine_Gcd
    {
        public int MaxPoints(int[][] points)
        {
            if (points.Length < 3) return points.Length;
            int max = 2;
            for (int i = 2; i < points.Length; i++)
            {
                var slopeCount = new Dictionary<(int,int), int>();
                for (int k = 0; k < i; k++)
                {
                    (int, int) pair = (1,0);
                    var gcd = GetGcd(points[k][1] - points[i][1], points[k][0] - points[i][0]);
                    pair = ((points[k][1] - points[i][1]) / gcd, (points[k][0] - points[i][0]) / gcd);

                    slopeCount[pair] = slopeCount.GetValueOrDefault(pair, 1) + 1;
                    max = Math.Max(max, slopeCount[pair]);
                }
            }
            return max;
        }

        // Greatest Common Devisor
        int GetGcd(int a, int b)
        {
            if (b == 0) return a;
            return GetGcd(b, a % b);
        }
    }
}
