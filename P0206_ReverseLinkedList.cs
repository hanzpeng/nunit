﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0206_ReverseLinkedList
    {
        public class Solution {
            public ListNode ReverseList(ListNode head) {
                ListNode tail = null;
                while (head != null) {
                    var newhead = head.next;
                    var newtail = head;
                    head.next = tail;
                    tail = newtail;
                    head = newhead;
                }
                return tail;
            }
        }

        public ListNode ReverseListRecursive(ListNode head)
        {
            if (head == null || head.next == null) return head;
            var nextTail = head.next;
            var nextHead = ReverseListRecursive(head.next);
            nextTail.next = head;
            head.next = null;
            return nextHead;
        }

        public ListNode ReverseListIterative(ListNode head)
        {
            ListNode tail = null;
            while (head != null) {
                var nextHead = head.next;
                head.next = tail;
                tail = head;
                head = nextHead;
            }
            return tail;
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
