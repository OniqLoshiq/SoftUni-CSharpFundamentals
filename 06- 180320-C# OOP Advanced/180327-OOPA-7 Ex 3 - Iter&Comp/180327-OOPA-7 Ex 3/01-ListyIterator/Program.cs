using System;
using System.Linq;

namespace _01_ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = new ListyIterator<string>();

            string input = String.Empty;

            while((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split();
                string command = cmdArgs[0];

                try
                {
                    switch (command)
                    {
                        case "Create": listyIterator = new ListyIterator<string>(cmdArgs.Skip(1).ToArray()); break;
                        case "Move": Console.WriteLine(listyIterator.Move()); break;
                        case "HasNext": Console.WriteLine(listyIterator.HasNext()); break;
                        case "Print": Console.WriteLine(listyIterator.Print()); break;
                        default:
                            throw new InvalidOperationException("Invalid Operation!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
