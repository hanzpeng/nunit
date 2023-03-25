using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P1166
    {
        public class FileSystem
        {
            public class TrieNode
            {
                public Dictionary<string, TrieNode> Children;
                public int value;
                public TrieNode(int val)
                {
                    Children = new Dictionary<string, TrieNode>();
                    this.value = val;
                }
            }

            TrieNode trie;
            public FileSystem()
            {
                trie = new TrieNode(-1);
            }
            public bool CreatePath(string path, int value)
            {
                if (string.IsNullOrEmpty(path))
                {
                    return false;
                }
                path = path.Trim();
                var sections = path.Split('/');
                var node = trie;
                for (int i = 1; i < sections.Length - 1; i++)
                {
                    var section = sections[i];
                    if (node.Children.ContainsKey(section))
                    {
                        node = node.Children[section];
                    }
                    else
                    {
                        return false;
                    }
                }
                var lastSec = sections[sections.Length - 1];
                if (node.Children.ContainsKey(lastSec))
                {
                    return false;
                }
                else
                {
                    node.Children[lastSec] = new TrieNode(value);
                    return true;
                }
            }
            public int Get(string path)
            {
                if (string.IsNullOrEmpty(path))
                {
                    return -1;
                }
                path = path.Trim();
                var sections = path.Split('/');
                var node = trie;
                for (int i = 1; i < sections.Length; i++)
                {
                    var section = sections[i];
                    if (node.Children.ContainsKey(section))
                    {
                        node = node.Children[section];
                    }
                    else
                    {
                        return -1;
                    }
                }
                return node.value;
            }
        }

        /**
         * Your FileSystem object will be instantiated and called as such:
         * FileSystem obj = new FileSystem();
         * bool param_1 = obj.CreatePath(path,value);
         * int param_2 = obj.Get(path);
         */
    }
}
