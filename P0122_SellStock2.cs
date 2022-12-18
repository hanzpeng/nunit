using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0122_SellStock2
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 1) return 0;
            int p = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i + 1] > prices[i])
                {
                    p += prices[i + 1] - prices[i];
                }
            }
            return p;
        }
    }
}
