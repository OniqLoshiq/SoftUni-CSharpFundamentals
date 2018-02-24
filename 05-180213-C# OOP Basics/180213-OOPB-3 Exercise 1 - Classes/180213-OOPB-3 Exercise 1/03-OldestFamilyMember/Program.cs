using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            Person person = new Person(int.Parse(input[1]), input[0]);
            family.AddMember(person);
        }

        Person oldestMember = family.GetOldestMember();

        Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
    }
}
