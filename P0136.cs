using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0136
    {
        public class Solution
        {
            public int SingleNumber(int[] nums)
            {
                int a = 0;
                foreach (var x in nums)
                {
                    a ^= x;
                }
                return a;
            }
        }
    }

}
