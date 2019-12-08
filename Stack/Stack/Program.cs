using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack(100);

            stack.Push(13);
            stack.Push(7);
            stack.Push(5);

            Console.WriteLine(stack.Peek() + " - " + stack.Depth());

            stack.Pop();

            Console.WriteLine(stack.Peek() + " - " + stack.Depth());
            Console.ReadLine();
        }
    }
}
