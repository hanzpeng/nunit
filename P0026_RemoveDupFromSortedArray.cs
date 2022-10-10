using NUnit.Framework;
namespace Leetcode
{
    public class P0026_RemoveDupFromSortedArray
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(0, RemoveDup(new int[] { }));
            Assert.AreEqual(1, RemoveDup(new int[] { 0 }));
            Assert.AreEqual(2, RemoveDup(new int[] { 0, 1 }));
            Assert.AreEqual(5, RemoveDup(new int[] { 0, 1, 2, 3, 4 }));
            Assert.AreEqual(1, RemoveDup(new int[] { 0, 0, 0, 0, 0 }));
            Assert.AreEqual(2, RemoveDup(new int[] { 0, 0, 0, 1, 1 }));
            Assert.AreEqual(2, RemoveDup(new int[] { 1, 1, 2 }));
            Assert.AreEqual(5, RemoveDup(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }));
        }
        public int RemoveDup(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;
            int i = 0;
            int j = 0;
            while (++j < nums.Length)
            {
                if (nums[j] != nums[i])
                {
                    nums[++i] = nums[j];
                }
            }
            return i + 1;
        }
    }
}

/*
26. Remove Duplicates from Sorted Array
Given a sorted array nums, remove the duplicates in-place such that each element appears only once and returns the new length.
Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
*/

