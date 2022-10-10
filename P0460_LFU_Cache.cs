using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0460_LFU_Cache
    {
        public class LFUCache
        {
            public class Node
            {
                public int key;
                public int val;
                public int freq;
                public Node next;
                public Node prev;
                public Node(int key, int val, int freq)
                {
                    this.key = key;
                    this.val = val;
                    this.freq = freq;
                }
                public Node() { }
            }

            public class DLL
            {
                Node head = new();
                Node tail = new();
                public DLL()
                {
                    this.head.next = tail;
                    this.tail.prev = head;
                }
                public bool IsEmpty()
                {
                    return head.next == tail;
                }
                public void Enqueue(Node curr)
                {
                    curr.prev = tail.prev;
                    curr.next = tail;
                    tail.prev.next = curr;
                    tail.prev = curr;
                }

                public Node Remove(Node curr)
                {
                    curr.prev.next = curr.next;
                    curr.next.prev = curr.prev;
                    return curr;
                }

                public Node Dequeue()
                {
                    if (head.next == tail) return null;
                    return Remove(head.next);
                }
            }

            private int capacity;
            private Dictionary<int, DLL> freqMap;
            private Dictionary<int, Node> keyMap;
            private int minFreq = 0;

            public LFUCache(int capacity)
            {
                this.capacity = capacity;
                this.freqMap = new();
                this.keyMap = new();
            }

            public void IncreaseFreq(Node curr)
            {
                freqMap[curr.freq].Remove(curr);
                if (freqMap[curr.freq].IsEmpty())
                {
                    freqMap.Remove(curr.freq);
                    if (curr.freq == minFreq) minFreq++;
                }
                curr.freq++;
                freqMap[curr.freq] = freqMap.GetValueOrDefault(curr.freq, new DLL());
                freqMap[curr.freq].Enqueue(curr);
            }

            public int Get(int key)
            {
                if (keyMap.ContainsKey(key))
                {
                    IncreaseFreq(keyMap[key]);
                    return keyMap[key].val;
                }
                return -1;
            }

            public void Put(int key, int val)
            {
                if (capacity == 0) return;
                if (keyMap.ContainsKey(key))
                {
                    keyMap[key].val = val;
                    IncreaseFreq(keyMap[key]);
                }
                else
                {
                    if (keyMap.Count == capacity)
                    {
                        keyMap.Remove(freqMap[minFreq].Dequeue().key);
                        if (freqMap[minFreq].IsEmpty()) freqMap.Remove(minFreq);
                    }
                    minFreq = 1;
                    keyMap[key] = new Node(key, val, 1);
                    freqMap[1] = freqMap.GetValueOrDefault(1, new DLL());
                    freqMap[1].Enqueue(keyMap[key]);
                }
            }
        }
    }
}
