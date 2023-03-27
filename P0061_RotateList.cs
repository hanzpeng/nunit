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
                // base cases
                if (head == null) return null;
                if (head.next == null) return head;

                // close the linked list into the ring
                ListNode old_tail = head;
                int n;
                for (n = 1; old_tail.next != null; n++)
                    old_tail = old_tail.next;
                old_tail.next = head;

                // find new tail : (n - k % n - 1)th node
                // and new head : (n - k % n)th node
                ListNode new_tail = head;
                for (int i = 0; i < n - k % n - 1; i++)
                    new_tail = new_tail.next;
                ListNode new_head = new_tail.next;

                // break the ring
                new_tail.next = null;

                return new_head;
            }
        }
        public class Solution2
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


        }

        public class ListNode
        {
            public ListNode next;
        }
    }
}
