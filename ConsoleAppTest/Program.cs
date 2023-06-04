using System.Collections;
using System.Collections.Generic;

var intList = new List<int>(new int[] { 1, 2, 2, 3 });
var strList = new List<string>(new string[] { "a", "a", "b" });
var pq = new PriorityQueue<(int I, string S), (int I, string S)>(
    Comparer<(int I, string S)>.Create((x, y) =>
    {
        if (x.I != y.I) { return x.I - y.I; }
        return x.S.CompareTo(y.S);
    }));

foreach (var intVal in intList)
{
    foreach (var strVal in strList)
    {
        pq.Enqueue((intVal, strVal), (intVal, strVal));
    }
}

while (pq.Count > 0)
{
    var item = pq.Dequeue();
    Console.WriteLine(item.I + item.S);
}

