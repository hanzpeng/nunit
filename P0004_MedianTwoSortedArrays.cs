using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace NUnitTests
{
    internal class P0004_MedianTwoSortedArrays
    {
        [Test]
        public void Test()
        {
            Console.WriteLine("tests hanz");
            Assert.AreEqual(true, 1 == 1);
            Assert.AreEqual(4, findMedianSortedArrays_BinarySearch(new int[] {1,2,}, new int[] {4,5,6}));
        }
        public double GetMedianOfSortedArray_BrutalForce(int[] nums1, int[] nums2)
        {
            int n1 = nums1.Length;
            int n2 = nums2.Length;
            int n = n1 + n2;
            int[] nums = new int[n1 + n2];
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < n1 && j < n2)
            {
                if (nums1[i] < nums2[j])
                    nums[k++] = nums1[i++];
                else
                    nums[k++] = nums2[j++];
            }
            while (i < n1)
                nums[k++] = nums1[i++];
            while (j < n2)
                nums[k++] = nums2[j++];

            double r = 0;
            if (n % 2 == 1)
                r = nums[n / 2];
            else
                r = (nums[n / 2] + nums[n / 2 - 1]) / 2.0;

            return r;

        }

        //binary search
        public double findMedianSortedArrays_BinarySearch(int[] A, int[] B)
        {
            int m = A.Length;
            int n = B.Length;
            if (m > n)
            { // to ensure m<=n
                return findMedianSortedArrays_BinarySearch(B, A);
            }
            int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2;
            while (iMin <= iMax)
            {
                int i = (iMin + iMax) / 2;
                int j = halfLen - i;
                if (i < iMax && B[j - 1] > A[i])
                {
                    iMin = i + 1; // i is too small
                }
                else if (i > iMin && A[i - 1] > B[j])
                {
                    iMax = i - 1; // i is too big
                }
                else
                { // i is perfect
                    int maxLeft;
                    if (i == 0)
                    {
                        maxLeft = B[j - 1];
                    }
                    else if (j == 0)
                    {
                        maxLeft = A[i - 1];
                    }
                    else
                    {
                        maxLeft = Math.Max(A[i - 1], B[j - 1]);
                    }
                    if ((m + n) % 2 == 1)
                    {
                        return maxLeft;
                    }

                    int minRight = 0;
                    if (i == m)
                    {
                        minRight = B[j];
                    }
                    else if (j == n)
                    {
                        minRight = A[i];
                    }
                    else
                    {
                        minRight = Math.Min(B[j], A[i]);
                    }

                    return (maxLeft + minRight) / 2.0;
                }
            }
            return 0.0;
        }


    }
}
