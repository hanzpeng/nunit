using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0135_Candy
    {
        public int Candy(int[] ratings)
        {
            var candy = new int[ratings.Length];
            for (int i = 0; i < ratings.Length; i++)
            {
                candy[i] = 1;
            }

            for (int i = 1; i <= ratings.Length - 1; i++)
            {
                if (ratings[i] > ratings[i - 1] && candy[i] <= candy[i - 1])
                {
                    candy[i] = candy[i - 1] + 1;
                }
            }

            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1] && candy[i] <= candy[i + 1])
                {
                    candy[i] = candy[i + 1] + 1;
                }
            }

            int sum = 0;
            foreach (var val in candy)
            {
                sum += val;
            }
            return sum;
        }
    }
}
