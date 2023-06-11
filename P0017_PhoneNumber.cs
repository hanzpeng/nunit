using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0017_PhoneNumber
    {
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> res = new List<string>();
            if (digits == null || digits.Length == 0) return res;
            var map = new string[][]
            {
                new string[]{},
                new string[]{},
                new string[]{"a","b","c"},
                new string[]{"d","e","f"},
                new string[]{"g","h","i"},
                new string[]{"j","k","l"},
                new string[]{"m","n","o"},
                new string[]{"p","q","r","s"},
                new string[]{"t","u","v"},
                new string[]{"w","x","y","z"}
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
