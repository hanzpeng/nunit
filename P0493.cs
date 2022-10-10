using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using NUnit.Framework;

namespace P0493
{
    class P0493
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(1, 1);
            Assert.AreEqual(2, ReversePairs(new int[]{ 1,3,2,3,1}));
            Assert.AreEqual(9, ReversePairs(new int[] { 2147483647, 2147483647, -2147483647, -2147483647, -2147483647, 2147483647 }));
        }

        public int ReversePairs(int[] nums)
        {
            return mergeSort(nums, 0, nums.Length - 1);
        }
        public int mergeSort(int[] nums, int l, int r)
        {
            if (l >= r) return 0;
            int m = (l + r) / 2;
            return mergeSort(nums, l, m) + mergeSort(nums, m + 1, r) + merge(nums, l, r, m);
        }

        public int merge(int[]nums, int l, int r, int m)
        {
            int res = getPairNumber(nums, l, r, m);

            int i = l;
            int j = m + 1;
            int k = l;
            int[] temp = new int[nums.Length];
            while (i <= m && j <= r)
            {
                if (nums[i] <= nums[j])
                {
                    temp[k++] = nums[i++];
                }
                else // nums[i] > nums[j]
                {
                    temp[k++] = nums[j++];
                }
            }
            while (i <= m)
            {
                temp[k++] = nums[i++];

            }
            while (j <= r)
            {
                temp[k++] = nums[j++];
            }

            for (k = l; k <= r; k++)
            {
                nums[k] = temp[k];
            }

            return res;
        }

        public int getPairNumber(int[] nums, int l, int r, int m)
        {
            int res = 0;
            for(int i=l, j=m+1; i<=m && j <= r; i++)
            {
                while(j<=r && (double)nums[i]/2 > nums[j])
                {
                    res += m - i + 1;
                    j++;
                }
            }
            return res;
        }


    }
}
