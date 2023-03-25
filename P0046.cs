using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0046
    {
        public class Solution
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                IList<IList<int>> result = new List<IList<int>>();
                Dfs(nums, new Stack<int>(), new bool[nums.Length], result);
                return result;
            }
            void Dfs(int[] nums, Stack<int> path, bool[] used, IList<IList<int>> result)
            {
                if (path.Count == nums.Length)
                {
                    result.Add(new List<int>(path));
                    return;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if (!used[i])
                    {
                        path.Push(nums[i]);
                        used[i] = true;
                        Dfs(nums, path, used, result);
                        used[i] = false;
                        path.Pop();
                    }
                }
            }

        }

        public class Solution2
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                var res = new List<IList<int>>();
                var set = new HashSet<int>(nums);
                dfs(set, res, new Stack<int>());
                return res;
            }

            public void dfs(HashSet<int> set, List<IList<int>> res, Stack<int> cur)
            {
                if (set.Count == 0)
                {
                    res.Add(cur.ToList());
                    return;
                }
                foreach (var v in set)
                {
                    cur.Push(v);
                    var nextSet = new HashSet<int>(set);
                    nextSet.Remove(v);
                    dfs(nextSet, res, cur);
                    cur.Pop();
                }
            }
        }
    }


}
