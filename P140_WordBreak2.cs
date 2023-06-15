using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P140_WordBreak2
    {

        public class Solution
        {
            public IList<string> WordBreak(string s, IList<string> wordDict)
            {
                var res = new List<string>();
                if (s.Length == 0) return res;
                if (wordDict.Contains(s))
                {
                    res.Add(s);
                };

                for (int i = 1; i < s.Length; i++)
                {
                    if (wordDict.Contains(s.Substring(0, i)) )
                    {
                        var first = s.Substring(0, i);
                        var rest = WordBreak(s.Substring(i), wordDict);
                        if(remain.Count > 0)
                        {
                            res.Add(first + " " + rest)
                        }
                    }
                }
                return res;
            }

            public IList<string> WordBreak(string s, IList<string> wordDict)
        }
    }
}
