using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests {
    internal class P0020_ValidParentheses {
        public class Solution {
            public bool IsValid(string s) {
                var pair = new Dictionary<char, char>{
                                                        {'{', '}'},
                                                        {'(', ')'},
                                                        {'[', ']'}
                                                    };
                var stack = new Stack<char>();
                foreach (var c in s) {
                    if (pair.Keys.Contains(c)) {
                        stack.Push(c);
                    } else if (pair.Values.Contains(c)) {
                        if (stack.Count == 0) {
                            return false;
                        }
                        if (c != pair[stack.Pop()]) return false;
                    }
                }
                return stack.Count == 0;
            }
        }

        public bool IsValid(string s) {
            var stack = new Stack<char>();
            foreach (var ch in s) {
                if (ch == '(' || ch == '[' || ch == '{') {
                    stack.Push(ch);
                }
                if (ch == ')' || ch == ']' || ch == '}') {
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
