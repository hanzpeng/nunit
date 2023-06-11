using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0019_RemooveNthNodeFromEnd
    {
        public class Solution
        {
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                var dummy = new ListNode(0);
                dummy.next = head;
                var p1 = dummy;
                var p2 = dummy;
                for (var i = 1; i <= n + 1; i++)
                {
                    if (p1 == null) return head;
                    p1 = p1.next;
                }
                while (p1 != null)
                {
                    p1 = p1.next;
                    p2 = p2.next;
                }
                p2.next = p2.next.next;
                return dummy.next;
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
}
