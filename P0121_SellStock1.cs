using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0121_SellStock1
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1)
            {
                return 0;
            }

            var rightMax = new int[prices.Length + 1];
            rightMax[prices.Length] = int.MinValue;
            for (int i = prices.Length - 1; i > 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], prices[i]);
            }

            var maxP = 0;
            var min = int.MaxValue;
            for (int i = 1; i <= prices.Length - 1; i++)
            {
                min = Math.Min(min, prices[i - 1]);
                maxP = Math.Max(maxP, rightMax[i] - min);
            }

            return maxP;
        }
    }
}
