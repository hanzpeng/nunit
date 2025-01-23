using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    public class Solution0269 {
        public string AlienOrder(string[] words) {
            // for each letter, add all the letter before it to a map
            var pre = new Dictionary<char, HashSet<char>>();

            // init HashSet for each letter
            foreach (var word in words) {
                foreach (var c in word.ToCharArray()) {
                    if (!pre.ContainsKey(c)) {
                        pre[c] = new HashSet<char>();
                    }
                }
            }
            // build pre by comparing each adjacent words
            for (int i = 1; i < words.Length; i++) {
                var len = Math.Min(words[i - 1].Length, words[i].Length);
                for (int j = 0; j < len; j++) {
                    if (words[i - 1][j] == words[i][j]) {
                        continue;
                    }
                    if (words[i - 1][j] != words[i][j]) {
                        pre[words[i][j]].Add(words[i - 1][j]);
                        break;
                    }
                }
            }

            // using dfs to do topological order
            var visited = new HashSet<char>();
            var res = new StringBuilder();
            foreach (var c in pre.Keys) {
                if (!visited.Contains(c)) {
                    if (false == Dfs(c, pre, visited, new HashSet<char>(), res)) {
                        return "";
                    }
                }
            }
            return res.ToString();
        }

        public bool Dfs(char c, Dictionary<char, HashSet<char>> pre, HashSet<char> visited, HashSet<char> parent, StringBuilder res) {
            if (parent.Contains(c)) return false;
            parent.Add(c);

            if (visited.Contains(c)) return true;
            visited.Add(c);

            foreach (var cc in pre[c]) {
                if (false == Dfs(cc, pre, visited, parent, res)) {
                    return false;
                }
            }

            res.Append(c);
            return true;
        }
    }
    internal class P0269_AlienDictionary
    {
        public string AlienOrder(string[] words)
        {
            Dictionary<char, HashSet<char>> g = new();
            if (false == BuildGraph(words.ToList(), g))
            {
                return "";
            };
            HashSet<char> visited = new();
            HashSet<char> parents = new();
            Stack<char> stack = new();
            foreach (char c in g.Keys)
            {
                if (!visited.Contains(c))
                {
                    var result = Dfs(c, g, visited, stack, parents);
                    if (result == false) return "";
                }
            }
            string res = "";
            while (stack.Count > 0)
            {
                res += stack.Pop();
            }
            return res;
        }

        bool Dfs(char c, Dictionary<char, HashSet<char>> g, HashSet<char> visited, Stack<char> stack, HashSet<char> parents)
        {
            if (parents.Contains(c))
            {
                return false;
            }
            parents.Add(c);
            foreach (var child in g[c])
            {
                if (!visited.Contains(child))
                {
                    var res = Dfs(child, g, visited, stack, parents);
                    if (res == false) return false;
                }
            }
            stack.Push(c);
            parents.Remove(c);
            visited.Add(c);
            return true;
        }
    public bool BuildGraph(List<string> words, Dictionary<char, HashSet<char>> g)
    {
        char lastChar = ' ';
        Dictionary<char, List<string>> dict = new();

        foreach (string word in words)
        {
            g[word[0]] = g.GetValueOrDefault(word[0], new HashSet<char>());
            if (lastChar != word[0] && lastChar != ' ')
            {
                g[lastChar].Add(word[0]);
            }

            if (word.Length > 1)
            {
                dict[word[0]] = dict.GetValueOrDefault(word[0], new List<string>());
                dict[word[0]].Add(word.Substring(1));
            }
            else if (word.Length == 1 && dict.ContainsKey(word[0]))
            {
                return false;
            }

            lastChar = word[0];
        }
        foreach (var subWords in dict.Values)
        {
            if (false == BuildGraph(subWords, g))
            {
                return false;
            };
        }
        return true;
    }
    }


}
