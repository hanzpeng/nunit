using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0139
    {
        public class Solution1
        {
            public string LongestCommonPrefix(string[] strs)
            {
                if (strs == null || strs.Length == 0) return "";
                int i = 0;
                var prefix = new StringBuilder();
                while (true)
                {
                    if (strs[0].Length <= i)
                        break;
                    char c = strs[0][i];
                    if (strs.Length > 1)
                    {
                        var stop = false;
                        for (int j = 1; j < strs.Length; j++)
                        {
                            if (strs[j].Length <= i || strs[j][i] != c)
                            {
                                stop = true;
                                break;
                            }
                        }
                        if (stop) break;
                    }
                    prefix.Append(c);
                    i++;
                }
                return prefix.ToString();
            }
        }
    }
}
