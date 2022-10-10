using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0140_WordBreak2
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var stackList = new List<Stack<string>>();
            var stack0 = new Stack<string>() ;
            stack0.Push("");
            stackList.Add(stack0);
            for (int k = 0; k <= s.Length - 1; k++)
            {
                var stackList1 = new List<Stack<string>>();
                foreach (var stack in stackList)
                {
                    // if last word is valid,  
                    if (wordDict.Contains(stack.Peek()))
                    {
                        var stack1 = new Stack<string>(stack.Reverse());
                        stack1.Push(s[k] + "");
                        stackList1.Add(stack1);
                    }

                    // append new char to the last word in the stack
                    var stack2 = new Stack<string>(stack.Reverse());
                    stack2.Push(stack2.Pop()+s[k]);
                    stackList1.Add(stack2);
                }
                stackList = stackList1;
            }
            var res = new List<string>();
            foreach (var stack in stackList)
            {
                if (wordDict.Contains(stack.Peek()))
                {
                    var str = "";
                    while (stack.Count > 0)
                    {
                        str = stack.Pop() + " " + str;
                    }
                    res.Add(str.Trim());
                }
            }
            return res;
        }
    }
}
