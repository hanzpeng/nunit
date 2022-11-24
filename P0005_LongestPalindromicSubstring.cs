using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0005_LongestPalindromicSubstring
    {
        public class Solution
        {
            public string LongestPalindrome(string s)
            {
                if (String.IsNullOrEmpty(s)) return s;
                string dp = s.Substring(0, 1);
                for (int i = 1; i < s.Length; i++)
                {
                    var cur = LongestPalindromEndedAt(i, s);
                    dp = cur.Length >= dp.Length ? cur : dp;
                }
                return dp;
            }

            public string LongestPalindromEndedAt(int index, string s)
            {
                for (int i = 0; i <= index; i++)
                {
                    var cur = s.Substring(i, index + 1 - i);
                    if (IsPalindrom(cur)) return cur;
                }
                return "";
            }

            public bool IsPalindrom(string s)
            {
                for (int i = 0; i <= s.Length / 2; i++)
                {
                    if (s[i] != s[s.Length - 1 - i]) return false;
                }
                return true;
            }
        }
    }
}
