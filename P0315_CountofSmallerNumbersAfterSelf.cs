using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0315_CountofSmallerNumbersAfterSelf
    {
        public void Test()
        {
           var nums = new int[] { 2, 1, 3, 4, 6, 5, 0 };
            var res = CountSmaller(nums);
            foreach (int i in res)
            {
                Console.WriteLine(i);
            }
        }

        public class Node
        {
            public int Index = 0;
            public int Val;
            public int Cnt;
            public Node(int index, int val)
            {
                this.Index = index;
                this.Val = val;
            }
        }
        public IList<int> CountSmaller(int[] nums)
        {
            Node[] numsNodes = new Node[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                numsNodes[i] = new Node(i, nums[i]);
            }
            MergeSort(0, nums.Length - 1, numsNodes);

            int[] result = new int[numsNodes.Length];
            foreach (var item in numsNodes)
            {
                result[item.Index] = item.Cnt;
            }
            return result.ToList();
        }
        public void MergeSort(int l, int r, Node[] nums)
        {
            if (l >= r) return;
            int m = (l + r) / 2;
            MergeSort(l, m, nums);
            MergeSort(m + 1, r, nums);
            var temp = new Node[r - l + 1];
            int i = l, j = m + 1, k = 0;
            int smallerNums = 0; //how many numbers to the right are bigger than us
            while (i <= m && j <= r)
            {
                if (nums[i].Val <= nums[j].Val)
                {
                    nums[i].Cnt += smallerNums;
                    temp[k++] = nums[i++];
                }
                else
                {
                    temp[k++] = nums[j++];
                    smallerNums++;
                }
            }
            while (i <= m) { 
                nums[i].Cnt += smallerNums;
                temp[k++] = nums[i++]; 
            }
            while (j <= r) temp[k++] = nums[j++];
            for (i = l; i <= r; i++) nums[i] = temp[i - l];
        }
    }
}
