using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<string>();
            var txt = String.Empty;

            for (int i = 0; i < n; i++)
            {
                List<string> input = Console.ReadLine().Split().ToList();

                string cmd = input[0];
                string arg = String.Empty;

                if (input.Count == 2)
                {
                    arg = input[1];
                }

                switch (cmd)
                {
                    case "1":
                        stack.Push(txt);
                        txt += arg;
                        break;

                    case "2":
                        stack.Push(txt);
                        txt = txt.Substring(0, txt.Length - int.Parse(arg));
                        break;

                    case "3":
                        Console.WriteLine(txt[int.Parse(arg) - 1]);
                        break;

                    case "4":
                        txt = stack.Pop();
                        break;
                }
            }

          //int n = int.Parse(Console.ReadLine());
          //
          //var stack = new Stack<List<string>>();
          //var sb = new StringBuilder();
          //
          //for (int i = 0; i < n; i++)
          //{
          //    List<string> input = Console.ReadLine().Split().ToList();
          //
          //    string cmd = input[0];
          //    string arg = String.Empty;
          //
          //    if (input.Count == 2)
          //    {
          //        arg = input[1];
          //    }
          //
          //    switch (cmd)
          //    {
          //        case "1":
          //            sb.Append(arg); stack.Push(input);
          //            break;
          //
          //        case "2":
          //            string removedText = sb.ToString().Substring((sb.Length - int.Parse(arg)));
          //            sb.Remove(sb.Length - int.Parse(arg), int.Parse(arg));
          //            input.Add(removedText);
          //            stack.Push(input);
          //            break;
          //
          //        case "3":
          //            Console.WriteLine(sb.ToString()[int.Parse(arg) - 1]);
          //            break;
          //
          //        case "4":
          //            var cmds = stack.Pop();
          //            cmd = cmds[0];
          //            arg = cmds[1];
          //
          //            if (cmd == "1")
          //            {
          //                sb.Remove(sb.Length - arg.Length, arg.Length);
          //            }
          //            else
          //            {
          //                string textToUndo = cmds[2];
          //                sb.Append(textToUndo);
          //            }
          //            break;
          //    }
          //}
        }
    }
}
