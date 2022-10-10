using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0021_MergeTwoortedLists
    {
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

        public class Solution
        {
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                var l1 = list1;
                var l2 = list2;
                //first node is cardinal node
                ListNode l = new ListNode();
                ListNode head = l;
                while (l1 != null && l2 != null)
                {
                    if (l1.val < l2.val)
                    {
                        l.next = l1;
                        l1 = l1.next;
                    }
                    else
                    {
                        l.next = l2;
                        l2 = l2.next;
                    }
                    l = l.next;
                }
                if (l1 != null)
                {
                    l.next = l1;
                }
                if (l2 != null)
                {
                    l.next = l2;
                }
                return head.next;
            }
        }
    }
}
