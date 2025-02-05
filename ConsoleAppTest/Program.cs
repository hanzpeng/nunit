using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

Console.WriteLine("hi");
Stack<char> stack = new Stack<char>();
stack.Push('a');
stack.Push('b');
stack.Push('c');

var l = new string(stack.Reverse().ToArray());

Console.WriteLine(l);