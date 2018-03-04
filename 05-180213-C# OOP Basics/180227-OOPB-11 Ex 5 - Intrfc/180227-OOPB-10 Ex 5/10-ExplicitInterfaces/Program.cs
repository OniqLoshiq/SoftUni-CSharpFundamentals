using System;
using System.Collections.Generic;

namespace _10_ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();

            GetCitizens(citizens);
            PrintCitizens(citizens);
        }

        private static void PrintCitizens(List<Citizen> citizens)
        {
            citizens.ForEach(c => Console.WriteLine("{0}{1}{2} {0}", ((IPerson)c).GetName(), Environment.NewLine, ((IResident)c).GetName()));
        }

        private static void GetCitizens(List<Citizen> citizens)
        {
            string data = String.Empty;

            while ((data = Console.ReadLine()) != "End")
            {
                string[] tokens = data.Split();
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);
                
                citizens.Add(new Citizen(name, age, country));
            }
        }
    }
}
