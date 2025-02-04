using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0017_PhoneNumber
    {
        public class Solution {
            public IList<string> LetterCombinations(string digits) {
                List<string> res = new();
                if (string.IsNullOrEmpty(digits)) return res;
                char[][] map = [    [],
                                    [],
                                    ['a','b','c'],
                                    ['d','e','f'],
                                    ['g','h','i'],
                                    ['j','k','l'],
                                    ['m','n','o'],
                                    ['p','q','r','s'],
                                    ['t','u','v'],
                                    ['w','x','y','z']
                                ];
                Dfs(map, digits, 0, res, new List<char>());
                return res;

            }
            void Dfs(char[][] map, string digits, int index, List<string> res, List<char> charList) {
                if (index == digits.Length) {
                    res.Add(new String(charList.ToArray()));
                    return;
                }
                foreach (var c in map[(int)(digits[index] - '0')]) {
                    charList.Add(c);
                    Dfs(map, digits, index + 1, res, charList);
                    charList.RemoveAt(charList.Count - 1);
                }
            }
        }

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> res = new List<string>();
            if (digits == null || digits.Length == 0) return res;
            var map = new string[][]
            {
                [],
                [],
                ["a","b","c"],
                ["d","e","f"],
                ["g","h","i"],
                ["j","k","l"],
                ["m","n","o"],
                ["p","q","r","s"],
                ["t","u","v"],
                ["w","x","y","z"]
            };

            foreach(var c in map[digits[0] - '0']){
                res.Add(c);
            }

            for(int i=1; i<digits.Length; i++)
            {
                int d = digits[i] - '0';
                var newRes = new List<string>();
                foreach (var str in res)
                {
                    foreach(var c in map[d])
                    {
                        newRes.Add(str + c);
                    }
                }
                res = newRes;
            }

            return res;
        }
    }
}
