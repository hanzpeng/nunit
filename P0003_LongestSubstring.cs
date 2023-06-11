using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0003_LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            var map = new HashSet<char>();
            int l = 0;
            int r = 0;
            int maxLen = 0;
            while (r < s.Length)
            {
                while (map.Contains(s[r]))
                {
                    map.Remove(s[l]);
                    l++;
                }
                map.Add(s[r]);
                maxLen = Math.Max(r - l + 1, maxLen);
                r++;
            }
            return maxLen;
        }

        public int LengthOfLongestSubstring_hashset(string s)
        {
            var set = new HashSet<char>();
            int l = 0;
            int r = 0;
            int maxLen = 0;
            while (r < s.Length)
            {
                while (set.Contains(s[r]))
                {
                    set.Remove(s[l]);
                    l++;
                }
                set.Add(s[r]);
                maxLen = Math.Max(r - l + 1, maxLen);
                r++;
            }
            return maxLen;
        }
    }
}
