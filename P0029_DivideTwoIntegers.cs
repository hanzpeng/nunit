using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0029_DivideTwoIntegers
    {
        public class Solution
        {
            public int Divide(int dividend, int divisor)
            {
                if (dividend == 0) return 0;
                if (dividend < 0 && dividend < 0)
                {
                    dividend = 0 - dividend;
                    divisor = 0 - divisor;
                    return Divide(dividend, divisor);
                }
                else if (dividend < 0)
                {
                    dividend = 0 - dividend;
                    return -Divide(dividend, divisor);
                }
                else if (divisor < 0)
                {
                    divisor = 0 - divisor;
                    return -Divide(dividend, divisor);
                }
                int res = 0;
                while (dividend >= divisor)
                {
                    res += 1;
                    dividend -= divisor;
                }
                return res;
            }
        }
    }
}
