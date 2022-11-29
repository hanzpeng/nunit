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
                foreach (IList<string> account in accounts)
                {
                    if (!nameAccounts.ContainsKey(account[0]))
                    {
                        nameAccounts.Add(account[0], new List<IList<string>>());
                    }
                    nameAccounts[account[0]].Add(account);
                }

                var res = new List<IList<string>>();
                foreach (List<IList<string>> sameNameAccounts in nameAccounts.Values)
                {
                    res.AddRange(AccountsMergeWithSameName(sameNameAccounts));
                }
                return res;
            }
            public List<IList<string>> AccountsMergeWithSameName(List<IList<string>> sameNameAccounts)
            {
                var name = sameNameAccounts[0][0];
                //remvoe name, which is the first element in each list
                foreach (var account in sameNameAccounts)
                {
                    account.RemoveAt(0);
                }
                var res = new List<IList<string>>();
                var ids = new int[sameNameAccounts.Count];
                for (int i = 0; i < sameNameAccounts.Count; i++)
                {
                    ids[i] = i;
                }
                for (int i = 0; i < sameNameAccounts.Count - 1; i++)
                {
                    for (int j = i + 1; j < sameNameAccounts.Count; j++)
                    {
                        if (sameNameAccounts[i].Where(email => sameNameAccounts[j].Contains(email)).Any())
                        {
                            Union(i, j, ids);
                        }
                    }
                }
                var rootIdEmails = new Dictionary<int, List<string>>();
                for (int i = 0; i < sameNameAccounts.Count; i++)
                {
                    var rootId = Find(i, ids);
                    if (!rootIdEmails.ContainsKey(rootId))
                    {
                        rootIdEmails.Add(rootId, new List<string>());
                    }
                    rootIdEmails[rootId].AddRange(sameNameAccounts[i]);
                }

                foreach (var values in rootIdEmails.Values)
                {
                    var emails = new HashSet<string>(values);
                    var emailsList = emails.ToList();
                    //c# uses UTF-16 to sort characters. switch to ASCII order. otherwise the testing case like '..._...' and '...0...' will fail.
                    emailsList.Sort(StringComparer.Ordinal);
                    emailsList.Insert(0, name);
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
