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

    public class Solution2
    {
        public int NumIslands(char[][] grid)
        {
            var result = 0;
            int R = grid.Length;
            int C = grid[0].Length;
            var visited = new bool[R][];
            for (int r = 0; r < R; r++)
            {
                visited[r] = new bool[C];
            }
            for (var r = 0; r < R; r++)
            {
                for (var c = 0; c < C; c++)
                {
                    if (grid[r][c] == '1' &&
                        visited[r][c] == false)
                    {
                        result++;
                        Dfs(r, c, grid, visited, R, C);
                    }
                }
            }
            return result;
        }
        private void Dfs(
                        int r,
                        int c,
                        char[][] grid,
                        bool[][] visited,
                        int R,
                        int C)
        {
            visited[r][c] = true;
            var drdc = new int[][] {
            new int[] { -1,  0 },
            new int[] {  1,  0 },
            new int[] {  0, -1 },
            new int[] {  0,  1 } };
            for (int i = 0; i < 4; i++)
            {
                var r1 = r + drdc[i][0];
                var c1 = c + drdc[i][1];
                if (r1 >= 0 &&
                    r1 < R &&
                    c1 >= 0 &&
                    c1 < C &&
                    visited[r1][c1] == false &&
                    grid[r1][c1] == '1')
                {
                    Dfs(r1, c1, grid, visited, R, C);
                }
            }
        }
    }
}
