using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0234_Palindrome_Linked_List
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head == null) return true;

            Stack<int> stack = new();
            ListNode n = head;
            while (n != null)
            {
                stack.Push(n.val);
                n = n.next;
            }

            while (head != null)
            {
                if (head.val != stack.Pop())
                {
                    return false;
                }
                head = head.next;
            }
            return true;

        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
