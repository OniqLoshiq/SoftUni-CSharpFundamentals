using System;
using System.Linq;

namespace _02_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = new ListyIterator<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
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
                        case "Print": listyIterator.Print(); break;
                        case "PrintAll": listyIterator.PrintAll(); break;
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
