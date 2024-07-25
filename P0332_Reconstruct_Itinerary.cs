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
            var origToDest = new Dictionary<string, PriorityQueue<string, string>>();
            foreach (var ticket in tickets)
            {
                origToDest[ticket[0]] = origToDest.GetValueOrDefault(ticket[0], new PriorityQueue<string, string>());
                origToDest[ticket[0]].Enqueue(ticket[1], ticket[1]);
            }
            var res = new Stack<string>();
            Dfs("JFK", origToDest, res);
            return res.ToList();
        }
        void Dfs(string orig, Dictionary<string, PriorityQueue<string, string>> origToDest, Stack<string> res)
        {
            while (origToDest.ContainsKey(orig) && origToDest[orig].Count > 0)
            {
                Dfs(origToDest[orig].Dequeue(), origToDest, res);
            }
            res.Push(orig);
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
}
