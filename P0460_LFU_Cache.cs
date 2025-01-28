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

    internal class P0460_LFU_Cache3_need_more_fix
    {
        public class LFUCache
        {
            Dictionary<int, KV> _keyToNode;
            Dictionary<int, MyLinkedList<KV>> _freqToDll;
            int _capacity = 0;
            int _minFreq = 0;

            public LFUCache(int capacity)
            {
                _keyToNode = new Dictionary<int, KV>();
                _freqToDll = new Dictionary<int, MyLinkedList<KV>>();
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
                    var newNode = new KV(key, value, 1);
                    _freqToDll[1] = new MyLinkedList<KV>();
                    _freqToDll[1].AddLast(newNode);
                    _keyToNode[key] = newNode;
                    _minFreq = 1;
                }
            }


            void IncreaseFreq(int key)
            {
                var n = _keyToNode[key];
                _freqToDll[n.Freq].Remove(n);
                if (_freqToDll[n.Freq].IsEmpty())
                {
                    _freqToDll.Remove(n.Freq);
                    if (n.Freq == _minFreq)
                    {
                        _minFreq++;
                    }
                }
                _freqToDll[n.Freq + 1] = _freqToDll.GetValueOrDefault(n.Freq + 1, new MyLinkedList<KV>());
                _freqToDll[n.Freq + 1].AddLast(n);
                n.Freq++;
            }
        }

        class KV
        {
            public KV(int k, int v, int f)
            {
                Key = k;
                Val = v;
                Freq = f;
            }
            public int Key;
            public int Val;
            public int Freq;
        }

        class Node<T>
        {
            public T Val;
            public Node<T> Next;
            public Node<T> Prev;
            public Node() { }
            public Node(T val) { Val = val; }
        }

        class MyLinkedList<T>
        {
            public Node<T> Head = new();
            public Node<T> Tail = new();
            public MyLinkedList()
            {
                Head.Next = Tail;
                Tail.Prev = Head;
            }
            public bool IsEmpty() => Head.Next == Tail && Tail.Prev == Head;
            public void AddLast(T t)
            {
                var n = new Node<T>(t);
                n.Prev = Tail.Prev;
                n.Next = Tail;

                Tail.Prev.Next = n;
                Tail.Prev = n;
            }

            public T Remove(T t)
            {
                var n = new Node<T>(t);
                var n1 = Remove(n);
                return n1.Val;
            }

            public Node<T> Remove(Node<T> n)
            {
                n.Prev.Next = n.Next;
                n.Next.Prev = n.Prev;
                n.Prev = null;
                n.Next = null;
                return n;
            }

            public T RemoveFirstNode()
            {
                if (IsEmpty())
                {
                    return default(T);
                }
                var n = Remove(Head.Next);
                return n.Val;
            }
        }
    }

    internal class P046_LFU_Cache2
    {
        public class LFUCache {
            Dictionary<int, LinkedListNode<Node>> _keyToNode = new();
            Dictionary<int, LinkedList<Node>> _freqToList = new();
            int _capacity = 0;
            int _minFreq = 0;

            public LFUCache(int capacity) {
                _capacity = capacity;
            }

            public int Get(int key) {
                if (_keyToNode.ContainsKey(key)) {
                    IncreaseFreq(key);
                    return _keyToNode[key].Value.Val;
                } else {
                    return -1;
                }
            }

            public void Put(int key, int value) {
                if (_keyToNode.ContainsKey(key)) {
                    IncreaseFreq(key);
                    _keyToNode[key].Value.Val = value;
                } else {
                    if (_keyToNode.Count == _capacity) {
                        // remove least used node
                        var minFreqList = _freqToList[_minFreq];
                        var firstNode = minFreqList.First;
                        minFreqList.RemoveFirst();
                        if (minFreqList.Count == 0) {
                            _freqToList.Remove(_minFreq);
                        }
                        _keyToNode.Remove(firstNode.Value.Key);
                    }
                    var newNode = new Node(key, value, 1);

                    _freqToList[1] = _freqToList.GetValueOrDefault(1, new LinkedList<Node>());
                    var llNode = _freqToList[1].AddLast(newNode);
                    _keyToNode[key] = llNode;
                    _minFreq = 1;
                }
            }


            void IncreaseFreq(int key) {
                var node = _keyToNode[key];
                var n = node.Value;
                _freqToList[n.Freq].Remove(node);
                if (_freqToList[n.Freq].Count == 0) {
                    _freqToList.Remove(n.Freq);
                    if (n.Freq == _minFreq) {
                        _minFreq++;
                    }
                }
                n.Freq++;
                _freqToList[n.Freq] = _freqToList.GetValueOrDefault(n.Freq, new LinkedList<Node>());
                _keyToNode[key] = _freqToList[n.Freq].AddLast(n);
            }
        }

        public class Node {
            public int Freq;
            public int Key;
            public int Val;
            public Node() { }
            public Node(int key, int val, int freq) { Key = key; Val = val; Freq = freq; }
        }


    }
}
