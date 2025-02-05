using System;
using NUnit.Framework;

namespace P0025_ReverseLinkedList
{
    public class Solution {
        public ListNode ReverseKGroup(ListNode head, int k) {
            ListNode res = null;
            ListNode tail = null;
            while (head != null) {
                ListNode newHead;
                ListNode revHead = head;

                bool isIncompleteSection = false;
                var pt = head;
                for (int i = 0; i < k; i++) {
                    if (pt == null) {
                        isIncompleteSection = true;
                        break;
                    }
                    pt = pt.next;
                }
                newHead = pt;

                if (isIncompleteSection) {
                    revHead = head;
                    if (tail != null) tail.next = revHead;
                    head = null;
                } else {
                    revHead = ReverseK(head, k);
                    head.next = newHead;
                    if (tail != null) tail.next = revHead;
                    tail = head;
                    head = newHead;
                }

                if (res == null) {
                    res = revHead;
                }
            }
            return res;
        }

        ListNode ReverseK(ListNode head, int k) {
            if (head == null) return head;
            ListNode tail = null;
            var pt = head;
            while (k > 0) {
                var next = pt.next;
                pt.next = tail;
                tail = pt;
                pt = next;
                k--;
            }
            return tail;
        }
    }
    public class Solution1
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || head.next == null) return head;
            ListNode dummy = new ListNode();
            var cur = head;
            var tail = dummy;
            while (cur != null)
            {
                tail.next = ReverseKGroupHelper(cur, k, out ListNode remain);
                tail = cur;
                cur = remain;
            }
            return dummy.next;
        }

        public ListNode ReverseKGroupHelper(ListNode head, int k, out ListNode remain)
        {
            ListNode pre = null;
            var cur = head;
            while (cur != null && k > 0)
            {
                var cur_next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = cur_next;
                k--;
            }
            remain = cur;
            if (k > 0)
            {
                return Reverse(pre);
            }
            else
            {
                return pre;
            }
        }
        public ListNode Reverse(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode pre = null;
            var cur = head;
            while (cur != null)
            {
                var cur_next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = cur_next;
            }
            return pre;
        }
    }

    public class Solution2
    {

        [Test]
        public void test1()
        {
            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(3);
            ListNode n4 = new ListNode(4);
            ListNode n5 = new ListNode(5);
            ListNode n6 = new ListNode(6);
            ListNode n7 = new ListNode(7);
            ListNode n8 = new ListNode(8);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = n6;
            n6.next = n7;
            n7.next = n8;

            ListNode cur = ReverseKGroup(n1, 3);
            while (cur != null)
            {
                Console.WriteLine(cur.val);
                cur = cur.next;
            }

            Assert.AreEqual(4, 4);
        }

        public ListNode SimpleReverseTest(ListNode head)
        {
            if (head == null) return null;
            var cur = head.next;
            head.next = null;
            while (cur != null)
            {
                var temp = cur.next;
                cur.next = head;
                head = cur;
                cur = temp;
            }
            return head;
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || head.next == null) return head;
            var dummy = new ListNode();
            ListNode tail = dummy;
            ListNode cur = head;
            while (cur != null)
            {
                var res = ReverseK(cur, k);
                tail.next = res[0];
                tail = res[1];
                cur = res[2];
            }

            return dummy.next;
        }

        public ListNode[] ReverseK(ListNode head, int k)
        {
            if (head == null || head.next == null) return new ListNode[] { head, null, null };

            ListNode temp= head.next;
            int count = 1;


            ListNode cur = head.next;
            ListNode tail = head;
            head.next = null;
            count = 1;
            while (cur != null && count < k)
            {
                count++;
                temp = cur.next;
                cur.next = head;
                head = cur;
                cur = temp;
            }

            // roll back the revers if the count is less than k
            if (count < k)
            {
                tail = null;
                cur = head.next;
                head.next = null;
                while(cur != null)
                {
                    temp = cur.next;
                    cur.next = head;
                    head = cur;
                    cur = temp;
                }
            }

            return new ListNode[] { head, tail, cur }; // head, tail, nextHead
        }


    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
        public ListNode() { }
    }


}