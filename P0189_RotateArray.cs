using NUnit.Framework;
namespace Leetcode
{
    public class P0189_RotateArray
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1);
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            RotateArray(nums, 3);
            Assert.AreEqual(5, nums[0]);
            Assert.AreEqual(6, nums[1]);
            Assert.AreEqual(7, nums[2]);
            Assert.AreEqual(1, nums[3]);
            Assert.AreEqual(2, nums[4]);
            Assert.AreEqual(3, nums[5]);
            Assert.AreEqual(4, nums[6]);
        }

        public void RotateArray(int[] nums, int k)
        {
            if (nums.Length <= 1) return;

            k = k % nums.Length;

            if (k == 0) return;

            int[] temp = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                temp[(i + k)%nums.Length] = nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = temp[i];
            }
        }
    }
}
