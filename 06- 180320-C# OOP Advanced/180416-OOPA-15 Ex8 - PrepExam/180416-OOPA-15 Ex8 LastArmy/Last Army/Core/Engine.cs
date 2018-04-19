using System;
using System.Text;

public class Engine
{
    private const string pullBack = "Enough! Pull back!";
    private IWriter writer;
    private IReader reader;

    public Engine(IReader reader, IWriter writer)
    {
        this.writer = writer;
        this.reader = reader;
    }

    public void Run()
    {
        var input = reader.ReadLine();
        var gameController = new GameController(writer);

        while (!input.Equals(pullBack))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                writer.AppendLine(arg.Message);
            }
            input = reader.ReadLine();
        }

        gameController.RequestResult();
        writer.WriteLineAll();
    }
}
