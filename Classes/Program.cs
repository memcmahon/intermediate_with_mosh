using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push("hello");
            stack.Push("world");

            Console.WriteLine(stack.Pop());
            Console.WriteLine("Length: " + stack.Length());
            Console.WriteLine(stack.Pop());
            Console.WriteLine("Length: " + stack.Length());
            Console.WriteLine(stack.Pop());
            Console.WriteLine("Length: " + stack.Length());
            Console.WriteLine(stack.Pop());
            Console.WriteLine("Length: " + stack.Length());
            Console.WriteLine(stack.Pop());
            Console.WriteLine("Length: " + stack.Length());
        }
    }
}
