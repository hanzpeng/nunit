using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0127_WordLadder
    {
        readonly Dictionary<string, List<string>> g = new();
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (beginWord == endWord) return 1;
            g.Add(beginWord, new List<string>());
            SetNeighbors(beginWord, wordList);
            foreach (var u in wordList)
            {
                if (!g.ContainsKey(u))
                {
                    g.Add(u, new List<string>());
                }
                SetNeighbors(u, wordList);
            }
            HashSet<string> visited = new();
            Queue<string> q = new();
            q.Enqueue(beginWord);
            visited.Add(beginWord);
            int level = 1;
            while (q.Count > 0)
            {
                level++;
                var count = q.Count;
                for(int i = 0; i < count; i++)
                {
                    var p = q.Dequeue();
                    foreach (var v in g[p])
                    {
                        if (v == endWord)
                        {
                            return level;
                        }
                        if (!visited.Contains(v))
                        {
                            q.Enqueue(v);
                            visited.Add(v);
                        }
                    }
                }
            }
            return 0;
        }

        public void SetNeighbors(string u, IList<string> wordList)
        {
            foreach (var v in wordList)
            {
                int count = 0;
                for (int i = 0; i < u.Length; i++)
                {
                    if (u[i] != v[i])
                    {
                        count++;
                    }
                    if (count == 2)
                    {
                        break;
                    }
                }
                if (count == 1)
                {
                    g[u].Add(v);
                }
            }
        }
    }
}
