using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0049_GroupAnagrams
    {
        public class Solution
        {
            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                var group = new Dictionary<string, IList<string>>();
                foreach (var str in strs)
                {
                    var chars = str.ToCharArray();
                    Array.Sort(chars);
                    var hash = new string(chars);
                    group[hash] = group.GetValueOrDefault(hash, new List<string>());
                    group[hash].Add(str);
                }
                return new List<IList<string>>(group.Values);
            }
        }

        public class Solution2
        {
            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                var group = new Dictionary<string, IList<string>>();
                foreach (var str in strs)
                {
                    var hash = GetHash(str);
                    group[hash] = group.GetValueOrDefault(hash, new List<string>());
                    group[hash].Add(str);
                }
                return new List<IList<string>>(group.Values);
            }

            public string GetHash(string s)
            {
                var counts = new int[26];
                foreach (char c in s.ToCharArray())
                {
                    ++counts[c - 'a'];
                }
                return string.Join(".", counts);
            }
        }
    }
}
