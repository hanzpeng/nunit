﻿using System.Text;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // convert Stack<char> to string

            Stack<char> stackxxx = new Stack<char>();
            stackxxx.Push('a');
            stackxxx.Push('b');
            stackxxx.Push('c');
            var l = new string(stackxxx.Reverse().ToArray());
            Console.WriteLine(l); // abc

            // new a list
            var res11 = new List<int>() { 1, 2, 3, 4, 5 };
            var res22 = new List<int> { 1, 2, 3, 4, 5 };
            var res33 = new List<int>([1, 2, 3, 4, 5]);
            List<int> res4 = [1, 2, 3, 4, 5];

            // reverse a string
            var word = "abc";
            var wr = new string(word.Reverse().ToArray());
            Console.WriteLine(word);
            Console.WriteLine(wr);

            //swap two integer
            var nums = new int[10];
            (nums[1], nums[2]) = (nums[2], nums[1]);

            //string phonePatten10Or7 = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            string pattern10 = @"^\s*(\(([0-9]{3}\))|([0-9]{3}[\s]*[-.]?))(\s*[0-9]{3}\s*)[-.]?(\s*[0-9]{4}\s*)$";
            string pattern7 = @"^(\s*[0-9]{3}\s*)[-.]?(\s*[0-9]{4}\s*)$";
            string pattern3 = @"^\s*[0-9]{3}\s*$";

            var phones = new string[]{
                "1234567890","  123 456 7890  ",
                "123-456-7890","123 - 456  - 7890", "123 - 4567890",// you may add white space before/after -
                "123.456.7890", "123 . 456 . 7890", // you may add white space before/after . 
                "123.456-7890",
                "123-456.7890",
                "(123)456-7890",
                "(123)456.7890",
                "4567890",
                "456-7890 ","456 -  7890 ",
                "456.7890", "456 .  7890",
                "123",
                "123 ",
                " 123 ",
            };
            foreach (var phone in phones)
            {
                var phone1 = Regex.Replace(phone, @"\s+", "");
                Console.WriteLine(phone + " " + Regex.IsMatch(phone, pattern3));
            }

            if (Math.Ceiling((new Random()).NextDouble()) > -1) return;

            //////////////////////////////////////////
            /// convert int[][] to List<List<int>>
            var arrayOfArray = new int[][] { new int[] { 11, 12 }, new int[] { 21, 22 } };

            var listlist = arrayOfArray.Select(x => x.ToList()).ToList();
            var arrayarray = listlist.Select(x => x.ToArray()).ToArray();


            //new int[][] arrayOfArray = { new int[] { 11, 12 }, new int[] { 21, 22 } };
            List<List<int>> listOfList = arrayOfArray.ToList().Select(x => new List<int>(x)).ToList();
            listOfList.ForEach(li => Console.Write($"({li[0]}, {li[1]}), "));
            Console.WriteLine();

            /// convert List<List<int>> to int[][]
            int[][] arrayOfArray1 = listOfList.Select(li => li.ToArray()).ToArray();


            if (Math.Ceiling((new Random()).NextDouble()) > -1) return;

            //////////////////////////////////////////
            /// sort with customer Comparer
            var sortTuple = new List<(int, int)>(new (int, int)[] { (3, 3), (1, 1), (1, 2), (2, 1), (2, 2) });
            sortTuple.Sort();
            sortTuple.ForEach(t => Console.WriteLine(t));

            sortTuple.Sort((t1, t2) => t1.Item1 == t2.Item1 ? t2.Item2 - t1.Item2 : t2.Item1 - t1.Item1);
            sortTuple.ForEach(t => Console.WriteLine(t));


            var sortlist = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 });
            sortlist.Sort((x1, x2) => x2 - x1);
            sortlist.ForEach(x => Console.WriteLine(x));

            if (Math.Ceiling((new Random()).NextDouble()) > -1) return;
            //////////////////////////////////////////
            ///list operation
            var intlist = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 });
            var avg = intlist.Average();
            var min = intlist.Min();
            var max = intlist.Max();
            var sum = intlist.Select(x => (long)x).Sum();
            Console.WriteLine(min.ToString());
            Console.WriteLine(avg.ToString());
            Console.WriteLine(max.ToString());
            Console.WriteLine(sum.ToString());

            var x11 = intlist.Where(x => x % 2 == 0).Select(x => x * 10).Average();
            Console.WriteLine(x11.ToString());

            //////////////////////////////////////////
            // numeric number format
            Console.WriteLine(0.12345.ToString("0.00"));
            Console.WriteLine(3.1415926.ToString("000.00000"));

            //////////////////////////////////////////
            // PriorityQueue Comparer
            /// var pq = new PriorityQueue<TElement, TPrioirty>(Comparer<(TPrioirty)>.Create((x, y) => {x.CompareTo(y);});
            /// 

            var intList = new List<int>(new int[] { 1, 2, 2, 3 });
            var strList = new List<string>(new string[] { "a", "a", "b" });

            var tupleComparer = Comparer<(int, string)>.Create(
                (x, y) =>
                {
                    if (x.Item1 != y.Item1)
                    {
                        return x.Item1 - y.Item1;
                    }
                    else
                    {
                        return x.Item2.CompareTo(y.Item2);
                    }
                });

            var pq = new PriorityQueue<(int, string), (int, string)>(tupleComparer);

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
                //Console.WriteLine(item.I + item.S);
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

            // Greatest Common Divisor
            // Euclid's algorithm
            //dividing larger number by the smaller number
            //replacing the larger number with the smaller
            //replacing the smaller number with the remainder
            //until the remainder is zero.
            //The last non-zero remainder is the GCD
            //int gcd(int a, int b) => b == 0 ? a : gcd(b, a % b);
            int gcd(int larger, int smaller) => smaller == 0 ? larger : gcd(smaller, larger % smaller);
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

            Console.WriteLine(q.First.Value);
            Console.WriteLine(q.Last.Value);
            Console.WriteLine();
            q.RemoveFirst();
            Console.WriteLine(q.First.Value);
            Console.WriteLine(q.Last.Value);
            Console.WriteLine();
            q.RemoveLast();
            Console.WriteLine(q.First.Value);
            Console.WriteLine(q.Last.Value);
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

            // call by out, ref, value
            // by out
            void GetLastName(out string lastName) {
                lastName = "zhang";
            }
            GetLastName(out string lastName);
            Console.WriteLine(lastName);//zhang

            // by ref
            void SetFirstName(ref string firstName) {
                firstName = "hanzhong";
            }
            string firstName = "";
            SetFirstName(ref firstName);
            Console.WriteLine(firstName);//hanzhong

            // by value
            void SetMiddleName(string middleName) {
                middleName = "hanz";
            }
            string middleName = "empty";
            SetMiddleName(middleName);
            Console.WriteLine(middleName);//empty

            // Random
            var r = new Random();
            var randomInteger = r.Next(); // 0 <= randomInt < int.MaxValue;
            var randomDouble = r.NextDouble(); // 0.0 <= randomDouble < 1.0
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
            Console.WriteLine(int.TryParse("123", out int res) ? res : "not int"); // 123
            Console.WriteLine(int.TryParse("123abc", out int res2) ? res : "not int"); // not int

            // Math 
            Console.WriteLine(Math.Max(1, 2)); //2
            Console.WriteLine(Math.Min(1, 2)); //1
            Console.WriteLine((int)Math.Pow(10, 3)); //1000
            Console.WriteLine(Math.Abs(-12321)); //12321
            Console.WriteLine(Math.Ceiling(1.23)); //2
            Console.WriteLine(Math.Floor(1.23)); //1


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
            nums = new int[] { 2, 1, 4, 3, 5 };
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