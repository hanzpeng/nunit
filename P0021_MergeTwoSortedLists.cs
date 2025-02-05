using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0021_MergeTwoSortedLists
    {
        public class Solution {
            public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
                var top = new ListNode();
                var res = top;
                while (list1 != null && list2 != null) {
                    if (list1.val <= list2.val) {
                        res.next = list1;
                        list1 = list1.next;
                    } else {
                        res.next = list2;
                        list2 = list2.next;
                    }
                    res = res.next;
                }
                res.next = list1 ?? list2;
                return top.next;
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

        public class Solution2
        {
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                var l1 = list1;
                var l2 = list2;
                //first node is sentinel node
                ListNode preHead = new ListNode();
                ListNode head = preHead;
                while (l1 != null && l2 != null)
                {
                    if (l1.val < l2.val)
                    {
                        head.next = l1;
                        l1 = l1.next;
                    }
                    else
                    {
                        head.next = l2;
                        l2 = l2.next;
                    }
                    head = head.next;
                }
                if (l1 != null)
                {
                    head.next = l1;
                }
                if (l2 != null)
                {
                    head.next = l2;
                }
                return preHead.next;
            }
        }
    }
}
