using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0381_InsertDeleteGetRandom
    {
        public class RandomizedCollection
        {
            public List<int> list = new();
            public Dictionary<int, HashSet<int>> map = new();
            public RandomizedCollection() { }

            public bool Insert(int val)
            {
                bool res = false;
                list.Add(val);
                if (!map.ContainsKey(val))
                {
                    res = true;
                    map[val] = new HashSet<int>();

                }
                map[val].Add(list.Count - 1);
                return res;
            }

            public bool Remove(int val)
            {
                bool res = false;
                if (map.ContainsKey(val))
                {
                    // update result
                    res = true;

                    // find first index
                    int index = -1;
                    foreach (var i in map[val])
                    {
                        index = i;
                        break;
                    }

                    // remove the index from the HashSet, 
                    // and remove the map entry for val if the hashset is empty
                    map[val].Remove(index);
                    if (map[val].Count == 0) map.Remove(val);

                    // move the list tail to the index location
                    // replace the hashset item list.Count-1 with index
                    if (index != list.Count - 1)
                    {
                        list[index] = list[list.Count - 1]; ;
                        map[list[index]].Remove(list.Count - 1);
                        map[list[index]].Add(index);
                    }

                    // Remove the tail from list
                    list.RemoveAt(list.Count - 1);
                }
                return res;
            }

            public int GetRandom()
            {
                return list[new Random().Next(list.Count)];
            }
        }
    }
}
