using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> peopleAndAnimals = new List<IBirthable>();

            GetPeopleAndAnimalsData(peopleAndAnimals);

            string yearOfBirthdates = Console.ReadLine();

            PrintBirthdays(peopleAndAnimals, yearOfBirthdates);
        }

        private static void PrintBirthdays(List<IBirthable> peopleAndAnimals, string yearOfBirthdates)
        {
            peopleAndAnimals.Where(x => x.Birthdate.EndsWith(yearOfBirthdates)).ToList().ForEach(x => Console.WriteLine(x.Birthdate));
        }

        private static void GetPeopleAndAnimalsData(List<IBirthable> peopleAndAnimals)
        {
            string inputObjectData = String.Empty;

            while ((inputObjectData = Console.ReadLine()) != "End")
            {
                string[] tokens = inputObjectData.Split();

                if(tokens[0] == "Citizen")
                {
                    peopleAndAnimals.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                }
                else if (tokens[0] == "Pet")
                {
                    peopleAndAnimals.Add(new Pet(tokens[1], tokens[2]));
                }
            }
        }
    }
}
