using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0060_PermutationSequence
    {
        string result = "";
        public string GetPermutation(int n, int k)
        {
            int count = 0;
            bool[] used = new bool[n + 1];
            Backtrack(0, k, n, "", ref count, used);
            return result;
        }
        public bool Backtrack(int i, int k, int n, string str, ref int count, bool[] used)
        {
            if (i == n)
            {
                count++;
                if (count == k)
                {
                    result = str;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for (int j = 1; j <= n; j++)
            {
                if (!used[j])
                {
                    used[j] = true;
                    var res = Backtrack(i + 1, k, n, str + j, ref count, used);
                    if (res == true)
                    {
                        return true;
                    }
                    used[j] = false;
                }
            }
            return false;
        }
    }
}
