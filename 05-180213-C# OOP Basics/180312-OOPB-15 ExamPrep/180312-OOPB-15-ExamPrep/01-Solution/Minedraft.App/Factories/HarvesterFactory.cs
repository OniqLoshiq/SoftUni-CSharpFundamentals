using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester ProduceHarvester(List<string> harvesterTokens)
    {
        Harvester harvester = null;
        string type = harvesterTokens[0];
        string id = harvesterTokens[1];
        double oreOutput = double.Parse(harvesterTokens[2]);
        double energyRequirement = double.Parse(harvesterTokens[3]);

        switch (type)
        {
            case "Sonic": harvester = new SonicHarvester(id, oreOutput, energyRequirement, int.Parse(harvesterTokens[4])); break;
            case "Hammer": harvester = new HammerHarvester(id, oreOutput, energyRequirement); break;
            default:
                break;
        }

        return harvester;
    }
}
