using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P0126_WordLadder2
    {
        class Node
        {
            public string word;
            public Node parent;
            public Node(string w, Node p)
            {
                this.word = w;
                this.parent = p;
            }
        }

        readonly Dictionary<string, List<string>> g = new();
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            List<IList<string>> res = new();
            g.Add(beginWord, new List<string>());
            SetNeighbors(beginWord, wordList);
            foreach (var u in wordList)
            {
                if (u == beginWord)
                {
                    continue;
                }
                if (!g.ContainsKey(u))
                {
                    g.Add(u, new List<string>());
                }
                SetNeighbors(u, wordList);
            }

            HashSet<string> visited = new();
            Queue<Node> q = new();
            q.Enqueue(new Node(beginWord, null));
            while (q.Count > 0)
            {
                bool found = false;
                HashSet<string> levelVisited = new();
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    var p = q.Dequeue();
                    foreach (var v in g[p.word])
                    {
                        if (v == endWord)
                        {
                            found = true;
                            var stack = new Stack<string>();
                            stack.Push(v);
                            stack.Push(p.word);
                            var pp = p;
                            while (pp.parent != null)
                            {
                                pp = pp.parent;
                                stack.Push(pp.word);
                            };
                            var list = new List<string>(stack);
                            res.Add(list);
                        }
                        else if (!visited.Contains(v))
                        {
                            q.Enqueue(new Node(v, p));
                            levelVisited.Add(v);
                        }
                    }
                }
                if (found) break;
                visited.UnionWith(levelVisited);
            }
            return res;
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
                    if (count >= 2)
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
