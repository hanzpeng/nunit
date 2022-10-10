using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0332_Reconstruct_Itinerary_UsingList
    {
        void Test(string[] args)
        {
            List<IList<string>> tickets = new();
            tickets.Add(new List<string> { "MUC", "LHR" });
            tickets.Add(new List<string> { "JFK", "MUC" });
            tickets.Add(new List<string> { "SFO", "SJC" });
            tickets.Add(new List<string> { "LHR", "SFO" });

            var res = FindItinerary(tickets);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var g = new Dictionary<string, List<string>>();
            foreach (var ticket in tickets)
            {
                g[ticket[0]] = g.GetValueOrDefault(ticket[0], new List<string>());
                g[ticket[0]].Add(ticket[1]);
            }

            foreach (var val in g.Values)
            {
                val.Sort();
            }

            Stack<string> res = new();
            Dfs("JFK", g, res);
            return res.ToList();
        }

        void Dfs(string origin, Dictionary<string, List<string>> g, Stack<string> res)
        {
            while (g.ContainsKey(origin) && g[origin].Count > 0)
            {
                string dest = g[origin][0];
                g[origin].RemoveAt(0);
                Dfs(dest, g, res);
            }
            res.Push(origin);
        }
    }

    internal class P0332_Reconstruct_Itinerary
    {
        void Test(string[] args)
        {
            List<IList<string>> tickets = new();
            tickets.Add(new List<string> { "MUC", "LHR" });
            tickets.Add(new List<string> { "JFK", "MUC" });
            tickets.Add(new List<string> { "SFO", "SJC" });
            tickets.Add(new List<string> { "LHR", "SFO" });

            var res = FindItinerary(tickets);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var g = new Dictionary<string, PriorityQueue<string, string>>();
            foreach (var ticket in tickets)
            {
                g[ticket[0]] = g.GetValueOrDefault(ticket[0], new PriorityQueue<string, string>());
                g[ticket[0]].Enqueue(ticket[1], ticket[1]);
            }
            Stack<string> itinerary = new();
            Dfs("JFK", g, itinerary);
            return itinerary.ToList();
        }

        void Dfs(string origin, Dictionary<string, PriorityQueue<string, string>> g, Stack<string> itinerary)
        {
            while (g.ContainsKey(origin) && g[origin].Count > 0)
            {
                string dest = g[origin].Dequeue();
                Dfs(dest, g, itinerary);
            }
            itinerary.Push(origin);
        }
    }
}
