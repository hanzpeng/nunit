using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0028
    {
        public class Solution
        {
            public int StrStr(string haystack, string needle)
            {
                if (string.IsNullOrEmpty(haystack) || string.IsNullOrEmpty(needle) || needle.Length > haystack.Length) return -1;
                for (int i = 0; i <= haystack.Length - needle.Length; i++)
                {
                    if (haystack[i] == needle[0])
                    {
                        bool isMatch = true;
                        for (int j = 1; j < needle.Length; j++)
                        {
                            if (haystack[i + j] != needle[j])
                            {
                                isMatch = false;
                            }
                        }
                        if (isMatch) return i;
                    }
                }
                return -1;
            }
        }
    }
}
