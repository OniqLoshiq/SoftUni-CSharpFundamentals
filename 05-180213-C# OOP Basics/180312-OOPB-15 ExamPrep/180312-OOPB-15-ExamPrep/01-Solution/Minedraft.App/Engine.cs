using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private DraftManager draftmanager;

    public Engine()
    {
        this.isRunning = true;
        this.draftmanager = new DraftManager();
    }

    public void Run()
    {
        while (isRunning)
        {
            List<string> args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string result = args[0];
            args = args.Skip(1).ToList();

            switch (result)
            {
                case "RegisterHarvester": Print(this.draftmanager.RegisterHarvester(args)); break;
                case "RegisterProvider": Print(this.draftmanager.RegisterProvider(args)); break;
                case "Mode": Print(this.draftmanager.Mode(args)); break;
                case "Day": Print(this.draftmanager.Day()); break;
                case "Check": Print(this.draftmanager.Check(args)); break;
                case "Shutdown": Print(this.draftmanager.ShutDown()); isRunning = false; break;
                default:
                    break;
            }
        }
    }

    private void Print(string output)
    {
        Console.WriteLine(output);
    }
}
