using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0206_ReverseLinkedList
    {
        public ListNode ReverseListRecursive(ListNode head)
        {
            if(head == null || head.next == null) return head;

            var current = head.next;
            var newHead = ReverseListRecursive(current);
            current.next = head;
            head.next = null;
            return newHead;

        }

        public ListNode ReverseListIterative(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode pre = null;
            var cur = head;
            while (cur != null)
            {
                var temp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = temp;
            }
            return pre;
        }

        public ListNode ReverseList2(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode tail = null;
            var n1 = head;
            while (n1 != null)
            {
                var n2 = n1.next;
                n1.next = tail;
                tail = n1;
                n1 = n2;
            }
            return tail;
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
