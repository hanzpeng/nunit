using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0167
    {
        public class Solution {
            public int[] TwoSum(int[] numbers, int target) {
                var l = 0;
                var r = numbers.Length - 1;
                while (l < r) {
                    var res = numbers[l] + numbers[r];
                    if (res == target) {
                        while (r - 1 > l && numbers[r - 1] == numbers[r]) {
                            r--;
                        }
                        return new int[] { ++l, ++r };
                    } else if (res > target) {
                        r--;
                    } else {
                        l++;
                    }
                }
                return new int[] { };
            }
        }

    }
}
