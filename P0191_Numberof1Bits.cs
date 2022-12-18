using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0191_Numberof1Bits
    {
        public class Solution
        {
            public int HammingWeight(uint n)
            {
                uint count = 0;
                while (n != 0)
                {
                    //count += n % 2;
                    count += n & 1;
                    n = n >> 1;
                }
                return (int)count;
            }
        }
    }
}
