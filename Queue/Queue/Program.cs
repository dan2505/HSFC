using System;

namespace QueueProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            ShuntingQueue queue = new ShuntingQueue(100);

            while (running)
            {
                Console.WriteLine("");
                Console.WriteLine("Queue Program");
                Console.WriteLine("1 - Add to queue.");
                Console.WriteLine("2 - Remove from queue.");
                Console.WriteLine("3 - Length of queue.");
                Console.WriteLine("4 - Display queue.");
                Console.WriteLine("5 - Quit");
                Console.WriteLine("");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Object to add to queue: ");
                        queue.Enqueue(Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine(queue.Dequeue());
                        break;
                    case "3":
                        Console.WriteLine(queue.GetLength());
                        break;
                    case "4":
                        Console.WriteLine(queue);
                        break;
                    case "5":
                        running = false;
                        break;
                }
            }
        }
    }
}