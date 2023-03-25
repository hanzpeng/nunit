using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0047_Permutation2_A
    {
        public class Solution1
        {
            public IList<IList<int>> PermuteUnique(int[] nums)
            {
                Array.Sort(nums);
                IList<IList<int>> result = new List<IList<int>>();
                Dfs(nums, new Stack<int>(), new bool[nums.Length], result);
                return result;
            }
            void Dfs(int[] nums, Stack<int> cur, bool[] used, IList<IList<int>> result)
            {
                if (cur.Count == nums.Length)
                {
                    result.Add(new List<int>(cur));
                    return;
                }
                var valueUsedInCurrentPosition = new HashSet<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!used[i])
                    {
                        if (valueUsedInCurrentPosition.Contains(nums[i])) continue;
                        cur.Push(nums[i]);
                        used[i] = true;
                        Dfs(nums, cur, used, result);
                        used[i] = false;
                        cur.Pop();
                        valueUsedInCurrentPosition.Add(nums[i]);
                    }
                }
            }
        }

        public class Solution2
        {
            public IList<IList<int>> PermuteUnique(int[] nums)
            {
                Dictionary<int, int> numsMap = new Dictionary<int, int>();
                foreach (int num in nums)
                {
                    numsMap[num] = numsMap.GetValueOrDefault(num, 0) + 1;
                }

                IList<IList<int>> result = new List<IList<int>>();
                Dfs(numsMap, new Stack<int>(), result, nums.Length);
                return result;
            }
            void Dfs(Dictionary<int, int> numsMap, Stack<int> path, IList<IList<int>> result, int length)
            {
                if (path.Count == length)
                {
                    result.Add(new List<int>(path));
                    return;
                }

                foreach (var entry in numsMap)
                {
                    if (entry.Value > 0)
                    {
                        path.Push(entry.Key);
                        numsMap[entry.Key]--;
                        Dfs(numsMap, path, result, length);
                        numsMap[entry.Key]++;
                        path.Pop();
                    }
                }
            }
        }

        public class Solution3
        {
            public IList<IList<int>> PermuteUnique(int[] nums)
            {
                if (nums?.Length < 1) return null;
                Array.Sort(nums);
                var res = new List<IList<int>>();
                dfs(nums, res, new List<int>(), new bool[nums.Length]);
                return (IList<IList<int>>)res;
            }
            public void dfs(int[] nums, List<IList<int>> res, List<int> cur, bool[] visited)
            {
                if (cur.Count == nums.Length)
                {
                    res.Add(new List<int>(cur));
                    return;
                }
                for (var i = 0; i < nums.Length; i++)
                {
                    if (visited[i]) continue;
                    if (i > 0 && nums[i] == nums[i - 1] && !visited[i - 1]) continue;
                    cur.Add(nums[i]);
                    visited[i] = true;
                    dfs(nums, res, cur, visited);
                    visited[i] = false;
                    cur.RemoveAt(cur.Count - 1);
                }
            }
        }
    }
}
