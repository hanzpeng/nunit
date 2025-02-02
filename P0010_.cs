using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0010
    {
        public class Solution {
            public bool IsMatch(string s, string p) {
                if (s.Length == 0) {
                    if (p.Length == 0)
                        return true;
                    else {
                        if (MustMatch(p)) return false;
                        else return true;
                    }
                } else { // s.Length > 0
                    if (p.Length == 0) return false;

                    if (p.Length > 1 && p[1] == '*') {
                        // drop c*
                        if (IsMatch(s, p.Substring(2))) {
                            return true;
                        }

                        // skip s0
                        if ((s[0] == p[0] || p[0] == '.') && IsMatch(s.Substring(1), p)) {
                            return true;
                        }

                        return false;
                    } else {
                        // regular match for c or .
                        if (p[0] == '.' || s[0] == p[0]) return IsMatch(s.Substring(1), p.Substring(1));
                        else return false;
                    }
                }
            }

            bool MustMatch(string p) {
                int i = 0;
                while (i < p.Length) {
                    if (i + 1 < p.Length && p[i + 1] == '*') {
                        i++;
                        i++;
                        continue;
                    }
                    return true;
                }
                return false;
            }
        }
    }
}
