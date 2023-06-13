using System.Text;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {   
        static void Main(string[] args)
        {

            //////////////////////////////////////////
            /// var pq = new PriorityQueue<TElement, TPrioirty>(Comparer<(TPrioirty)>.Create((x, y) => {x.CompareTo(y);});
            /// 

            Console.WriteLine(3.1415926.ToString("000.00000"));

            var intList = new List<int>(new int[] { 1, 2, 2, 3 });
            var strList = new List<string>(new string[] { "a", "a", "b" });
            var pq = new PriorityQueue<(int I, string S), (int I, string S)>(
                Comparer<(int I, string S)>.Create((x, y) =>
                {
                    if (x.I != y.I) { return x.I - y.I; }
                    return x.S.CompareTo(y.S);
                }));

            foreach (var intVal in intList)
            {
                foreach (var strVal in strList)
                {
                    pq.Enqueue((intVal, strVal), (intVal, strVal));
                }
            }

            while (pq.Count > 0)
            {
                var item = pq.Dequeue();
                Console.WriteLine(item.I + item.S);
            }

            //////////////////////////////////////////

            (string, int)[] pare = { ("one", 1), ("two", 2) };
            foreach (var pa in pare)
            {
                Console.WriteLine(pa.Item1 + " " + pa.Item2);
                if (Math.Ceiling((new Random()).NextDouble()) > -1) return;
            }

            var result = new List<string>(new string[] { "a", "b", "c" });
            Console.WriteLine(String.Join(",", result));
            if (Math.Ceiling((new Random()).NextDouble()) > -1) return;

            // Greatest Common Divisor
            //dividing larger number by the smaller number
            //replacing the larger number with the remainder
            //until the remainder is zero.
            //The last non-zero remainder is the GCD
            int gcd(int a, int b) => b == 0 ? a : gcd(b, a % b);
            Console.WriteLine(gcd(12, 16));


            //list
            var mylist = new List<string>(new string[] { "sherry", "soap" });
            mylist.Insert(1, "peng");
            foreach (var s in mylist) { Console.Write(s + ","); }
            Console.WriteLine();
            mylist.RemoveAt(1);
            mylist.Add("sherry");
            mylist.Remove("sherry");
            foreach (var s in mylist) { Console.Write(s + ","); }
            Console.WriteLine();
            mylist.Insert(0, "zhang");
            foreach (var s in mylist) { Console.Write(s + ","); }
            Console.WriteLine();

            // Stack, clone, reverse
            var stack = new Stack<string>("a b c d".Split(" "));
            var clone = new Stack<string>(stack.Reverse());
            var rev = new Stack<string>(stack);
            Console.WriteLine(clone.Peek());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(rev.Peek());

            Console.WriteLine(stack.Pop());
            stack.Push("e");

            //LinkedList
            var q = new LinkedList<string>("a b c d".Split(" "));
            q.AddFirst("A");
            var first = q.First;
            var second = first?.Next;
            Console.WriteLine(second?.Value);

            Console.WriteLine(q.First());
            Console.WriteLine(q.Last());
            Console.WriteLine();
            q.RemoveFirst();
            Console.WriteLine(q.First());
            Console.WriteLine(q.Last());
            Console.WriteLine();
            q.RemoveLast();
            Console.WriteLine(q.First());
            Console.WriteLine(q.Last());
            Console.WriteLine(q.Count);


            // Queue
            var queue = new Queue<string>("a b c d".Split(" "));
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue("e");
            Console.WriteLine(queue.First());
            Console.WriteLine(queue.Last());

            // HashSet
            var set = new HashSet<string>("a b c d a b c".Split(" "));
            set.Add("a");
            set.Add("b");
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

            // Dictionary GetValueOrDefault
            var strCount = new Dictionary<string, int>();
            strCount["apple"] = strCount.GetValueOrDefault("apple", 0) + 1;
            strCount["apple"] = strCount.GetValueOrDefault("apple", 0) + 1;
            strCount["banana"] = strCount.GetValueOrDefault("banana", 0) + 1;
            if (!strCount.ContainsKey("cherry"))
            {
                strCount["cherry"] = strCount.GetValueOrDefault("cherry", 0) + 1;
            }
            Console.WriteLine(strCount["apple"]);
            Console.WriteLine(strCount["banana"]);
            Console.WriteLine(strCount["cherry"]);
            Console.WriteLine(strCount.Count);
            foreach (var kv in strCount)
            {
                Console.WriteLine(kv.Key + " " + kv.Value);
            }

            // call by out
            GetLastName(out string lastName);
            Console.WriteLine(lastName);

            // call be ref
            string firstName = "";
            SetFirstName(ref firstName);
            Console.WriteLine(firstName);


            // Random
            var r = new Random();
            var randomInteger = r.Next(); // 0 <= randomInt < int.MaxValue;
            var randomDouble = r.NextDouble(); // 0.0 <= yyy < 1.0
            var randomK = r.Next(40); // 0 <= randomK< 40

            // Tuple List
            List<(string, string)> tList = new List<(string, string)>();
            tList.Add(("B", "Banana"));
            tList.Add(("A", "Apple"));
            tList.Add(("C", "Cherry"));

            // Tuple List and PriorityQueue          
            var p = new PriorityQueue<(string, string), string>();
            foreach (var t in tList)
            {
                p.Enqueue(t, t.Item1);
            }
            while (p.Count > 0)
            {
                Console.WriteLine(p.Dequeue().Item2);
            }

            // Tuple List and Sort 
            List<(int, string)> tl = new List<(int, string)>();
            tl.Add((2, "TWo"));
            tl.Add((1, "One"));
            tl.Add((3, "Three"));

            //tl.Sort((t1, t2) => t1.Item1 - t2.Item1);
            tl.Sort((t1, t2) => t1.Item2.CompareTo(t2.Item2));

            foreach (var t in tl)
            {
                Console.WriteLine(t.Item2.ToString());
            }

            //StringBuilder
            var sb = new StringBuilder("Test");
            sb.Append(" Is Fun");
            sb.Replace("Test", "Dve");
            Console.WriteLine(sb.ToString());

            // convert char to int
            int xxx = 'b' - 'a'; //1
            Console.WriteLine(xxx);

            //char
            char.IsDigit('1');
            char.IsLetter('a');
            char.IsLower('a');

            // String.ToCharArray()
            char[] charArray = "abc".ToCharArray();

            // charArray to string
            var str1 = new string("abc".ToCharArray());

            // charArray to list
            var list = ("abc".ToCharArray()).ToList();

            // list to CharArray
            char[] charArray1 = list.ToArray();

            //string Substring
            var zhang = "zhang";
            Console.WriteLine(zhang.Substring(0));
            Console.WriteLine(zhang.Substring(0, 1));

            // pass string by ref
            SetFirstName(ref zhang);
            Console.WriteLine(zhang);

            // int
            Console.WriteLine(int.Parse("12"));
            Console.WriteLine(int.MaxValue);// 2,147,483,647
            Console.WriteLine(int.MinValue);//-2,147,483,648
            Console.WriteLine(int.TryParse("123", out int res) ? res : "not int");
            Console.WriteLine(int.TryParse("123abc", out int res2) ? res : "not int");

            // Math 
            Console.WriteLine(Math.Max(1, 2));
            Console.WriteLine(Math.Min(1, 2));
            Console.WriteLine((int)Math.Pow(10, 3));
            Console.WriteLine(Math.Abs(-12321));
            Console.WriteLine(Math.Ceiling(1.23));
            Console.WriteLine(Math.Floor(1.23));


            // double
            Console.WriteLine(double.MinValue);
            Console.WriteLine(double.MaxValue);
            Console.WriteLine(double.Parse("1.234"));
            Console.WriteLine(double.PositiveInfinity);
            Console.WriteLine(double.NegativeInfinity);

            // twoD Array length
            var board = new int[3, 4];
            Console.WriteLine(board.GetLength(0)); // 3
            Console.WriteLine(board.GetLength(1)); // 4
            Console.WriteLine(board.Length); // 12

            //Array.Sort(nums)
            var nums = new int[] { 2, 1, 4, 3, 5 };
            Console.WriteLine(Array.BinarySearch(nums, 4)); // 2
            Array.Sort(nums);
            Array.Reverse(nums);
            foreach (var i in nums)
            {
                Console.WriteLine(i);
            }

            // OrderBy(i=>i)
            var nums1 = new int[] { 2, 1, 4, 3, 5 };
            nums1 = nums1.OrderBy(i => -i).ToArray();
            foreach (var i in nums1)
            {
                Console.WriteLine(i);
            }

        }

        public static void SetFirstName(ref string str)
        {
            str = "Soap";
        }

        public static void GetLastName(out string str)
        {
            str = "Zhang";
        }
    }
}