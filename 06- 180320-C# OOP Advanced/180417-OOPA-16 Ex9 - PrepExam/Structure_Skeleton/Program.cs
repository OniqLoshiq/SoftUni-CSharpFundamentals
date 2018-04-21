public class Program
{
    public static void Main(string[] args)
    {
        ICommandInterpreter commandInterpreter = InitializeCommandInterpreter();

        Engine engine = new Engine(commandInterpreter, new ConsoleReader(), new ConsoleWriter());
        engine.Run();
    }

    private static ICommandInterpreter InitializeCommandInterpreter()
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        IHarvesterController harvesterController = new HarvesterController(energyRepository);
        IProviderController providerController = new ProviderController(energyRepository);

        return new CommandInterpreter(harvesterController, providerController);
    }
}