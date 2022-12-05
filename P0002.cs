using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0002
    {
        public class Solution
        {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                return AddTwoNumbers_Recur(l1, l2, 0);
            }

            public ListNode AddTwoNumbers_Recur(ListNode l1, ListNode l2, int carry)
            {
                if (l1 == null && l2 == null && carry == 0)
                {
                    return null;
                }
                else
                {
                    int i1 = 0;
                    int i2 = 0;
                    if (l1 != null) i1 = l1.val;
                    if (l2 != null) i2 = l2.val;
                    int total = i1 + i2 + carry;
                    return new ListNode(total % 10, AddTwoNumbers_Recur(l1?.next, l2?.next, total / 10));
                }
            }

            public ListNode AddTwoNumbers_Iter(ListNode l1, ListNode l2)
            {
                ListNode head = new ListNode();
                ListNode cur = head;
                int carry = 0;
                while (l1 != null || l2 != null || carry != 0)
                {
                    int i1 = 0;
                    int i2 = 0;
                    if (l1 != null)
                    {
                        i1 = l1.val;
                        l1 = l1.next;
                    }
                    if (l2 != null)
                    {
                        i2 = l2.val;
                        l2 = l2.next;
                    }
                    int total = i1 + i2 + carry;
                    carry = total / 10;
                    cur.next = new ListNode(total % 10);
                    cur = cur.next;
                }
                return head.next;
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

