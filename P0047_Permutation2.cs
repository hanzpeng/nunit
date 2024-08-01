using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests {
    internal class P0047_Permutation2_A {

        public class Solution0 {
            public IList<IList<int>> PermuteUnique(int[] nums) {
                var res = new List<IList<int>>();
                SwapEachRemainingNumberWithCurrentPosition(nums, 0, res);
                return res;
            }
            public void SwapEachRemainingNumberWithCurrentPosition(int[] nums, int pos, List<IList<int>> res) {
                if (pos == nums.Length) {
                    res.Add(new List<int>(nums));
                    return;
                }
                var valueUsed = new HashSet<int>();
                for (int j = pos; j < nums.Length; j++) {
                    if (valueUsed.Contains(nums[j])) continue;
                    // put every remaining number in current index, including the current index itself
                    (nums[pos], nums[j]) = (nums[j], nums[pos]);
                    SwapEachRemainingNumberWithCurrentPosition(nums, pos + 1, res);
                    (nums[pos], nums[j]) = (nums[j], nums[pos]);
                    valueUsed.Add(nums[j]);
                }
            }
        }

        public class Solution1_UsedIndex {
            public IList<IList<int>> PermuteUnique(int[] nums) {
                IList<IList<int>> result = new List<IList<int>>();
                Dfs(nums, new Stack<int>(), new bool[nums.Length], result);
                return result;
            }
            void Dfs(int[] nums, Stack<int> cur, bool[] used, IList<IList<int>> result) {
                if (cur.Count == nums.Length) {
                    result.Add(new List<int>(cur));
                    return;
                }
                var valueUsedInCurrentPosition = new HashSet<int>();
                for (int i = 0; i < nums.Length; i++) {
                    if (!used[i]) {
                        if (valueUsedInCurrentPosition.Contains(nums[i])) continue;
                        cur.Push(nums[i]);
                        used[i] = true;
                        Dfs(nums, cur, used, result);
                        used[i] = false;
                        cur.Pop();
                        valueUsedInCurrentPosition.Add(nums[i]);
                    }
                }
            }
        }

        public class Solution2_NumCount {
            public IList<IList<int>> PermuteUnique(int[] nums) {
                Dictionary<int, int> numCount = new Dictionary<int, int>();
                foreach (int num in nums) {
                    numCount[num] = numCount.GetValueOrDefault(num, 0) + 1;
                }

                IList<IList<int>> result = new List<IList<int>>();
                Dfs(numCount, new Stack<int>(), result, nums.Length);
                return result;
            }
            void Dfs(Dictionary<int, int> numsMap, Stack<int> path, IList<IList<int>> result, int length) {
                if (path.Count == length) {
                    result.Add(new List<int>(path));
                    return;
                }

                foreach (var entry in numsMap) {
                    if (entry.Value > 0) {
                        path.Push(entry.Key);
                        numsMap[entry.Key]--;
                        Dfs(numsMap, path, result, length);
                        numsMap[entry.Key]++;
                        path.Pop();
                    }
                }
            }
        }

        public class Solution3 {
            public IList<IList<int>> PermuteUnique(int[] nums) {
                if (nums?.Length < 1) return null;
                Array.Sort(nums);
                var res = new List<IList<int>>();
                dfs(nums, res, new List<int>(), new bool[nums.Length]);
                return (IList<IList<int>>)res;
            }
            public void dfs(int[] nums, List<IList<int>> res, List<int> cur, bool[] visited) {
                if (cur.Count == nums.Length) {
                    res.Add(new List<int>(cur));
                    return;
                }
                for (var i = 0; i < nums.Length; i++) {
                    if (visited[i]) continue;
                    if (i > 0 && nums[i] == nums[i - 1] && !visited[i - 1]) continue;
                    cur.Add(nums[i]);
                    visited[i] = true;
                    dfs(nums, res, cur, visited);
                    visited[i] = false;
                    cur.RemoveAt(cur.Count - 1);
                }
            }
        }

        public class Solution4 {
            public IList<IList<int>> PermuteUnique(int[] nums) {
                var res = new List<IList<int>>();
                Array.Sort(nums);
                Bt(0, nums, res);
                return res;
            }
            public void Bt(int pos, int[] nums, List<IList<int>> res) {
                if (pos == nums.Length) {
                    res.Add(new List<int>(nums));
                }
                for (int i = pos; i < nums.Length; i++) {
                    if (i > pos && nums[i] == nums[i - 1]) continue;
                    (nums[pos], nums[i]) = (nums[i], nums[pos]);
                    Bt(pos + 1, nums, res);
                    (nums[pos], nums[i]) = (nums[i], nums[pos]);
                }
            }

        }

        public class Solution5_Iterative {
            public IList<IList<int>> PermuteUnique(int[] nums) {
                var res = new List<IList<int>>();
                if (nums == null || nums.Length == 0) {
                    return res;
                }

                Array.Sort(nums);

                for (var j = 0; j < nums.Length; j++) {
                    if (j > 0 && nums[j] == nums[j - 1]) continue;
                    var list = new List<int>();
                    list.Add(j);
                    res.Add(list);
                }

                for (var i = 1; i < nums.Length; i++) {
                    var res1 = new List<IList<int>>();
                    foreach (var list in res) {
                        for (var j = 0; j < nums.Length; j++) {
                            if (list.Contains(j)) continue;
                            if (j > 0 && nums[j] == nums[j - 1] && !list.Contains(j - 1)) continue;
                            var newList = new List<int>(list);
                            newList.Add(j);
                            res1.Add(newList);
                        }
                    }
                    res = res1;
                }
                return res.Select(l => (IList<int>)l.Select(j => nums[j]).ToList()).ToList();
            }
        }

        public class Solution5b__Iterative {
            public IList<IList<int>> PermuteUnique(int[] nums) {
                var res = new List<IList<int>>();
                if (nums == null || nums.Length == 0) {
                    return res;
                }

                Array.Sort(nums);

                for (var j = 0; j < nums.Length; j++) {
                    if (j > 0 && nums[j] == nums[j - 1]) continue;
                    var list = new List<int>();
                    list.Add(j);
                    res.Add(list);
                }

                for (var i = 1; i < nums.Length; i++) {
                    var res1 = new List<IList<int>>();
                    foreach (var list in res) {
                        int? prev = null;
                        for (var j = 0; j < nums.Length; j++) {
                            if (list.Contains(j)) continue;
                            if (prev == nums[j]) continue;
                            var newList = new List<int>(list);
                            newList.Add(j);
                            res1.Add(newList);
                            prev = nums[j];
                        }
                    }
                    res = res1;
                }
                return res.Select(l => (IList<int>)l.Select(j => nums[j]).ToList()).ToList();
            }
        }

        public class Solution6 {
            public IList<IList<int>> PermuteUnique(int[] nums) {
                var res = new List<IList<int>>();
                if (nums == null || nums.Length == 0) {
                    return res;
                }

                Array.Sort(nums);
                BT(nums, res, new Stack<int>());
                return res.Select(l => (IList<int>)l.Select(i => nums[i]).ToList()).ToList();
            }

            public void BT(int[] nums, List<IList<int>> res, Stack<int> pre) {
                if (pre.Count == nums.Length) {
                    res.Add(new List<int>(pre));
                    return;
                }

                int? previousNumber = null;
                for (int i = 0; i < nums.Length; i++) {
                    if (pre.Contains(i)) continue;
                    if (previousNumber == nums[i]) continue;
                    pre.Push(i);
                    BT(nums, res, pre);
                    pre.Pop();
                    previousNumber = nums[i];
                }
            }
        }

        public class Solution7 {
            public IList<IList<int>> PermuteUnique(int[] nums) {
                var res = new List<IList<int>>();
                if (nums == null || nums.Length == 0) {
                    return res;
                }
                Array.Sort(nums);
                BT(nums, res, new Stack<int>());
                return res.Select(l => (IList<int>)l.Select(i => nums[i]).ToList()).ToList();
            }

            public void BT(int[] nums, List<IList<int>> res, Stack<int> pre) {
                if (pre.Count == nums.Length) {
                    res.Add(new List<int>(pre));
                    return;
                }

                int? previousNumber = null;
                for (int i = 0; i < nums.Length; i++) {
                    if (pre.Contains(i)) continue;
                    if (nums[i] == previousNumber) continue;
                    pre.Push(i);
                    BT(nums, res, pre);
                    pre.Pop();
                    previousNumber = nums[i];
                }
            }
        }

        public class Solution8_pre_rem {
            public IList<IList<int>> PermuteUnique(int[] nums) {
                var res = new List<IList<int>>();
                if (nums == null || nums.Length == 0) {
                    return res;
                }
                Array.Sort(nums);
                BT(new Stack<int>(), nums.ToList(), res);
                return res;
            }

            public void BT(Stack<int> pre, List<int> rem, List<IList<int>> res) {
                if (rem.Count == 0) {
                    res.Add(new List<int>(pre));
                    return;
                }

                int? previousNumber = null;
                for (var i = 0; i < rem.Count; i++) {
                    var num = rem[i];
                    if (previousNumber == num) continue;
                    pre.Push(num);
                    rem.RemoveAt(i);
                    BT(pre, rem, res);
                    pre.Pop();
                    rem.Insert(i, num);
                    previousNumber = num;
                }
            }
        }
    }
}
