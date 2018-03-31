using System;
using System.Linq;

namespace _03_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            IMyStack<int> myStack = new MyStack<int>();

            string input = String.Empty;

            while((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];

                try
                {
                    switch (command)
                    {
                        case "Push":
                            myStack.Push(cmdArgs.Skip(1).Select(x => x.TrimEnd(',')).Select(int.Parse).ToArray());
                            break;
                        case "Pop": myStack.Pop(); break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                PrintMyStack(myStack);
            }
        }

        private static void PrintMyStack(IMyStack<int> myStack)
        {
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
