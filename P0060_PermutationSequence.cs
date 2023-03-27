using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0060_PermutationSequence
    {
        public string GetPermutation(int n, int k)
        {
            int count = 0;
            bool[] used = new bool[n + 1];
            string result = "";
            Backtrack(0, k, n, "", ref count, used, ref result);
            return result;
        }
        public bool Backtrack(int i, int k, int n, string str, ref int count, bool[] used, ref string result)
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
                    if (Backtrack(i + 1, k, n, str + j, ref count, used, ref result) == true)
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
