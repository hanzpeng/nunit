using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0003_LongestSubstring
    {
        public class Solution {
            public int LengthOfLongestSubstring(string s) {
                Dictionary<char, int> charIndex = new();
                int i = 0;
                int res = 0;
                int le = 0;
                while (i < s.Length) {
                    if (charIndex.ContainsKey(s[i])) {
                        if (i - charIndex[s[i]] > res) {
                            res = i - le;
                        }
                        for (int j = le; j < charIndex[s[i]]; j++) {
                            charIndex.Remove(s[j]);
                        }
                        le = charIndex[s[i]] + 1;
                    } else {
                        if (i - le + 1 > res) res = i - le + 1;
                    }
                    charIndex[s[i]] = i;
                    i++;
                }
                return res;
            }
        }
        public class Solution3 {
            public int LengthOfLongestSubstring(string s) {
                var map = new Dictionary<char, int>();
                int l = 0;
                int r = 0;
                int maxLen = 0;
                while (r < s.Length) {
                    if (map.ContainsKey(s[r])) {
                        l = Math.Max(l, map[s[r]] + 1);
                    }
                    map[s[r]] = r;
                    maxLen = Math.Max(r - l + 1, maxLen);
                    r++;
                }
                return maxLen;
            }
        }
        public class Solution2 {
            public int LengthOfLongestSubstring(string s) {
                var set = new HashSet<char>();
                int l = 0;
                int r = 0;
                int maxLen = 0;
                while (r < s.Length) {
                    while (set.Contains(s[r])) {
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
}
