using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            var input = reader.ReadLine();
            var data = input.Split().ToList();

            string result = this.commandInterpreter.ProcessCommand(data);

            this.writer.WriteLine(result);

            if (data[0] == "Shutdown")
                break;
        }
    }
}
