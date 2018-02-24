using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Trainer> allTrainers = new List<Trainer>();

        GetTrainersAndPokemons(allTrainers);

        Battle(allTrainers);

        foreach (var trainer in allTrainers.OrderByDescending(x => x.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }

    private static void Battle(List<Trainer> allTrainers)
    {
        string element = String.Empty;

        while((element = Console.ReadLine()) != "End")
        {
            foreach (var trainer in allTrainers)
            {
                if (!trainer.Pokemons.Any(x => x.Element == element))
                {
                    trainer.Pokemons.ForEach(x => x.Health -= 10);
                    trainer.Pokemons = trainer.Pokemons.Where(x => x.Health > 0).ToList();
                }
                else
                {
                    trainer.Badges += 1;
                }
            }
        }
    }

    private static void GetTrainersAndPokemons(List<Trainer> allTrainers)
    {
        string inputData = String.Empty;

        while ((inputData = Console.ReadLine()) != "Tournament")
        {
            string[] tokens = inputData.Split();
            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            double pokemonHealth = double.Parse(tokens[3]);

            Pokemon thisPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (!allTrainers.Any(x => x.Name == trainerName))
            {
                Trainer thisTrainer = new Trainer(trainerName);
                allTrainers.Add(thisTrainer);
            }

            int trainerIndex = allTrainers.FindIndex(x => x.Name == trainerName);
            allTrainers[trainerIndex].Pokemons.Add(thisPokemon);
        }
    }
}

