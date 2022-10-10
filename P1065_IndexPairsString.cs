using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    internal class P1065_IndexPairsString
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children;
            public bool IsWord;
        }

        public TrieNode BuildTrie(string[] words)
        {
            if (words == null || words.Length == 0) return null;
            var root = new TrieNode();
            foreach (var word in words)
            {
                var current = root;
                foreach (char ch in word)
                {
                    current.Children ??= new Dictionary<char, TrieNode>();
                    current.Children[ch] = current.Children.GetValueOrDefault(ch, new TrieNode());
                    current = current.Children[ch];
                }
                current.IsWord = true;
            }
            return root;
        }

        public int[][] IndexPairs(string text, string[] words)
        {
            var list = new List<int[]>();
            var root = BuildTrie(words);
            for (int i = 0; i < text.Length; i++)
            {
                var current = root;
                for (int j = i; j < text.Length && current != null; j++)
                {
                    current = current.Children?.GetValueOrDefault(text[j], null);
                    if (current != null && current.IsWord)
                    {
                        list.Add(new[] { i, j });
                    }
                }
            }
            return list.ToArray();
        }
    }
}
