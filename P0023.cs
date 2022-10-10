using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace P0023
{
    public class P0023
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1);

            //Input: lists = [[1, 4, 5],[1,3,4],[2,6]]
            //Output: [1,1,2,3,4,4,5,6]
            var list = new ListNode[3];

            {
                ListNode node1 = new ListNode(1);
                ListNode node2 = new ListNode(4);
                ListNode node3 = new ListNode(5);
                node1.next = node2;
                node2.next = node3;
                list[0] = node1;
            };

            {
                ListNode node1 = new ListNode(1);
                ListNode node2 = new ListNode(3);
                ListNode node3 = new ListNode(4);
                node1.next = node2;
                node2.next = node3;
                list[1] = node1;
            };

            {
                ListNode node1 = new ListNode(2);
                ListNode node2 = new ListNode(6);
                ListNode node3 = new ListNode(8);
                node1.next = node2;
                node2.next = node3;
                list[2] = node1;
            };

            MergeKLists(list);
            var expected = new int[] { 1, 1, 2, 3, 4, 4, 5, 6, 8 };

            var next = head;
            int i = 0;
            while(next != null)
            {
                Console.WriteLine(next.val);
                Assert.AreEqual(expected[i++], next.val);
                next = next.next;
            }

        }

        public ListNode head = null;
        public ListNode tail = null;
        public PriorityQueue<(int, ListNode), int> queue = new PriorityQueue<(int, ListNode), int>();

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;


            for (int i = 0; i < lists.Length; i++)
            {
                queue.Enqueue((i, lists[i]), lists[i].val);
            }

            if (queue.Count > 0)
            {
                var first = queue.Dequeue();
                head = new ListNode(first.Item2.val, null);
                tail = head;
                if (first.Item2.next != null)
                {
                    queue.Enqueue((first.Item1, first.Item2.next), first.Item2.next.val);
                }
            }

            while (queue.Count > 0)
            {
                var dequeued = queue.Dequeue();
                tail.next = new ListNode(dequeued.Item2.val, null);
                tail = tail.next;
                if (dequeued.Item2.next != null)
                {
                    queue.Enqueue((dequeued.Item1, dequeued.Item2.next), dequeued.Item2.next.val);
                }
            }

            return head;

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
