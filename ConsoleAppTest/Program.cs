public class LFUCache
{
    Dictionary<int, Node> _keyToNode;
    Dictionary<int, LinkedList<Node>> _freqToDll;
    int _capacity = 0;
    int _minFreq = 0;

    public LFUCache(int capacity)
    {
        _keyToNode = new Dictionary<int, Node>();
        _freqToDll = new Dictionary<int, LinkedList<Node>>();
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
                var firstNode = minFreqDll.First();
                minFreqDll.RemoveFirst();
                if (minFreqDll.Count == 0)
                {
                    _freqToDll.Remove(_minFreq);
                }
                _keyToNode.Remove(firstNode.Key);
            }
            var newNode = new Node(key, value, 1);
            _freqToDll[1] = new LinkedList<Node>();
            _freqToDll[1].AddLast(newNode);
            _keyToNode[key] = newNode;
            _minFreq = 1;
        }
    }


    void IncreaseFreq(int key)
    {
        var n = _keyToNode[key];
        _freqToDll[n.Freq].Remove(n);
        if (_freqToDll[n.Freq].Count == 0)
        {
            _freqToDll.Remove(n.Freq);
            if (n.Freq == _minFreq)
            {
                _minFreq++;
            }
        }
        _freqToDll[n.Freq + 1] = _freqToDll.GetValueOrDefault(n.Freq + 1, new LinkedList<Node>);
        _freqToDll[n.Freq + 1].AddLast(n);
        n.Freq++;
    }
}

public class Node
{
    public int Freq;
    public int Key;
    public int Val;
    public Node() { }
    public Node(int key, int val, int freq) { Key = key; Val = val; Freq = freq; }
}
