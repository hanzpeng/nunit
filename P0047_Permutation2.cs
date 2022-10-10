using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0047_Permutation2
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Dictionary<int, int> numsMap = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                numsMap[num] = numsMap.GetValueOrDefault(num, 0) + 1;
            }

            IList<IList<int>> result = new List<IList<int>>();
            Dfs(numsMap, new Stack<int>(), result, nums.Length);
            return result;
        }
        void Dfs(Dictionary<int, int> numsMap, Stack<int> path, IList<IList<int>> result, int length)
        {
            if (path.Count == length)
            {
                result.Add(new List<int>(path));
                return;
            }

            foreach(var entry in numsMap)
            {
                if (entry.Value > 0)
                {
                    path.Push(entry.Key);
                    numsMap[entry.Key]--;
                    Dfs(numsMap, path, result, length);
                    numsMap[entry.Key]++;
                    path.Pop();
                }
            }
        }
    }
}
