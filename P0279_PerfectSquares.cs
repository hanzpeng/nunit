using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0279_PerfectSquares
    {
        public class Solution
        {
            public static int NumSquares(int n)
            {
                int[] dp = new int[n + 1];
                dp[1] = 1;
                if (n > 1)
                {
                    for (int i = 2; i <= n; i++)
                    {
                        int r = (int)Math.Floor(Math.Sqrt(i));
                        if (r * r == i)
                        {
                            dp[i] = 1;
                        }
                        else
                        {
                            dp[i] = i;
                            for (int j = 1; j <= r; j++)
                            {
                                dp[i] = Math.Min(dp[i], 1 + dp[i - j * j]);
                            }
                        }
                    }
                }
                return dp[n];
            }
        }

    }
}
