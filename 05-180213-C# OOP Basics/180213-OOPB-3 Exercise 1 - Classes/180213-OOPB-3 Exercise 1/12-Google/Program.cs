using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        GetPeople(people);

        string personName = Console.ReadLine();

        Console.Write(people.First(x => x.Name == personName).ToString());
        
    }

    private static void GetPeople(List<Person> people)
    {
        string inputData = String.Empty;

        while ((inputData = Console.ReadLine()) != "End")
        {
            string[] data = inputData.Split();
            string name = data[0];
            string dataClass = data[1];

            if (!people.Any(x => x.Name == name))
            {
                Person newPerson = new Person(name);
                people.Add(newPerson);
            }

            var person = people.First(x => x.Name == name);

            switch (dataClass)
            {
                case "company":
                    string companyName = data[2];
                    string companyDepartment = data[3];
                    decimal salary = decimal.Parse(data[4]);
                    person.Company = new Company(companyName, companyDepartment, salary);
                    break;

                case "pokemon":
                    string pokeName = data[2];
                    string pokeType = data[3];
                    person.Pokemons.Add(new Pokemon(pokeName, pokeType));
                    break;

                case "parents":
                    string parentName = data[2];
                    string bitrhDay = data[3];
                    person.Parents.Add(new Parents(parentName, bitrhDay));
                    break;

                case "children":
                    string childName = data[2];
                    string childBirthDay = data[3];
                    person.Children.Add(new Children(childName, childBirthDay));
                    break;

                case "car":
                    string model = data[2];
                    double speed = double.Parse(data[3]);
                    person.Car = new Car(model, speed);
                    break;
                default:
                    break;
            }
        }
    }
}
