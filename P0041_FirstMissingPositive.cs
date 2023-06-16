using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0041_FirstMissingPositive
    {

        public class Solution1
        {
            public int FirstMissingPositive(int[] nums)
            {
                int n = nums.Length;

                // Base case.
                bool containsOne = false;
                for (int i = 0; i < n; i++)
                {
                    if (nums[i] == 1)
                    {
                        containsOne = true;
                        break;
                    }
                }
                if (!containsOne) return 1;

                // Replace negative numbers, zeros,
                // and numbers larger than n by 1s.
                // After this convertion nums will contain 
                // only positive numbers.
                for (int i = 0; i < n; i++)
                {
                    if ((nums[i] <= 0) || (nums[i] > n)) nums[i] = 1;
                }

                // Use index as a hash key and number sign as a presence detector.
                // For example, if nums[1] is negative that means that number `1`
                // is present in the array. 
                // If nums[2] is positive - number 2 is missing.
                for (int i = 0; i < n; i++)
                {
                    int a = Math.Abs(nums[i]);
                    // If you meet number a in the array - change the sign of a-th element.
                    // Be careful with duplicates : do it only once.
                    if (a == n)
                        nums[0] = -Math.Abs(nums[0]);
                    else
                        nums[a] = -Math.Abs(nums[a]);
                }

                // Now the index of the first positive number 
                // is equal to first missing positive.
                for (int i = 1; i < n; i++)
                {
                    if (nums[i] > 0) return i;
                }

                if (nums[0] > 0) return n;

                return n + 1;
            }
        }

        public int FirstMissingPositive_Simple(int[] nums)
        {
            var foundValue = new bool[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 && nums[i] <= nums.Length)
                {
                    foundValue[nums[i]-1] = true;      
                }
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
