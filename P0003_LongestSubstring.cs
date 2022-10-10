using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0003_LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            List<char> list = new List<char>();
            var set = new HashSet<char>(list);
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
