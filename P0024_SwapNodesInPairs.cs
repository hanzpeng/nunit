using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0024_SwapNodesInPairs
    {
        public class Solution
        {
            public ListNode SwapPairs(ListNode head)
            {
                if (head == null) return head;
                if (head.next == null) return head;
                var n1 = head;
                var n2 = n1?.next;
                var n3 = n2?.next;
                if (n1 != null) n1.next = SwapPairs(n3);
                if (n2 != null) n2.next = n1;
                return n2;
            }
            public ListNode SwapPairs_Iter(ListNode head)
            {
                if (head == null || head.next == null) return head;
                var root = head.next;
                var cur = head;
                while (cur != null)
                {
                    var n1 = cur;
                    var n2 = n1?.next;
                    var n3 = n2?.next;
                    var n4 = n3?.next;
                    if (n1 != null)
                    {
                        n1.next = n3;
                        if (n4 != null) n1.next = n4;
                    }
                    if (n2 != null) n2.next = n1;
                    cur = n3;
                }
                return root;
            }
            public class ListNode
            {
                public int val;
                public ListNode next;
            }
        }
    }
}
