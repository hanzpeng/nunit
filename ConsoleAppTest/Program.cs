using System.Collections.Generic;

Console.WriteLine("Hello, World!");
var workers = new int[4][];
var bikes = new int[4][];


Console.WriteLine(new Solution().AssignBikes(workers, bikes));

public class Solution
{
    public int[] AssignBikes(int[][] workers, int[][] bikes)
    {

        PriorityQueue<WBD, WBD> pq = new PriorityQueue<WBD, WBD>(
            Comparer<WBD>.Create(
                                    (x, y) =>
                                            {
                                                if (x.d != y.d) return x.d - y.d;
                                                if (x.w != y.w) return x.w - y.w;
                                                return x.b - y.b;
                                            }
                                 )
            );

        for (int w = 0; w < workers.Length; w++)
        {
            for (int b = 0; b < bikes.Length; b++)
            {
                var d = Math.Abs(workers[w][0] - bikes[b][0]) + Math.Abs(workers[w][1] - bikes[b][1]);
                pq.Enqueue(new(w, b, d), new WBD(w, b, d));
            }
        }
        var res = new Dictionary<int, int>();
        while (pq.Count > 0)
        {
            var item = pq.Dequeue();
            if (!res.ContainsKey(item.w) && !res.ContainsValue(item.b))
            {
                res[item.w] = item.b;
            }
        }

        var result = new int[res.Count];

        foreach (var item in res)
        {
            result[item.Key] = item.Value;
        }
        return result;
    }
    struct WBD
    {
        public WBD(int w, int b, int d)
        {
            this.w = w;
            this.b = b;
            this.d = d;
        }
        public int w;
        public int b;
        public int d;
    }
}