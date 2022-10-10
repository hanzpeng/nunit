using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0132_PalindromePartitioning2
    {
        Dictionary<string, int> minCutMap = new();
        Dictionary<string, bool> isPalinMap = new();
        public int MinCut(string s)
        {
            if (s == null | s.Length <= 1) return 0;
            return Mincut(s, 0, s.Length - 1);
        }

        public int Mincut(string s, int l, int r)
        {
            if (l >= r) return 0;
            int minCut = int.MaxValue;
            string key = l + "," + r;

            if (minCutMap.ContainsKey(key))
            {
                return minCutMap[key];
            }

            if (IsPal(s, l, r))
            {
                minCut = 0;
                minCutMap[key] = minCut;
                return minCutMap[key];
            }

            for (int i = l; i < r; i++)
            {
                if (IsPal(s, l, i))
                {
                    minCut = Math.Min(minCut, Mincut(s, i + 1, r) + 1);
                }
            }
            minCutMap[key] = minCut;
            return minCutMap[key];
        }

        public bool IsPal(string s, int l, int r)
        {
            if (l >= r) return true;
            string key = l + "," + r;
            if (isPalinMap.ContainsKey(key))
            {
                return isPalinMap[key];
            }
            isPalinMap[key] = false;
            if (s[l] == s[r])
            {
                isPalinMap[key] = IsPal(s, l + 1, r - 1);

            }
            return isPalinMap[key];
        }
    }

    internal class P0132_PalindromePartitioning2_b
    {
        int[][] minCutMap;
        bool[][] isPalinMap;
        public int MinCut(string s)
        {
            if (s == null || s.Length <= 1) return 0;
            minCutMap = new int[s.Length][];
            isPalinMap = new bool[s.Length][];
            for (int i = 0; i < s.Length; i++)
            {
                minCutMap[i] = new int[s.Length];
                isPalinMap[i] = new bool[s.Length];
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    minCutMap[i][j] = -1;
                }
            }
            return Mincut(s, 0, s.Length - 1);
        }

        public int Mincut(string s, int l, int r)
        {
            if (l >= r) return 0;
            int minCut = int.MaxValue;

            if (minCutMap[l][r] >= 0)
            {
                return minCutMap[l][r];
            }

            if (IsPal(s, l, r))
            {
                minCut = 0;
                minCutMap[l][r] = minCut;
                return minCutMap[l][r];
            }

            for (int i = l; i < r; i++)
            {
                if (IsPal(s, l, i))
                {
                    minCut = Math.Min(minCut, Mincut(s, i + 1, r) + 1);
                }
            }
            minCutMap[l][r] = minCut;
            return minCutMap[l][r];
        }

        public bool IsPal(string s, int l, int r)
        {
            if (l >= r) return true;
            string key = l + "," + r;
            if (isPalinMap[l][r])
            {
                return isPalinMap[l][r];
            }
            if (s[l] == s[r])
            {
                isPalinMap[l][r] = IsPal(s, l + 1, r - 1);

            }
            return isPalinMap[l][r];
        }
    }

    internal class P0132_PalindromePartitioning2_Bottomup
    {
        public int MinCut(string s)
        {
            if (s == null || s.Length <= 1) return 0;
            var mincut = new int[s.Length];
            var isPal = new bool[s.Length, s.Length];
            BuildPal(s, isPal);
            for (int r = 0; r < s.Length; r++)
            {
                if (isPal[0, r])
                {
                    mincut[r] = 0;
                }
                else
                {
                    int min = r;
                    for (int l = 1; l <= r; l++)
                    {
                        if (isPal[l, r])
                        {
                            min = Math.Min(min, mincut[l - 1] + 1);
                        }
                    }
                    mincut[r] = min;
                }
            }
            return mincut[s.Length - 1];
        }
        public void BuildPal(string s, bool[,] isPal)
        {
            for (int i = 0; i <= s.Length - 1; i++)
            {
                isPal[i, i] = true;
            }
            for (int i = 0; i <= s.Length - 2; i++)
            {
                isPal[i, i + 1] = s[i] == s[i + 1];
            }
            for (int len = 3; len <= s.Length; len++)
            {
                for (int i = 0; i <= s.Length - len; i++)
                {
                    isPal[i, i + len - 1] = s[i] == s[i + len - 1] && isPal[i + 1, i + len - 2];
                }
            }
        }
    }
}
