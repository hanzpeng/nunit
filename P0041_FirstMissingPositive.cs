using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0041_FirstMissingPositive
    {
        public int FirstMissingPositive_Simple(int[] nums)
        {
            var foundValue = new bool[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 && nums[i] <= nums.Length)
                {
                    foundValue[nums[i]-1] = true;                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (foundValue[i] == false)
                {
                    return i+1;
                }
            }
            return nums.Length + 1;
        }

        public int FirstMissingPositive(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0 || nums[i] > nums.Length)
                {
                    nums[i] = 0;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 && nums[i] <= nums.Length)
                {
                    handleValue(nums, nums[i]);
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != -1) return i + 1;
            }
            return nums.Length + 1;
        }

        public void handleValue(int[] nums, int value)
        {
            int index = value - 1;
            int temp = nums[index];
            nums[index] = -1;

            if (temp - 1 == index) return;
            if (temp > 0 && temp <= nums.Length)
            {
                handleValue(nums, temp);
            }
        }



    }
}
