using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0200_NumberOfIslands  {
        public int NumIslands(char[][] grid)
        {
            int R = grid.Length;
            int C = grid[0].Length;
            var visited = new bool[R][];
            for (int i = 0; i < R; i++)
            {
                visited[i] = new bool[C];
            }
            int count = 0;
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (!visited[r][c] && grid[r][c] != '0')
                    {
                        Dfs(r, c, grid, visited);
                        count++;
                    }
                }
            }
            return count;
        }
        void Dfs(int r, int c, char[][] grid, bool[][] visited)
        {
            int R = grid.Length;
            int C = grid[0].Length;
            visited[r][c] = true;
            var Dir = new (int dr, int dc)[] { (0, -1), (0, 1), (-1, 0), (1, 0) };
            foreach (var d in Dir)
            {
                var r1 = r + d.dr;
                var c1 = c + d.dc;
                if (r1 >= 0 && r1 < R && c1 >= 0 && c1 < C && grid[r1][c1] != '0' && !visited[r1][c1])
                {
                    Dfs(r1, c1, grid, visited);
                }
            }
        }
    }
}
