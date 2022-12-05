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
                    return new ListNode(total % 10, AddTwoNumbers(l1?.next, l2?.next, total / 10));
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

