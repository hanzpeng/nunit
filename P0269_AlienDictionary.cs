using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
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
