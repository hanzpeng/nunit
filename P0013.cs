using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0013
    {
        public int RomanToInt(string s) {
            var SymVal1 = new Dictionary<string, int> { { "M", 1000 }, { "D", 500 }, { "C", 100 }, { "L", 50 }, { "X", 10 }, { "V", 5 }, { "I", 1 } };
            var SymVal2 = new Dictionary<string, int> { { "CM", 900 }, { "CD", 400 }, { "XC", 90 }, { "XL", 40 }, { "IX", 9 }, { "IV", 4 } };
            var res = 0;
            int i = 0;
            while (i < s.Length) {
                if (i + 1 < s.Length && SymVal2.ContainsKey(s.Substring(i, 2))) {
                    res += SymVal2[s.Substring(i, 2)];
                    i += 2;
                    continue;
                }
                if (SymVal1.ContainsKey(s[i].ToString())) {
                    res += SymVal1[s[i].ToString()];
                    i++;
                }
            }
            return res;
        }
    }
}
