using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0174_DungeonGame
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            if (dungeon == null || dungeon.Length == 0 || dungeon[0].Length == 0) return 0;
            int m = dungeon.Length;
            int n = dungeon[0].Length;
            var dp = new int[m][];
            for (int i = 0; i < m; i++)
                dp[i] = new int[n];

            dp[m - 1][n - 1] = Math.Max(1, 1 - dungeon[m - 1][n - 1]);

            for (int r = m - 2; r >= 0; r--)
                dp[r][n - 1] = GetMin(dp[r + 1][n - 1], dungeon[r][n - 1]);

            for (int c = n - 2; c >= 0; c--)
                dp[m - 1][c] = GetMin(dp[m - 1][c + 1], dungeon[m - 1][c]);

            for (int r = m - 2; r >= 0; r--)
                for (int c = n - 2; c >= 0; c--)
                {
                    var dp1 = GetMin(dp[r][c + 1], dungeon[r][c]);
                    var dp2 = GetMin(dp[r + 1][c], dungeon[r][c]);
                    dp[r][c] = Math.Min(dp1, dp2);
                }

            return dp[0][0];
        }

        public int GetMin(int next, int current)
        {
            return Math.Max(1, next - current);
        }
    }

    internal class P0174_DungeonGame_1D
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            if (dungeon == null || dungeon.Length == 0 || dungeon[0].Length == 0) return 0;
            int m = dungeon.Length;
            int n = dungeon[0].Length;
            var dp = new int[n];

            dp[n - 1] = Math.Max(1, 1 - dungeon[m - 1][n - 1]);
            for (int c = n - 2; c >= 0; c--)
                dp[c] = GetMin(dp[c + 1], dungeon[m - 1][c]);

            for(int r = m-2; r >= 0; r--)
            {
                var dp1 = new int[n];
                dp1[n - 1] = GetMin(dp[n - 1], dungeon[r][n - 1]);
                for (int c = n - 2; c >= 0; c--)
                {
                    var dpRight = GetMin(dp1[c + 1], dungeon[r][c]);
                    var dpDown = GetMin(dp[c], dungeon[r][c]);
                    dp1[c] = Math.Min(dpRight, dpDown);
                }
                dp = dp1;
            }
            return dp[0];
        }

        public int GetMin(int next, int current)
        {
            return Math.Max(1, next - current);
        }
    }
}
