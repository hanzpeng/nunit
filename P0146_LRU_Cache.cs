using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0146_LRU_Cache
    {
        class Program
        {
            //static void Main(string[] args)
            //{
            //    var p = new LRUCache(2);
            //    p.Put(1, 1);
            //    Console.WriteLine(p.Get(1));
            //    p.Put(2, 2);
            //    Console.WriteLine(p.Get(1));
            //}

        }

        public class LRUCache
        {
            public class LinkedListNode
            {
                public int Key;
                public int Val;
                public LinkedListNode Prev;
                public LinkedListNode Next;
                public LinkedListNode(int key, int val)
                {
                    this.Key = key;
                    this.Val = val;
                }
            }
            private int Capacity;
            private Dictionary<int, LinkedListNode> Map;
            LinkedListNode Head;
            LinkedListNode Tail;

            public LRUCache(int capacity)
            {
                this.Capacity = capacity;
                this.Map = new();
                this.Head = new LinkedListNode(-1, -1);
                this.Tail = new LinkedListNode(-1, -1);
                Head.Next = Tail;
                Tail.Prev = Head;
            }

            public int Get(int key)
            {
                if (Map.ContainsKey(key))
                {
                    Remove(Map[key]);
                    AddBeforeTail(Map[key]);
                    return Map[key].Val;
                }
                return -1;
            }

            public void Put(int key, int val)
            {
                if (Map.ContainsKey(key))
                {
                    Map[key].Val = val;
                    Remove(Map[key]);
                    AddBeforeTail(Map[key]);
                }
                else
                {
                    if (Map.Count >= Capacity)
                    {
                        Map.Remove(Head.Next.Key);
                        Remove(Head.Next);
                    }
                    Map[key] = new LinkedListNode(key, val);
                    AddBeforeTail(Map[key]);
                }
            }
            void Remove(LinkedListNode curr)
            {
                curr.Prev.Next = curr.Next;
                curr.Next.Prev = curr.Prev;
            }
            void AddBeforeTail(LinkedListNode curr)
            {
                curr.Prev = Tail.Prev;
                curr.Next = Tail;
                Tail.Prev.Next = curr;
                Tail.Prev = curr;
            }
        }
    }
}
