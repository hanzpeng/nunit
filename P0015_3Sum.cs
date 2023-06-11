using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0015_3Sum
    {
        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                Array.Sort(nums);
                var res = new HashSet<(int, int, int)>();
                for (int i = 0; i < nums.Length; i++)
                {
                    var twoRes = TwoSum(nums, -nums[i], i + 1);
                    if (twoRes?.Count > 0)
                    {
                        foreach (var item in twoRes)
                        {
                            res.Add(item);
                        }
                    }
                }
                return res.Select(x => (IList<int>)(new List<int>(new int[] { x.Item1, x.Item2, x.Item3 }))).ToList();
            }

            public HashSet<(int, int, int)> TwoSum(int[] nums, int target, int iNext)
            {
                var res = new HashSet<(int, int, int)>();
                var set = new HashSet<int>();
                if (iNext > nums.Length - 2) return res;
                for (int i = iNext; i < nums.Length; i++)
                {
                    if (set.Contains(target - nums[i]))
                    {
                        var arr = new int[] { -target, target - nums[i], nums[i] };
                        Array.Sort(arr);
                        res.Add((arr[0], arr[1], arr[2]));
                    }
                    set.Add(nums[i]);
                }
                return res;
            }
        }

        public class Solution2
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                Array.Sort(nums);
                var res = new List<IList<int>>();
                for (int i = 0; i < nums.Length && nums[i] <= 0; i++)
                {
                    if (i == 0 || nums[i - 1] != nums[i])
                    {
                        TwoSum(nums, i, res);
                    }
                }
                return res;
            }

            public void TwoSum(int[] nums, int cur, List<IList<int>> res)
            {
                if (cur > nums.Length - 3) return;
                var seen = new HashSet<int>();
                for (int i = cur + 1; i < nums.Length; i++)
                {
                    if (seen.Contains(-nums[cur] - nums[i]))
                    {
                        var arr = new int[] { nums[cur], -nums[cur] - nums[i], nums[i] };
                        res.Add(new List<int>(arr));
                        while (i + 1 < nums.Length && nums[i] == nums[i + 1])
                        {
                            ++i;
                        }
                    }
                    seen.Add(nums[i]);
                }
            }
        }
    }
}
