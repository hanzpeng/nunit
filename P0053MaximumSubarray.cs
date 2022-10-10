using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0053MaximumSubarray
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2)
            {
                int res = Math.Max(nums[0], nums[1]);
                res = Math.Max(res, nums[0] + nums[1]);
                return res;
            }

            int L = nums.Length;
            List<int> startIndex = new();
            List<int> endIndex = new();
            int[] sum = new int[L];

            if (nums[0] > 0) startIndex.Add(0);
            sum[0] = nums[0];
            int max = nums[0];
            for (int i = 1; i < L - 1; i++)
            {
                sum[i] = sum[i - 1] + nums[i];
                max = Math.Max(nums[i], max);
                max = Math.Max(max, sum[i]);
                if (nums[i] > 0 && nums[i - 1] <= 0) startIndex.Add(i);
                if (nums[i] > 0 && nums[i + 1] <= 0) endIndex.Add(i);
            }

            sum[L - 1] = sum[L - 2] + nums[L - 1];
            max = Math.Max(max, nums[L - 1]);
            max = Math.Max(max, sum[L - 1]);
            if (nums[L - 1] > 0) endIndex.Add(L - 1);

            if (startIndex.Count == 0 || endIndex.Count == 0) return max;

            for (int i = 0; i < startIndex.Count; i++)
            {
                for (int j = 0; j < endIndex.Count; j++)
                {
                    int left = startIndex[i];
                    int right = endIndex[j];
                    if (right > left)
                    {
                        var val = left > 0 ? sum[right] - sum[left - 1] : sum[right];
                        if (val > max) max = val;
                    }
                }
            }
            return max;
        }
    }
}
