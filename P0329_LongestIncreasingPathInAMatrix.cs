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

        public class Solution2
        {
            public int LongestIncreasingPath(int[][] matrix)
            {
                var maxDepth = 0;
                int[][] depth = new int[matrix.Length][];
                for (int r = 0; r < matrix.Length; r++)
                {
                    depth[r] = new int[matrix[0].Length];
                }

                for (int r = 0; r < matrix.Length; r++)
                {
                    for (int c = 0; c < matrix[0].Length; c++)
                    {
                        maxDepth = Math.Max(Dfs(r, c, matrix, depth), maxDepth);
                    }
                }
                return maxDepth;
            }

            public int Dfs(int r, int c, int[][] matrix, int[][] depth)
            {
                if (depth[r][c] > 0) return depth[r][c];
                var dir = new int[4][] { new int[2] { -1, 0 }, new int[2] { 1, 0 }, new int[2] { 0, -1 }, new int[2] { 0, 1 } };
                var maxDepth = 1;
                foreach (var d in dir)
                {
                    var r1 = r + d[0];
                    var c1 = c + d[1];
                    if (r1 >= 0 && r1 < matrix.Length && c1 >= 0 && c1 < matrix[0].Length && matrix[r1][c1] > matrix[r][c])
                    {
                        maxDepth = Math.Max(Dfs(r1, c1, matrix, depth) + 1, maxDepth);
                    }
                }
                depth[r][c] = maxDepth;
                return maxDepth;
            }
        }
    }
}
