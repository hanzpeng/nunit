public class LFUCache
{
    Dictionary<int, Node> _keyToNode;
    Dictionary<int, LinkedList<Node>> _freqToList;
    int _capacity = 0;
    int _minFreq = 0;

    public LFUCache(int capacity)
    {
        _keyToNode = new Dictionary<int, Node>();
        _freqToList = new Dictionary<int, LinkedList<Node>>();
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
                var minFreqList = _freqToList[_minFreq];
                var firstNode = minFreqList.First();
                minFreqList.RemoveFirst();
                if (minFreqList.Count == 0)
                {
                    _freqToList.Remove(_minFreq);
                }
                _keyToNode.Remove(firstNode.Key);
            }
            var newNode = new Node(key, value, 1);
            _freqToList[1] = new LinkedList<Node>();
            _freqToList[1].AddLast(newNode);
            _keyToNode[key] = newNode;
            _minFreq = 1;
        }
    }


    void IncreaseFreq(int key)
    {
        var n = _keyToNode[key];
        _freqToList[n.Freq].Remove(n);
        if (_freqToList[n.Freq].Count == 0)
        {
            _freqToList.Remove(n.Freq);
            if (n.Freq == _minFreq)
            {
                _minFreq++;
            }
        }
        _freqToList[n.Freq + 1] = _freqToList.GetValueOrDefault(n.Freq + 1, new LinkedList<Node>());
        _freqToList[n.Freq + 1].AddLast(n);
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