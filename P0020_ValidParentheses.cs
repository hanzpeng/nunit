using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0020_ValidParentheses
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            foreach (var ch in s)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (stack.Count == 0) return false;
                    if (ch == ')' && stack.Pop() != '(') return false;
                    else if (ch == ']' && stack.Pop() != '[') return false;
                    else if (ch == '}' && stack.Pop() != '{') return false;
                }
            }
            return stack.Count == 0;
        }
    }
}
