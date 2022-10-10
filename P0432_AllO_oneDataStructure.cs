using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace P0432_AllO_oneDataStructure
{
    internal class P0432_AllO_oneDataStructure
    {
        class Program
        {
            [Test]
            public void Test()
            {
                var p = new AllOne();
                p.Inc("a");//1
                p.Inc("b");//1
                p.Inc("c");//1
                p.Inc("d");//1

                p.Inc("a");//2
                p.Inc("b");//2
                p.Inc("c");//2
                p.Inc("d");//2

                p.Inc("c");//3
                p.Inc("d");//3
                p.Inc("d");//4
                p.Inc("a");//3
                Console.WriteLine(p.GetMinKey());//b
                Console.WriteLine(p.GetMaxKey());//d
            }

        }
        public class AllOne
        {
            private Dictionary<string, LinkedListNode> map;
            private LinkedListNode head;
            private LinkedListNode tail;


            public AllOne()
            {
                this.map = new();
                head = new("", int.MinValue);
                tail = new("", int.MaxValue);
                head.Next = tail;
                tail.Prev = head;
            }
            private void Remove(string key)
            {
                if (map.ContainsKey(key))
                {
                    var node = this.map[key];
                    map.Remove(key);
                    node.Strings.Remove(key);
                    if (node.Strings.Count == 0)
                    {
                        node.Prev.Next = node.Next;
                        node.Next.Prev = node.Prev;
                    }
                }
            }

            private void AddOrInsertAfter(LinkedListNode curr, string key, int val)
            {
                // add to curr.Next
                if (curr.Next.Val == val)
                {
                    curr.Next.Strings.Add(key);
                    map[key] = curr.Next;
                }
                else //Insert newn after curr
                {
                    var newn = new LinkedListNode(key, val);
                    map[key] = newn;

                    newn.Next = curr.Next;
                    curr.Next.Prev = newn;

                    newn.Prev = curr;
                    curr.Next = newn;
                }
            }

            private void AddOrInsertBefore(LinkedListNode curr, string key, int val)
            {
                // add to curr.Prev
                if (curr.Prev.Val == val)
                {
                    curr.Prev.Strings.Add(key);
                    map[key] = curr.Prev;
                }
                else //Insert newn before curr
                {
                    var newn = new LinkedListNode(key, val);
                    map[key] = newn;

                    curr.Prev.Next = newn;
                    newn.Prev = curr.Prev;

                    newn.Next = curr;
                    curr.Prev = newn;
                }
            }

            public void Inc(string key)
            {
                if (!map.ContainsKey(key))
                    AddOrInsertAfter(head, key, 1);
                else //map.ContainsKey(key), insert or add after curr
                {
                    var curr = map[key];
                    Remove(key);
                    var temp = curr.Strings.Count > 0 ? curr : curr.Prev;
                    this.AddOrInsertAfter(temp, key, curr.Val + 1);
                }
            }

            public void Dec(string key)
            {
                if (!map.ContainsKey(key)) return;
                var curr = map[key];
                this.Remove(key);
                if (curr.Val > 1)
                {
                    var temp = curr.Strings.Count > 0 ? curr : curr.Next;
                    this.AddOrInsertBefore(temp, key, curr.Val - 1);
                }
            }

            public string GetMaxKey()
            {
                foreach (var str in tail.Prev.Strings)
                {
                    return str;
                }
                return "";
            }

            public string GetMinKey()
            {
                foreach (var str in head.Next.Strings)
                {
                    return str;
                }
                return "";
            }
        }
        public class LinkedListNode
        {
            public LinkedListNode Next;
            public LinkedListNode Prev;
            public int Val;
            public HashSet<string> Strings = new();
            public LinkedListNode(string str, int val)
            {
                this.Val = val;
                Strings.Add(str);
            }
            public LinkedListNode()
            {

            }
        }
    }
}
