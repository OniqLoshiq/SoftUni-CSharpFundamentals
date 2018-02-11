using System;
using System.Collections.Generic;

namespace _07_BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if(input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            Stack<char> stack = new Stack<char>();

            bool checker = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '[' || input[i] == '(')
                {
                    stack.Push(input[i]);
                }

                if(input[i] == '}' || input[i] == ']' || input[i] == ')')
                {
                    if(stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        checker = false;
                        break;
                    }
                    else
                    {
                        char closingParenthesis = ' ';

                        switch (input[i])
                        {
                            case '}': closingParenthesis = '{'; break;
                            case ']': closingParenthesis = '['; break;
                            case ')': closingParenthesis = '('; break;
                        }

                        if (stack.Peek() == closingParenthesis)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            checker = false;
                            break;
                        }
                    }
                }
            }

            if(stack.Count == 0 && checker)
            {
                Console.WriteLine("YES");
            }
        }
    }
}
