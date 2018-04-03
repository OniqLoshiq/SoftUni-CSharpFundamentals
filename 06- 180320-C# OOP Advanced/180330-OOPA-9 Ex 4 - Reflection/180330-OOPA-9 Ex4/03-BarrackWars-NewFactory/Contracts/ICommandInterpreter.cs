namespace _03_BarrackWars.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] data, string commandName);
    }
}
