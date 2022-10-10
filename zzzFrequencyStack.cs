using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTests
{
    internal class zzzFrequencyStack
    {
    }

    class FreqStack0
    {
        Dictionary<int, int> freq;
        Dictionary<int, Stack<int>> group;
        int maxfreq;

        public FreqStack0()
        {
            freq = new Dictionary<int, int>();
            group = new Dictionary<int, Stack<int>>();
            maxfreq = 0;
        }

        public void push(int x)
        {
            int f = 1;
            if (!freq.ContainsKey(x))
            {
                f = ++freq[x];
            }
            else
            {
                freq.Add(x, 1);
                f = 1;
            }
            if (f > maxfreq)
                maxfreq = f;

            if (!group.ContainsKey(f))
            {
                group.Add(f, new Stack<int>());
            }
            group[f].Push(x);
        }

        public int pop()
        {
            int x = group[maxfreq].Pop();
            freq[x]--;
            if (group[maxfreq].Count == 0)
                maxfreq--;
            return x;
        }
    }

    class FreqStack3
    {
        Dictionary<int, int> valFreq;
        Dictionary<int, Stack<int>> freqStackMap;
        int maxfreq;
        public FreqStack3()
        {
            valFreq = new Dictionary<int, int>();
            freqStackMap = new Dictionary<int, Stack<int>>();
            maxfreq = 0;
        }
        public void Push(int x)
        {
            int f = 1;
            if (valFreq.ContainsKey(x))
            {
                f = ++valFreq[x];
            }
            else
            {
                valFreq.Add(x, 1);
                f = 1;
            }
            if (f > maxfreq)
                maxfreq = f;

            if (!freqStackMap.ContainsKey(f))
            {
                freqStackMap.Add(f, new Stack<int>());
            }
            freqStackMap[f].Push(x);
        }

        public int Pop()
        {
            int x = freqStackMap[maxfreq].Pop();
            valFreq[x]--;
            if (freqStackMap[maxfreq].Count == 0)
                maxfreq--;
            return x;
        }
    }

    public class FreqStack2
    {
        private int index = 0;
        private IDictionary<int, IList<int>> dict = new Dictionary<int, IList<int>>();
        public void Push(int element)
        {
            if (!dict.ContainsKey(element)) dict.Add(element, new List<int>());
            dict[element].Add(++index);
        }
        public int Pop()
        {
            int max = 0;
            int maxIndex = 0;
            int key = 0;
            foreach (var pair in dict)
            {
                if (pair.Value.Count > max)
                {
                    max = pair.Value.Count;
                    maxIndex = pair.Value[max - 1];
                    key = pair.Key;
                }
                else if (pair.Value.Count == max)
                {
                    if (pair.Value[pair.Value.Count - 1] > maxIndex)
                    {
                        maxIndex = pair.Value[pair.Value.Count - 1];
                        key = pair.Key;
                    }
                }
            }
            dict[key].RemoveAt(dict[key].Count - 1);
            if (dict[key].Count == 0)
            {
                dict.Remove(key);
            }
            return key;
        }
    }

    public class FrequencyStackTests
    {
        [Test]
        public void Test1()
        {
            var freq = new FreqStack2();
            freq.Push(1);
            Assert.AreEqual(1, freq.Pop());
        }
        [Test]
        public void Test2()
        {
            var freq = new FreqStack2();
            freq.Push(1);
            freq.Push(1);
            freq.Push(2);
            freq.Push(1);
            freq.Push(2);
            freq.Push(3);
            freq.Push(1);
            Assert.AreEqual(1, freq.Pop());
            Assert.AreEqual(1, freq.Pop());
            Assert.AreEqual(2, freq.Pop());
            Assert.AreEqual(1, freq.Pop());
            Assert.AreEqual(3, freq.Pop());
            Assert.AreEqual(2, freq.Pop());
            Assert.AreEqual(1, freq.Pop());
        }
    }
}
