using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0403_FrogJump
    {
        public bool CanCross(int[] stones)
        {
            Dictionary<int, HashSet<int>> map = new();
            for (int i = 0; i < stones.Length; i++)
            {
                map[stones[i]] = new HashSet<int>();
            }
            map[0].Add(0);
            for (int i = 0; i < stones.Length; i++)
            {
                foreach (int step in map[stones[i]])
                {
                    for (int k = step - 1; k <= step + 1; k++)
                    {
                        if (k > 0 && map.ContainsKey(stones[i] + k))
                        {
                            map[stones[i] + k].Add(k);
                        }
                    }
                }
            }
            return map[stones[stones.Length - 1]].Count > 0;
        }
    }
}
