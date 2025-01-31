using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0001_TwoSum
    {
        public class Solution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                var numIndex = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (numIndex.ContainsKey(target - nums[i]))
                    {
                        return new int[] { numIndex[target - nums[i]], i };
                    }
                    numIndex[nums[i]] = i;
                }
                return null;
            }
        }
    }
}
