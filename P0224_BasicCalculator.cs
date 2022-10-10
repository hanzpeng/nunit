using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0224_BasicCalculator
    {
        public class Node
        {
            public bool IsLeft;
            public int Val;
            public Node(int val, bool isLeft = false)
            {
                this.Val = val;
                this.IsLeft = isLeft;
            }
        }

        public int Calculate(string s)
        {
            Stack<Node> stack = new();
            int current = 0;
            int sign = 1;
            s = "(" + s + ")";
            foreach (char ch in s)
            {
                if (ch == ' ')
                {

                }
                else if (Char.IsDigit(ch))
                {
                    current = 10 * current + ch - '0';
                }
                else
                {
                    if (ch == '+')
                    {
                        current = sign * current;
                        if (stack.Count > 0 && !stack.Peek().IsLeft)
                        {
                            current += stack.Pop().Val;
                        }
                        stack.Push(new Node(current));
                        sign = 1;
                        current = 0;
                    }
                    else if (ch == '-')
                    {
                        current = sign * current;
                        if (stack.Count > 0 && !stack.Peek().IsLeft)
                        {
                            current += stack.Pop().Val;
                        }
                        stack.Push(new Node(current));
                        sign = -1;
                        current = 0;
                    }
                    else if (ch == '(')
                    {
                        stack.Push(new Node(sign, true));
                        sign = 1;
                        current = 0;
                    }
                    else if (ch == ')')
                    {
                        if (stack.Count > 0)
                        {
                            if (!stack.Peek().IsLeft)
                            {
                                current = sign * current;
                                current += stack.Pop().Val;
                            }

                            int prevSign = 1;
                            if (stack.Count > 0 && stack.Peek().IsLeft)
                            {
                                prevSign = stack.Pop().Val;
                            }
                            current = prevSign * current;
                            sign = 1;
                        }
                    }
                }
            }
            return current;
        }
    }
}
