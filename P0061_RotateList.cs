using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0061_RotateList
    {
        public class Solution
        {
            public ListNode RotateRight(ListNode head, int k)
            {
                if (head == null || head.next == null) return head;
                var tail = head;
                while (tail.next != null)
                {
                    tail = tail.next;
                }
                tail.next = head;

                var front = head;
                for (int i = 0; i < k; i++)
                {
                    front = front.next;
                };

                var back = head;
                while (front != tail)
                {
                    front = front.next;
                    back = back.next;
                }
                var newhead = back.next;
                back.next = null;
                return newhead;
            }

            public class ListNode
            {
                public ListNode next;
            }
        }
    }
}
