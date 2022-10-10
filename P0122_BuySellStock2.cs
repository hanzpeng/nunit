using NUnit.Framework;
namespace Leetcode
{
    public class P0122_BuyuSellStock2
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(7, MaxProfit(new int[]{7,1,5,3,6,4}));
            Assert.AreEqual(4, MaxProfit(new int[]{1,2,3,4,5}));
            Assert.AreEqual(0, MaxProfit(new int[]{7,6,4,3,1}));
        }
        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2) return 0;
            int b = 0;
            int s = 1;
            int s1 = 2;
            int g = 0;

            while (s < prices.Length)
            {
                while (s < prices.Length && prices[s] <= prices[b])
                {
                    s++;
                    b++;
                }

                s1 = s + 1;
                while (s1 < prices.Length && prices[s1] >= prices[s])
                {
                    s++;
                    s1++;
                }

                if (s < prices.Length && prices[s] > prices[b])
                {
                    g += prices[s] - prices[b];
                }

                b = s + 1;
                s = b + 1;
            }
            return g;
        }

    }
}