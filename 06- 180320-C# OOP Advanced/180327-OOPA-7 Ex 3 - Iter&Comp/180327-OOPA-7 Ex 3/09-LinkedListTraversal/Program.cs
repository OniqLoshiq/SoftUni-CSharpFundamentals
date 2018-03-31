using System;

namespace _09_LinkedListTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var myLinkedList = new MyLinkedList<int>();

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string command = cmdArgs[0];
                int num = int.Parse(cmdArgs[1]);

                switch (command)
                {
                    case "Add": myLinkedList.Add(num); break;
                    case "Remove": myLinkedList.Remove(num); break;
                }
            }

            Console.WriteLine(myLinkedList.Count);
            Console.WriteLine(string.Join(" ", myLinkedList));
        }
    }
}
