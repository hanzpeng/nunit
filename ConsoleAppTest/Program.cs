using NUnit.Framework;
using System;
using System.Collections.Generic;

Console.WriteLine("hi");

int[] nums = [1, 2, 3, 4, 5, 6, 7];
var x = Array.BinarySearch(nums,3);
Console.WriteLine(Bs(nums,4));


int Bs(int[] nums, int x) {
    int l = 0;
    int r = nums.Length - 1;
    while (l <= r) {
        var m = (l + r) / 2;
        if (nums[m] < x) {
            r = m - 1;
        } else if (nums[m] > x) {
            l = m + 1;
        } else {
            return m;
        }
        l++;
        r--;
    }
    return -1;
}

