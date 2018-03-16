using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = "Full";
        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;
    }

    public string RegisterHarvester(List<string> args)
    {
        try
        {
            Harvester harvester = HarvesterFactory.ProduceHarvester(args);
            harvesters.Add(harvester);
            return $"Successfully registered {args[0]} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string RegisterProvider(List<string> args)
    {
        try
        {
            Provider provider = ProviderFactory.ProduceProvider(args);
            providers.Add(provider);

            return $"Successfully registered {args[0]} Provider - {provider.Id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        double energyOutputForTheDay = providers.Sum(x => x.EnergyOutput);
        double oreOutputForTheDay = 0.0;

        totalStoredEnergy += energyOutputForTheDay;
        double totalEnergyRequirement = harvesters.Sum(x => x.EnergyRequirement);

        switch (mode)
        {
            case "Full":
                if (totalEnergyRequirement <= totalStoredEnergy)
                {
                    totalStoredEnergy -= totalEnergyRequirement;
                    oreOutputForTheDay = harvesters.Sum(x => x.OreOutput);
                    totalMinedOre += oreOutputForTheDay;
                }
                break;

            case "Half":
                totalEnergyRequirement *= 0.6;

                if (totalEnergyRequirement <= totalStoredEnergy)
                {
                    totalStoredEnergy -= totalEnergyRequirement;
                    oreOutputForTheDay = harvesters.Sum(x => x.OreOutput) * 0.5;
                    totalMinedOre += oreOutputForTheDay;
                }
                break;

            case "Energy":
                break;
        }

        var sb = new StringBuilder();

        sb.AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {energyOutputForTheDay}")
            .Append($"Plumbus Ore Mined: {oreOutputForTheDay}");

        return sb.ToString();
    }

    public string Mode(List<string> args)
    {
        this.mode = args[0];

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> args)
    {
        string id = args[0];

        if (harvesters.Any(x => x.Id == id))
        {
            return harvesters.Single(h => h.Id == id).ToString();
        }
        else if (providers.Any(x => x.Id == id))
        {
            return providers.Single(h => h.Id == id).ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        } 
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {this.totalStoredEnergy}")
            .Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString();
    }
}
