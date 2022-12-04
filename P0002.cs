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
                return AddTwoNumbers(l1, l2, 0);
            }

            public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry)
            {
                if (l1 == null && l2 == null && carry == 0)
                    return null;
                else if (l1 == null && l2 == null)
                    return new ListNode(carry, null);
                else if (l1 == null || l2 == null)
                {
                    ListNode l = l1 != null ? l1 : l2;
                    var total = l.val + carry;
                    if (total / 10 == 0)
                    {
                        return new ListNode(total % 10, l.next);
                    }
                    else
                    {
                        return new ListNode(total % 10, AddTwoNumbers(l.next, null, total / 10));
                    }
                }
                else
                {
                    var total = l1.val + l2.val + carry;
                    return new ListNode(total % 10, AddTwoNumbers(l1.next, l2.next, total / 10));
                }
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

