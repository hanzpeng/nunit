using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0053MaximumSubarray
    {
        public class Solution
        {
            public int MaxSubArray(int[] nums)
            {
                int cur = nums[0];
                int max = cur;
                for (int i = 1; i < nums.Length; i++)
                {
                    cur = Math.Max(nums[i], cur + nums[i]);
                    max = Math.Max(max, cur);
                }
                return max;
            }
        }
    }
}
