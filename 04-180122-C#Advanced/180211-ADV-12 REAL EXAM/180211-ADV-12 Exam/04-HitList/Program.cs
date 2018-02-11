using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            int infoIndex = int.Parse(Console.ReadLine());

            var people = new Dictionary<string, Dictionary<string, string>>();

            string input = String.Empty;

            while((input = Console.ReadLine()) != "end transmissions")
            {
                string[] personData = input.Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];

                if(!people.ContainsKey(name))
                {
                    people[name] = new Dictionary<string, string>();
                }

                for (int i = 1; i < personData.Length; i++)
                {
                    string[] keyValueData = personData[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string key = keyValueData[0];
                    string value = keyValueData[1];

                    if(!people[name].ContainsKey(key))
                    {
                        people[name][key] = String.Empty;
                    }

                    people[name][key] = value;
                }
            }

            string personToKill = Console.ReadLine().Substring(5);
            int personIndex = 0;

            Console.WriteLine($"Info on {personToKill}:");

            foreach (var info in people[personToKill].OrderBy(x => x.Key))
            {
                personIndex += info.Key.Length + info.Value.Length;
                Console.WriteLine($"---{info.Key}: {info.Value}");
            }

            Console.WriteLine($"Info index: {personIndex}");

            if(personIndex >= infoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {infoIndex - personIndex} more info.");
            }
        }
    }
}
