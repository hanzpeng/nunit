using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0014_commonprefix
    {
        public class Solution
        {
            public string LongestCommonPrefix(string[] strs)
            {
                if (strs == null || strs.Length == 0) return "";
                for (int i = 0; i < strs[0].Length; i++)
                {
                    char c = strs[0][i];
                    for (int j = 1; j < strs.Length; j++)
                    {
                        if (strs[j].Length == i || strs[j][i] != c)
                        {
                            return strs[0].Substring(0, i);
                        }
                    }
                }
                return strs[0];
            }
        }
    }
}
