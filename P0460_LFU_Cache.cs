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
            Dictionary<int, Node> _keyToNode;
            Dictionary<int, Dll> _freqToDll;
            int _capacity = 0;
            int _minFreq = 0;

            public LFUCache(int capacity)
            {
                _keyToNode = new Dictionary<int, Node>();
                _freqToDll = new Dictionary<int, Dll>();
                _capacity = capacity;
            }

            public int Get(int key)
            {
                if (_keyToNode.ContainsKey(key))
                {
                    IncreaseFreq(key);
                    return _keyToNode[key].Val;
                }
                else
                {
                    return -1;
                }
            }

            public void Put(int key, int value)
            {
                if (_keyToNode.ContainsKey(key))
                {
                    IncreaseFreq(key);
                    _keyToNode[key].Val = value;
                }
                else
                {
                    if (_keyToNode.Count == _capacity)
                    {
                        // remove least used node
                        var minFreqDll = _freqToDll[_minFreq];
                        var firstNode = minFreqDll.RemoveFirstNode();
                        if (minFreqDll.IsEmpty())
                        {
                            _freqToDll.Remove(_minFreq);
                        }
                        _keyToNode.Remove(firstNode.Key);
                    }
                    var newNode = new Node(key, value, 1);
                    _freqToDll[1] = new Dll();
                    _freqToDll[1].AppendNode(newNode);
                    _keyToNode[key] = newNode;
                    _minFreq = 1;
                }
            }


            void IncreaseFreq(int key)
            {
                var n = _keyToNode[key];
                _freqToDll[n.Freq].RemoveNode(n);
                if (_freqToDll[n.Freq].IsEmpty())
                {
                    _freqToDll.Remove(n.Freq);
                    if (n.Freq == _minFreq)
                    {
                        _minFreq++;
                    }
                }
                _freqToDll[n.Freq + 1] = _freqToDll.GetValueOrDefault(n.Freq + 1, new Dll());
                _freqToDll[n.Freq + 1].AppendNode(n);
                n.Freq++;
            }
        }

        class Node
        {
            public int Freq;
            public int Key;
            public int Val;
            public Node Next;
            public Node Prev;
            public Node() { }
            public Node(int key, int val, int freq) { Key = key; Val = val; Freq = freq; }
        }

        class Dll
        {
            public Node Head = new();
            public Node Tail = new();
            public Dll()
            {
                Head.Next = Tail;
                Tail.Prev = Head;
            }
            public bool IsEmpty() => Head.Next == Tail && Tail.Prev == Head;
            public void AppendNode(Node n)
            {
                n.Prev = Tail.Prev;
                n.Next = Tail;

                Tail.Prev.Next = n;
                Tail.Prev = n;
            }

            public Node RemoveNode(Node n)
            {
                n.Prev.Next = n.Next;
                n.Next.Prev = n.Prev;
                n.Prev = null;
                n.Next = null;
                return n;
            }

            public Node RemoveFirstNode()
            {
                if (IsEmpty())
                {
                    return null;
                }
                return RemoveNode(Head.Next);
            }
        }
    }
}
