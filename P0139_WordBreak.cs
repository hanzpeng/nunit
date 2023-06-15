using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0139_WordBreak
    {
        public class Solution
        {
            public bool WordBreak(string s, IList<string> wordDict)
            {
                if (s.Length == 0) return true;
                if (wordDict.Contains(s)) return true;
                for (int i = 1; i < s.Length; i++)
                {
                    if (wordDict.Contains(s.Substring(0, i)) && WordBreak(s.Substring(i), wordDict))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
