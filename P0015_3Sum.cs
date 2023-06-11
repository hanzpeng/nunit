using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0015_3Sum
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
}
