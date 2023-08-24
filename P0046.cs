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
        public class Solution0
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                var res = new List<IList<int>>();
                PutEveryRemainingNumberInCurIndex(nums, 0, res);
                return res;
            }
            public void PutEveryRemainingNumberInCurIndex(int[] nums, int curIndex, List<IList<int>> res)
            {
                if (curIndex == nums.Length)
                {
                    res.Add(new List<int>(nums));
                    return;
                }
                for (int j = curIndex; j < nums.Length; j++)
                {
                    // put every remaining number in current index, including the current index it self
                    (nums[curIndex], nums[j]) = (nums[j], nums[curIndex]);
                    // for each current index, proceed to next the index 
                    var nextIndex = curIndex + 1;
                    PutEveryRemainingNumberInCurIndex(nums, nextIndex, res);
                    //back track so we can try next one
                    (nums[curIndex], nums[j]) = (nums[j], nums[curIndex]);
                }
            }
        }
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
                var remain = new HashSet<int>(nums);
                dfs(remain, res, new Stack<int>());
                return res;
            }

            public void dfs(HashSet<int> remain, List<IList<int>> res, Stack<int> pre)
            {
                if (remain.Count == 0)
                {
                    res.Add(pre.ToList());
                    return;
                }
                foreach (var v in remain)
                {
                    pre.Push(v);
                    var nextRemain = new HashSet<int>(remain);
                    nextRemain.Remove(v);
                    dfs(nextRemain, res, pre);
                    pre.Pop();
                }
            }
        }

        public class Solution3
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                var res = new List<IList<int>>();
                backtrack(nums, res, new List<int>());
                return res;
            }
            public void backtrack(int[] nums, List<IList<int>> res, List<int> cur)
            {
                if (cur.Count == nums.Length)
                {
                    res.Add(new List<int>(cur));
                    return;
                }

                foreach (var num in nums)
                {
                    if (cur.Contains(num)) continue;
                    cur.Add(num);
                    backtrack(nums, res, cur);
                    cur.RemoveAt(cur.Count - 1);
                }
            }
        }
    }


}
