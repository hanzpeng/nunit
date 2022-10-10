﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace P0494_TargetSum
{
    class P0494_TargetSum
    {
        /****************************************************************************
            You are given a list of non-negative integers, 
            a1, a2, ..., an, 
            and a target, S. 
            Now you have 2 symbols + and -. 
            For each integer, you should choose one from + and - as its new symbol.
            
            Find out how many ways to assign symbols to make sum of integers equal to target S.

            Example 1:
            Input: nums is [1, 1, 1, 1, 1], S is 3. 
            Output: 5
            Explanation: 

            -1+1+1+1+1 = 3
            +1-1+1+1+1 = 3
            +1+1-1+1+1 = 3
            +1+1+1-1+1 = 3
            +1+1+1+1-1 = 3

            There are 5 ways to assign symbols to make the sum of nums be target 3.
            Note:
            The length of the given array is positive and will not exceed 20.
            The sum of elements in the given array will not exceed 1000.
            Your output answer is guaranteed to be fitted in a 32-bit integer.
         ******************************************************************************/
        [Test]
        public void Test1()
        {
            Assert.AreEqual(5, BruteForce(new int[] { 1, 1, 1, 1, 1 }, target: 3));
            Assert.AreEqual(5, WaysByBuilder(new int[] { 1, 1, 1, 1, 1 }, target: 3));
            Assert.AreEqual(5, WaysByRecurssion(new int[] { 1, 1, 1, 1, 1 }, target: 3));
        }
        public int BruteForce(int[] nums, int target)
        {
            List<int> sumList = new List<int>();
            sumList.Add(0); // this is important, this is the case that we do not pick any element
            for (int i = 0; i < nums.Length; i++)
            {
                var tempList = new List<int>();
                foreach (var s in sumList)
                {
                    tempList.Add(s + nums[i]);  // plus value
                    tempList.Add(s - nums[i]);  // minues value
                }
                sumList = tempList;
            }
            int count = 0;
            foreach (var s in sumList)
            {
                if (s == target) count++;
            }
            return count;

            // Space Complexity: O(2^N)    (Max Lengh of the sumList/tempList)
            // Time  Complexity: O(N * 2^N) each value of tempList is process N times 

        }


        public int WaysByBuilder(int[] nums, int target)
        {
            // number of ways to get to target, key=target, val= number of ways
            Dictionary<int, int> sumWays = new Dictionary<int, int>();
            sumWays[0] = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                Dictionary<int, int> sumWaysNew = new Dictionary<int, int>();
                foreach (var sw in sumWays)
                {
                    int key = sw.Key + nums[i];
                    sumWaysNew[key] = sw.Value + sumWaysNew.GetValueOrDefault(key, 0);

                    key = sw.Key - nums[i];
                    sumWaysNew[key] = sw.Value + sumWaysNew.GetValueOrDefault(key, 0);
                }
                sumWays = sumWaysNew;
            }
            return sumWays[target];

            // Space Complexity: O(2*SumRange)   -> O(2*SumRange)
            // Time  Complexity: O(2*SumRange*N) -> O(SumRange*N)
        }
        public int WaysByRecurssion(int[] nums, int target)
        {
            Dictionary<int, int>[] waysForTargetsAtIndex = new Dictionary<int, int>[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                waysForTargetsAtIndex[i] = new Dictionary<int, int>();
            }
            return WaysByRecurssionHelper(nums, target, 0, waysForTargetsAtIndex);
        }
        public int WaysByRecurssionHelper(int[] nums, int target, int index, Dictionary<int, int>[] waysToTargetsAtIndex)
        {
            if (index == nums.Length)
            {
                if (target == 0) return 1;
                else return 0;
            }

            if (waysToTargetsAtIndex[index].ContainsKey(target))
            {
                return waysToTargetsAtIndex[index][target];
            }

            int ways =
                WaysByRecurssionHelper(nums, target + nums[index], index + 1, waysToTargetsAtIndex) +
                WaysByRecurssionHelper(nums, target - nums[index], index + 1, waysToTargetsAtIndex);

            waysToTargetsAtIndex[index][target] = ways;
            return ways;

            //Space Complexity: O(SumRange*N)
            //Time  Complexity: O(SumRange*N) : each N array Dictionary with key in SumRange, each item is filled only at most once.

            // without Memoization, the time complexity is O(2^N)

        }
    }
}
