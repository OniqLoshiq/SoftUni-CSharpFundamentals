using System.Collections.Generic;

public static class ProviderFactory
{
    public static Provider ProduceProvider(List<string> providerTokens)
    {
        Provider provider = null;
        string type = providerTokens[0];
        string id = providerTokens[1];
        double energyOutput = double.Parse(providerTokens[2]);

        switch (type)
        {
            case "Solar": provider = new SolarProvider(id, energyOutput); break;
            case "Pressure": provider = new PressureProvider(id, energyOutput); break;
            default:
                break;
        }

        return provider;
    }
}
