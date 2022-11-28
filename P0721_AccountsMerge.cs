using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0721_AccountsMerge
    {
        public class Solution
        {
            public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
            {
                var nameAccounts = new Dictionary<string, List<IList<string>>>();
                foreach (var account in accounts)
                {
                    if (!nameAccounts.ContainsKey(account[0]))
                    {
                        nameAccounts.Add(account[0], new List<IList<string>>());
                    }
                    nameAccounts[account[0]].Add(account);
                }

                var res = new List<IList<string>>();
                foreach (var sameNameAccounts in nameAccounts.Values)
                {
                    res.AddRange(AccountsMerge1(sameNameAccounts));
                }
                return res;
            }
            public List<IList<string>> AccountsMerge1(List<IList<string>> sameNameAccounts)
            {
                var res = new List<IList<string>>();
                var edges = new List<int[]>();
                var emailSetArray = new HashSet<string>[sameNameAccounts.Count];
                var ids = new int[sameNameAccounts.Count];
                for (int i = 0; i < sameNameAccounts.Count; i++)
                {
                    ids[i] = i;
                }
                for (int i = 0; i < sameNameAccounts.Count; i++)
                {
                    for (int j = 1; j < sameNameAccounts[i].Count; j++)
                    {
                        emailSetArray[i].Add(sameNameAccounts[i][j]);
                    }
                }
                for (int i = 0; i < emailSetArray.Length - 1; i++)
                {
                    for (int j = 1; j < emailSetArray.Length; j++)
                    {
                        if (emailSetArray[i].Where(email => emailSetArray[j].Contains(email)).Any())
                        {
                            Union(i, j, ids);
                        }
                    }
                }
                var rootIdList = new Dictionary<int, List<int>>();
                foreach (var i in ids)
                {
                    var rootId = Find(i, ids);
                    if (!rootIdList.ContainsKey(rootId))
                    {
                        rootIdList.Add(rootId, new List<int>());
                    }
                    rootIdList[rootId].Add(i);
                }

                foreach (var idList in rootIdList.Values)
                {
                    var emails = new HashSet<string>();
                    foreach (int i in idList)
                    {
                        emails.UnionWith(emailSetArray[i]);
                    }
                    var emailsList = emails.ToList();
                    emailsList.Sort();
                    emailsList.Insert(0, sameNameAccounts[0][0]);
                    res.Add(emailsList);
                }

                return res;
            }

            public void Union(int i, int j, int[] ids)
            {
                var id0 = Find(i, ids);
                var id1 = Find(j, ids);
                if (id0 != id1)
                {
                    ids[id0] = id1;
                }
            }

            public int Find(int i, int[] ids)
            {
                if (ids[i] != i) ids[i] = Find(ids[i], ids);
                return ids[i];
            }
        }
    }

}
