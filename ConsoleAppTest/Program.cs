
var strComparer = Comparer<StringMap>.Create((m1, m2) => m1.S1.CompareTo(m2.S1));
var pq = new PriorityQueue<StringMap, StringMap>(strComparer);

struct StringMap
{
    public string S1;
    public string S2;
}
