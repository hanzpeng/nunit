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
            if (head == null) return null;
            var current = head.next;
            head.next = null;
            while (current != null)
            {
                var temp = current.next;
                current.next = head;
                head = current;
                current = temp;
            }
            return head;
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
