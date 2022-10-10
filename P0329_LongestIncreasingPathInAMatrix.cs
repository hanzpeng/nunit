using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0329_LongestIncreasingPathInAMatrix
    {
        int R, C;
        (int, int)[] Dirs = { (1, 0), (-1, 0), (0, -1), (0, 1) };
        bool OutOfBound(int r, int c) => (r < 0 || r > R - 1 || c < 0 || c > C - 1);
        int[][] Depth;
        public int LongestIncreasingPath(int[][] matrix)
        {
            var m = matrix;
            R = m.Length; C = m[0].Length;
            Depth = new int[R][];
            for (int r = 0; r < R; r++) Depth[r] = new int[C];
            int maxDepth = 0;
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    maxDepth = Math.Max(maxDepth, Dfs(r, c, m));
                }
            }
            return maxDepth;
        }
        public int Dfs(int r, int c, int[][] m)
        {
            if (Depth[r][c] > 0) return Depth[r][c];
            int maxChildDepth = 0;
            foreach (var dir in Dirs)
            {
                var r1 = r + dir.Item1;
                var c1 = c + dir.Item2;
                if (!OutOfBound(r1, c1) && m[r1][c1] < m[r][c])
                {
                    maxChildDepth = Math.Max(Dfs(r1, c1, m), maxChildDepth);
                }
            }
            Depth[r][c] = maxChildDepth + 1;
            return Depth[r][c];
        }
    }
}
