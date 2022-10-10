using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0123_SellStock3
    {
        public int MaxProfit(int[] prices)
        {
            var length = prices.Length;
            if (prices == null || length <= 1)
            {
                return 0;
            }

            if (length == 2)
            {
                return Math.Max(0, prices[1] - prices[0]);
            }

            var leftProf = new int[length];
            var min = int.MaxValue;
            for (int i = 1; i < length; i++)
            {
                min = Math.Min(min, prices[i - 1]);
                leftProf[i] = Math.Max(leftProf[i - 1], prices[i] - min);
            }

            var rightProf = new int[length];
            var max = int.MinValue;
            for (int i = length - 2; i >= 0; i--)
            {
                max = Math.Max(max, prices[i + 1]);
                rightProf[i] = Math.Max(rightProf[i + 1], max - prices[i]);
            }

            var maxP = 0;
            for (int i = 1; i < length - 1; i++)
            {
                maxP = Math.Max(maxP, rightProf[i] + leftProf[i]);
            }

            return maxP;
        }
    }
}
