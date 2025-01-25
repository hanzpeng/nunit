using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace P0336_Palindrome_Pairs_Trie {

    class P0336_Palindrome_Pairs_Trie {
        [Test]
        public void Test() {
            var prog = new P0336_Palindrome_Pairs_Trie();
            IList<IList<int>> res;
            Console.WriteLine("___________________");
            res = prog.PalindromePairs(new string[] { "abcd", "dcba", "lls", "s", "sssll" });
            foreach (var pair in res) {
                Console.WriteLine(pair[0] + "," + pair[1]);
            }

            Console.WriteLine("___________________");
            res = prog.PalindromePairs(new string[] { "bat", "tab", "cat" });
            foreach (var pair in res) {
                Console.WriteLine(pair[0] + "," + pair[1]);
            }
            Console.WriteLine("___________________");
            res = prog.PalindromePairs(new string[] { "a", "" });
            foreach (var pair in res) {
                Console.WriteLine(pair[0] + "," + pair[1]);
            }
            Console.WriteLine("___________________");
            res = prog.PalindromePairs(new string[] { "a", "ba", "bba" });
            foreach (var pair in res) {
                Console.WriteLine(pair[0] + "," + pair[1]);
            }
            Console.WriteLine("___________________");
            res = prog.PalindromePairs(new string[] { "a", "b", "c", "ab", "ac", "aa" });
            foreach (var pair in res) {
                Console.WriteLine(pair[0] + "," + pair[1]);
            }
        }
        public IList<IList<int>> PalindromePairs(string[] words) {
            List<IList<int>> res = new();
            TrieNode g1 = new();
            TrieNode g2 = new();
            for (int k = 0; k < words.Length; k++) {
                var w = words[k];
                g1.Add(w, k);
                g2.Add(new string(w.Reverse().ToArray()), k);
            }

            for (int k = 0; k < words.Length; k++) {
                var w = words[k];
                var suffix2 = g2.GetSuffixesForWord(w);
                foreach (var tup in suffix2) {
                    if (k != tup.Item2 && IsPalin(tup.Item1)) {
                        res.Add(new List<int> { k, tup.Item2 });
                    }
                }

                var wr = new string(w.Reverse().ToArray());
                var suffix1 = g1.GetSuffixesForWord(wr);
                foreach (var tup in suffix1) {
                    if (k != tup.Item2 && IsPalin(tup.Item1) && w.Length < words[tup.Item2].Length) {
                        res.Add(new List<int> { tup.Item2, k });
                    }
                }
            }
            return res;
        }

        public class TrieNode {
            public Dictionary<char, TrieNode> Children = new();
            public int Index = -1;
            public void Add(string w, int index) {
                if (w == null && w.Length == 0) return;
                var n = this;
                foreach (char c in w) {
                    n.Children[c] = n.Children.GetValueOrDefault(c, new TrieNode());
                    n = n.Children[c];
                }
                n.Index = index;
            }

            public TrieNode GetNode(string w) {
                if (w == null) return null;
                if (w == "") return this;
                var n = this;
                foreach (char c in w) {
                    if (!n.Children.ContainsKey(c)) return null;
                    n = n.Children[c];
                }
                return n;
            }

            public List<(string, int)> GetSuffixesForWord(string w) {
                List<(string, int)> res = new();
                var n = GetNode(w);
                if (n != null) {
                    n.GetAllWords("", res);
                }
                return res;
            }

            public void GetAllWords(string pre, List<(string, int)> res) {
                if (Index >= 0) {
                    res.Add((pre, Index));
                }
                foreach (var child in Children) {
                    child.Value.GetAllWords(pre + child.Key, res);
                }
            }
        }

        public bool IsPalin(string word) {
            int l = 0;
            int r = word.Length - 1;
            while (l < r) {
                if (word[l++] != word[r--]) return false;
            }
            return true;
        }
    }
    internal class P0336_Palindrome_Pairs {
        public void Test() {
            var prog = new P0336_Palindrome_Pairs();
            var res = prog.PalindromePairs(new string[] { "abcd", "dcba", "lls", "s", "sssll" });
            foreach (var pair in res) {
                Console.WriteLine(pair[0] + "," + pair[1]);
            }

            Console.WriteLine("___________________");
            res = prog.PalindromePairs(new string[] { "bat", "tab", "cat" });
            foreach (var pair in res) {
                Console.WriteLine(pair[0] + "," + pair[1]);
            }
            Console.WriteLine("___________________");
            res = prog.PalindromePairs(new string[] { "a", "" });
            foreach (var pair in res) {
                Console.WriteLine(pair[0] + "," + pair[1]);
            }
        }

        public IList<IList<int>> PalindromePairs(string[] words) {
            bool[,] visited = new bool[words.Length * 2, words.Length * 2];
            Dictionary<string, IList<int>> res = new();
            List<(string, int)> list = new();

            for (int k = 0; k < words.Length; k++) {
                list.Add((words[k], k + 1));
                var str = new string(words[k].Reverse().ToArray());
                list.Add((str, -(k + 1)));

            }
            list.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            Dp(0, 1, list, res, words, visited);
            return res.Values.ToList();
        }

        public void Dp(int i, int j, List<(string, int)> list, Dictionary<string, IList<int>> res, string[] words, bool[,] visited) {
            if (i == list.Count || j == list.Count) return;
            if (visited[i, j]) return;
            visited[i, j] = true;
            if (i >= j) {
                Dp(i, i + 1, list, res, words, visited);
                return;
            }

            var i1 = list[i].Item2;
            var i2 = list[j].Item2;
            if (i1 == -i2 || i1 * i2 > 0) {
                Dp(i, j + 1, list, res, words, visited);
                Dp(i + 1, j, list, res, words, visited);
                return;
            }
            var w1 = list[i].Item1;
            var w2 = list[j].Item1;
            if (!w2.StartsWith(w1)) {
                Dp(i + 1, i + 2, list, res, words, visited);
                return;
            } else {
                // w2.StartsWith(w1)
                if (i1 > 0) {
                    i1 = Math.Abs(i1) - 1;
                    i2 = Math.Abs(i2) - 1;
                } else {
                    var iTemp = Math.Abs(i1) - 1;
                    i1 = Math.Abs(i2) - 1;
                    i2 = iTemp;
                }

                if (IsPalin(words[i1], words[i2])) {
                    List<int> item = new();
                    item.Add(i1);
                    item.Add(i2);
                    res["" + i1 + ',' + i2] = item;
                }
                Dp(i, j + 1, list, res, words, visited);
                Dp(i + 1, j, list, res, words, visited);
            }
        }
        public bool IsPalin(string st1, string st2) {
            var word = st1 + st2;
            int l = 0;
            int r = word.Length - 1;
            while (l < r) {
                if (word[l++] != word[r--]) return false;
            }
            return true;
        }
    }
}
