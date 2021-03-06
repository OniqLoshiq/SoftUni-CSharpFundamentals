﻿using System;

namespace _08_CustomListSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            var customList = new CustomList<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split();
                string command = cmdArgs[0];

                switch (command)
                {
                    case "Add": customList.Add(cmdArgs[1]); break;
                    case "Remove": customList.Remove(int.Parse(cmdArgs[1])); break;
                    case "Contains": Console.WriteLine(customList.Contains(cmdArgs[1])); break;
                    case "Swap":
                        int index1 = int.Parse(cmdArgs[1]);
                        int index2 = int.Parse(cmdArgs[2]);
                        customList.Swap(index1, index2);
                        break;
                    case "Greater": Console.WriteLine(customList.CountGreaterThan(cmdArgs[1])); break;
                    case "Max": Console.WriteLine(customList.Max()); break;
                    case "Min": Console.WriteLine(customList.Min()); break;
                    case "Sort": customList.Sort(); break;
                    case "Print":
                        //Sorter<string>.Sort(customList);
                        for (int i = 0; i < customList.Count; i++)
                        {
                            Console.WriteLine(customList[i]);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
