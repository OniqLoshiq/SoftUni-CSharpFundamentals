using System;
using System.Linq;
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine();

                if (input == "END")
                    break;

                try
                {
                    string result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex) 
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var data = input.Split(" ");

            var cmdName = data[0];
            var args = data.Skip(1).ToArray();

            if (cmdName == "LetsRock")
            {
                var result = this.setCоntroller.PerformSets();
                return result;
            }

            var festivalcontrolfunction = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == cmdName);

            string cmdResult = String.Empty;

            try
            {
                cmdResult = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { args });
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }

            return cmdResult;
        }
    }
}