using System;
using System.Threading;
using DataStructures.LinkedList;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            StackDemo();
            QueueDemo();
            LinkedListDemo();
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static void LinkedListDemo()
        {
            Console.WriteLine($"\n*** {nameof(LinkedListDemo)} ***\n");

            var toDoList = new LinkedList<string>();

            toDoList.Add("Buy milk");
            toDoList.Add("Feed a cat");
            toDoList.AddAt(0, "Study C#");

            Console.WriteLine($"There are {toDoList.Length} things to do:");
            foreach (var item in toDoList)
            {
                Console.WriteLine($"\t-{item};");
            }

            Console.WriteLine($"\n{toDoList.ElementAt(0).Item} is done!");
            Console.WriteLine($"{toDoList.ElementAt(2).Item} is done!");

            toDoList.Remove("Buy milk");
            toDoList.RemoveAt(1);
            
            Console.WriteLine($"\n{toDoList.Length} things left to do:");
            foreach (var item in toDoList)
            {
                Console.WriteLine($"\t-{item}");
            }
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