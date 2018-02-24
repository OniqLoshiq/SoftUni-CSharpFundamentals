using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        List<Person> children = new List<Person>();
        List<Person> parents = new List<Person>();
        List<Person> people = new List<Person>();

        string personData = Console.ReadLine();
        if(personData.Contains("/"))
        {
            person.BirthDate = personData;
        }
        else
        {
            person.Name = personData;
        }

        Queue<string> inputData = new Queue<string>();

        GetData(inputData, personData, people);

        if(person.Name != null)
        {
            person = people.First(x => x.Name == person.Name);
        }
        else
        {
            person = people.First(x => x.BirthDate == person.BirthDate);
        }

        GetPersonFamily(person, people, inputData, children, parents);

        Print(person, parents, children);
    }

    private static void Print(Person person, List<Person> parents, List<Person> children)
    {
        Console.WriteLine(person.ToString());
        Console.WriteLine("Parents:");
        if (parents.Count > 0)
        {
            foreach (var parent in parents)
            {
                Console.WriteLine(parent.ToString());
            }
        }

        Console.WriteLine("Children:");
        if (children.Count > 0)
        {
            foreach (var child in children)
            {
                Console.WriteLine(child.ToString());
            }
        }
    }

    private static void GetPersonFamily(Person person, List<Person> people, Queue<string> inputData, List<Person> children, List<Person> parents)
    {
        int n = inputData.Count;
        for (int i = 0; i < n; i++)
        {
            string[] familyTie = inputData.Dequeue().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            if (familyTie[0] == person.Name || familyTie[0] == person.BirthDate)
            {
                if (familyTie[1].Contains("/"))
                {
                    children.Add(people.First(x => x.BirthDate == familyTie[1]));
                }
                else
                {
                    children.Add(people.First(x => x.Name == familyTie[1]));
                }
            }
            else if (familyTie[1] == person.Name || familyTie[1] == person.BirthDate)
            {
                if (familyTie[0].Contains("/"))
                {
                    parents.Add(people.First(x => x.BirthDate == familyTie[0]));
                }
                else
                {
                    parents.Add(people.First(x => x.Name == familyTie[0]));
                }
            }
        }
    }

    private static void GetData(Queue<string> inputData, string personData, List<Person> people)
    {
        while ((personData = Console.ReadLine()) != "End")
        {
            string[] tokens = personData.Split();

            if (!personData.Contains("-"))
            {
                string name = tokens[0] + " " + tokens[1];
                Person thisPerson = new Person(name, tokens[2]);
                people.Add(thisPerson);
            }
            else
            {
                inputData.Enqueue(personData);
            }
        }
    }
}
