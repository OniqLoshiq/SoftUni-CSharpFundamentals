using System;
using System.Collections.Generic;

namespace _06_StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameComparer = new PersonNameComparator();
            var ageComparer = new PersonAgeComparator();

            var peopleByName = new SortedSet<Person>(nameComparer);
            var peopleByAge = new SortedSet<Person>(ageComparer);

            int peopleNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleNumber; i++)
            {
                string[] personData = Console.ReadLine().Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);

                peopleByName.Add(new Person(name, age));
                peopleByAge.Add(new Person(name, age));
            }

            PrintSet(peopleByName);
            PrintSet(peopleByAge);

        }

        private static void PrintSet(SortedSet<Person> collection)
        {
            foreach (var person in collection)
            {
                Console.WriteLine(person);
            }
        }
    }
}
