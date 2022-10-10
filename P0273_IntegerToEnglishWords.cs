using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0273_IntegerToEnglishWords
    {
        string[] doubles = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        string[] thousands = { "Thousand", "Million", "Billion", "Trillion", "Zillion" };
        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";
            Stack<string> stack = new();
            int i = 0;
            while (num > 0)
            {
                if (num % 1000 > 0)
                {
                    GetStringUnderThousand(num % 1000, stack);
                }
                num /= 1000;
                if (num % 1000 > 0)
                {
                    stack.Push(thousands[i]);
                }
                i++;
            }

            string res = "";
            while (stack.Count > 0)
            {
                res = res + " " + stack.Pop();
            }
            return res.Trim();
        }


        public Stack<string> GetStringUnderThousand(int rem, Stack<string> stack)
        {
            if (rem > 1000) rem = rem % 1000;
            if (rem % 100 >= 20)
            {
                //sigles
                if (rem % 10 > 0)
                {
                    stack.Push(doubles[rem % 10]);
                }
                //tens
                stack.Push(tens[(rem % 100) / 10]);
            }
            else if (rem % 100 < 20 && rem % 100 > 0)
            {
                //teens or singles
                stack.Push(doubles[rem % 100]);
            }

            if (rem / 100 > 0)
            {
                stack.Push(doubles[rem / 100] + " Hundred");
            }
            return stack;
        }
    }
}
