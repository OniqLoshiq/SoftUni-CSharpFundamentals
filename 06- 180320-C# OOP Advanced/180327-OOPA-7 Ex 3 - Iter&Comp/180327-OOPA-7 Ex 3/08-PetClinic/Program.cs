using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_PetClinic
{
    class Program
    {
        private static List<Clinic> allClinics = new List<Clinic>();
        private static List<Pet> allPets = new List<Pet>();

        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string command = cmdArgs[0];
                Clinic currentClinic = null;

                if (command == "Create")
                {
                    command += $" {cmdArgs[1]}";
                }

                switch (command)
                {
                    case "Create Pet":
                        Pet pet = new Pet(cmdArgs[2], int.Parse(cmdArgs[3]), cmdArgs[4]);
                        allPets.Add(pet);
                        break;

                    case "Create Clinic":
                        try
                        {
                            Clinic clinic = new Clinic(cmdArgs[2], int.Parse(cmdArgs[3]));
                            allClinics.Add(clinic);
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "Add":
                        string petName = cmdArgs[1];
                        string clinicName = cmdArgs[2];

                        try
                        {
                            Pet petToAdd = allPets.FirstOrDefault(p => p.Name == petName);
                            if (petToAdd == null)
                                throw new InvalidOperationException("Invalid Operation!");

                            currentClinic = GetClinic(clinicName);
                            Console.WriteLine(currentClinic.AddPet(petToAdd));
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "Release":
                        currentClinic = GetClinic(cmdArgs[1]);
                        Console.WriteLine(currentClinic.ReleasePet());
                        break;

                    case "HasEmptyRooms":
                        currentClinic = GetClinic(cmdArgs[1]);
                        Console.WriteLine(currentClinic.HasEmptyRooms());
                        break;

                    case "Print":
                        currentClinic = GetClinic(cmdArgs[1]);

                        if (cmdArgs.Length == 2)
                        {
                            currentClinic.PrintAll();
                        }
                        else
                        {
                            currentClinic.Print(int.Parse(cmdArgs[2]));
                        }
                        break;
                }
            }
        }

        private static Clinic GetClinic(string clinicName)
        {
            return allClinics.First(c => c.Name == clinicName);
        }
    }
}
