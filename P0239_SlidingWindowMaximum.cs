﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0239_SlidingWindowMaximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {

            if (k == 0) return nums;

            int len = nums.Length;
            int maxArrayLen = len - k + 1;
            int[] ans = new int[maxArrayLen];

            LinkedList<int> q = new LinkedList<int>();

            // Queue stores indices of array, and 
            // values are in decreasing order.
            // So, the first node in queue is the max in window
            for (int i = 0; i < len; i++)
            {
                // 1. remove element from head until first number within window
                if (q.Count > 0 && q.First.Value + k <= i)
                {
                    q.RemoveFirst();
                }

                // 2. before inserting i into queue, remove from the tail of the
                // queue indices with smaller value they array[i]
                while (q.Count > 0 && nums[q.Last.Value] <= nums[i])
                {
                    q.RemoveLast();
                }

                q.AddLast(i);

                // 3. set the max value in the window (always the top number in
                // queue)
                int index = i + 1 - k;
                if (index >= 0)
                {
                    ans[index] = nums[q.First.Value];
                }
            }

            return ans;
        }
    }
}
