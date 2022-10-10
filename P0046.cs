using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0046
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Dfs(nums, new Stack<int>(), new bool[nums.Length], result);
            return result;
        }
        void Dfs(int[] nums, Stack<int> path, bool[] used, IList<IList<int>> result)
        {
            if (path.Count == nums.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!used[i])
                {
                    path.Push(nums[i]);
                    used[i] = true;
                    Dfs(nums, path, used, result);
                    used[i] = false;
                    path.Pop();
                }
            }
        }
    }
}
