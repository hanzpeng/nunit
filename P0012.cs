using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0012
    {
        public string IntToRoman(int num) {
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] sym = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            StringBuilder sb = new();
            for (var i = 0; i < values.Length && num > 0; i++) {
                while (values[i] <= num) {
                    num -= values[i];
                    sb.Append(sym[i]);
                }
            }
            return sb.ToString();
        }
    }
}
