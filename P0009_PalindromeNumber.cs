using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0009_PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;

            int numberOfDigits = NumberOfDigits(x);
            for (int i = 1; i <= numberOfDigits / 2; i++)
            {
                if (DigitAt(x, i) != DigitAt(x, numberOfDigits - i + 1))
                {
                    return false;
                }
            }
            return true;
        }

        public int NumberOfDigits(int y)
        {
            int numberOfDigits = 0;
            while (y != 0)
            {
                numberOfDigits++;
                y /= 10;
            }
            return numberOfDigits;
        }

        public int DigitAt(int x, int i)
        {
            return (x / (int)Math.Pow(10, (i - 1))) % 10;
        }

        public bool IsPalindrome2(int x)
        {
            if (x < 0) return false;
            return Reverse(x) == x;
        }

        public int Reverse(int x)
        {
            int y = 0;
            while (x != 0)
            {
                y = y * 10 + x % 10;
                x /= 10;
            }
            return y;
        }
    }
}
