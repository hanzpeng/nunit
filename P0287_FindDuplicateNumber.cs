using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0287_FindDuplicateNumber
    {
        public void test()
        {

        }
        public static int FindDuplicate(int[] nums)
        {
            var slow = nums[0];
            var fast = nums[0];
            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            }
            while (slow != fast);
            slow = nums[0];
            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[fast];
            }
            return slow;
        }
    }

}
