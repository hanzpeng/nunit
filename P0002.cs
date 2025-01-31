using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0002
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }
        public class Solution1
        {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
                var head = new ListNode();
                var tail = head;
                var carry = 0;
                while (l1 != null || l2 != null || carry != 0) {
                    tail.next = new ListNode();
                    tail = tail.next;
                    var cur = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;
                    // var cur = l1?.val??0 + l2?.val??0 + carry; // this does not work in leetcode
                    tail.val = cur % 10;
                    carry = cur / 10;
                    l1 = l1?.next;
                    l2 = l2?.next;
                }
                return head.next;
            }

        }
        public class Solution2 {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
                return AddTwoNumbers(l1, l2, 0);
            }

            public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry) {
                if (l1 == null && l2 == null && carry == 0) return null;
                var cur = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;
                return new ListNode(cur % 10, AddTwoNumbers(l1?.next, l2?.next, cur / 10));
            }
        }
    }

}

