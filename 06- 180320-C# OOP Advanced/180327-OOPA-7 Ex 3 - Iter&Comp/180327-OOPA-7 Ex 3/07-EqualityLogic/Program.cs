using System;
using System.Collections.Generic;

namespace _07_EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleSorted = new SortedSet<Person>();
            var peopleHash = new HashSet<Person>();

            int numOfPpl = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfPpl; i++)
            {
                string[] personData = Console.ReadLine().Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);
                var person = new Person(name, age);

                peopleSorted.Add(person);
                peopleHash.Add(person);
            }

            Console.WriteLine(peopleSorted.Count);
            Console.WriteLine(peopleHash.Count);
        }
    }
}
