using System;
using System.Threading;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            StackDemo();
            QueueDemo();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static void QueueDemo()
        {
            Console.WriteLine($"\n**** {nameof(QueueDemo)} ****\n");

            var groceryQueue = new Queue<string>();

            Console.WriteLine($@"- {groceryQueue.Enqueue("Mike")} came at {DateTime.Now.ToLongTimeString()}.");
            Thread.Sleep(1000);
            Console.WriteLine($@"- {groceryQueue.Enqueue("Lisa")} came at {DateTime.Now.ToLongTimeString()}.");
            Console.WriteLine();

            Console.WriteLine($"{groceryQueue.Dequeue()} is first in line...");
            Console.WriteLine($"...than {groceryQueue.Dequeue()} goes...");
        }

        private static void StackDemo()
        {
            Console.WriteLine($"\n**** {nameof(StackDemo)} ****\n");

            var emergencyCalls = new Stack<string>();

            Console.WriteLine($@"- {emergencyCalls.Push("Mike")} has arrived at {DateTime.Now.ToLongTimeString()}!");
            Thread.Sleep(1000);
            Console.WriteLine($@"- {emergencyCalls.Push("Lisa")} has arrived at {DateTime.Now.ToLongTimeString()}!");
            Console.WriteLine();

            Console.WriteLine($"Who's next?\n- {emergencyCalls.Peek()}");
            Console.WriteLine($"Left in line: {emergencyCalls.Count}");

            Console.WriteLine($"{emergencyCalls.Pop()} needs help first!");
            Console.WriteLine($"{emergencyCalls.Count} patients left.");

            Console.WriteLine($"{emergencyCalls.Pop()} can go next.");
            Console.WriteLine($"{emergencyCalls.Count} patients in emergency room.");

            Console.WriteLine($"Who's next?\n- {emergencyCalls.Pop() ?? "Nobody"}");
        }
    }
}