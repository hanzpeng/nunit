var stack = new Stack<string>("a b c d".Split(" "));
var clone = new Stack<string>(stack.Reverse());
var rev = new Stack<string>(stack);
Console.WriteLine(stack.Peek());//d
Console.WriteLine(clone.Peek());//d
Console.WriteLine(rev.Peek());//a
Console.WriteLine(stack.Pop());//d
stack.Push("e");