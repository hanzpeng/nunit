using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0044_WildcardMatching
    {
        public bool IsMatch(string s, string p)
        {
            return IsMatch(s, p, 0, 0, new bool?[s.Length + 1, p.Length + 1]).Value;
        }

        public bool? IsMatch(string s, string p, int i, int j, bool?[,] memo)
        {
            if (!memo[i, j].HasValue)
            {
                if (i == s.Length)
                {
                    memo[i, j] = j == p.Length || !p.Substring(j).ToCharArray().ToList<char>().Exists(c => c != '*');
                }
                else if (j == p.Length)
                {
                    memo[i, j] = i == s.Length;
                }
                else if (p[j] == '*')
                {
                    memo[i, j] =
                        IsMatch(s, p, i, j + 1, memo).Value ||
                        IsMatch(s, p, i + 1, j, memo).Value ||
                        IsMatch(s, p, i + 1, j + 1, memo).Value;

                }
                else if (p[j] == '?')
                {
                    memo[i, j] = IsMatch(s, p, i + 1, j + 1, memo);
                }
                else //p[j] is a letter
                {
                    memo[i, j] = s[i] == p[j] && IsMatch(s, p, i + 1, j + 1, memo).Value;
                }
            }
            return memo[i, j];
        }

        public bool IsMatchByDP(string s, string p)
        {
            bool[,] dp = new bool[s.Length + 1, p.Length + 1];

            dp[s.Length, p.Length] = true;

            for (int i = 0; i < s.Length; i++)
            {
                dp[i, p.Length] = false;
            }

            for (int j = p.Length - 1; j >= 0; j--)
            {
                dp[s.Length, j] = dp[s.Length, j + 1] && p[j] == '*';
            }

            for (int i = s.Length - 1; i >= 0; i--)
            {
                for (int j = p.Length - 1; j >= 0; j--)
                {
                    if (p[j] == '*')
                    {
                        dp[i, j] = dp[i, j + 1] || dp[i + 1, j] || dp[i + 1, j + 1];

                    }
                    else if (p[j] == '?')
                    {
                        dp[i, j] = dp[i + 1, j + 1];
                    }
                    else
                    {
                        dp[i, j] = s[i] == p[j] && dp[i + 1, j + 1];
                    }
                }
            }

            return dp[0, 0];
        }
    }
}