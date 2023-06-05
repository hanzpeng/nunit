using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P007_ReversInteger
    {
        public int Reverse(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > int.MaxValue % 10)) return 0;
                if (rev < int.MinValue / 10 || (rev == int.MinValue / 10 && pop < int.MinValue % 10)) return 0;
                rev = rev * 10 + pop;
            }
            return rev;
        }

    }
}
