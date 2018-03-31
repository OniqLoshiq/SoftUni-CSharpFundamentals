using System;
using System.Collections.Generic;

namespace _05_ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> people = new List<Person>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] personData = input.Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);
                string town = personData[2];

                people.Add(new Person(name, age, town));
            }

            int personIndex = int.Parse(Console.ReadLine()) - 1;
            var selectedPerson = people[personIndex];

            int equalPeople = 0;
            int notEqualPeople = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(selectedPerson) != 0)
                    notEqualPeople++;
                else
                    equalPeople++;
            }

            if(equalPeople == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {notEqualPeople} {people.Count}");
            }
        }
    }
}
