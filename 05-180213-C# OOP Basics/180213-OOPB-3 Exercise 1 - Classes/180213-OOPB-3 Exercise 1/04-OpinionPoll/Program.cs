using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            Person person = new Person(int.Parse(input[1]), input[0]);
            people.Add(person);
        }

        foreach (var person in people.Where(x => x.Age > 30).OrderBy(x => x.Name))
        {
            Console.WriteLine(person.Name + " - " + person.Age);
        }
    }
}
