using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

Console.WriteLine("hi");

var res1 = new List<int>() { 1, 2, 3, 4, 5 };
var res2 = new List<int>{ 1, 2, 3, 4, 5 };
List<int> res4 = [1, 2, 3, 4, 5];

//Console.WriteLine();
//Console.Write("res1: ");
//foreach (var i in res1) { Console.Write(i); }

//Console.WriteLine();
//Console.Write("res2: ");
//foreach (var i in res2) { Console.Write(i); }

var res3 = new List<int>([1, 2, 3, 4, 5]);
Console.WriteLine();
Console.Write("res3: ");
foreach (var i in res3) { Console.Write(i); }

//Console.WriteLine();
//Console.Write("res4: ");
//foreach (var i in res4) { Console.Write(i); }
