using Logger.Model.Factories;
using Logger.Model.Interfaces;
using Logger.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.App
{
    public class Engine
    {
        private readonly AppenderFactory appenderFactory;
        private readonly LogFactory logFactory;

        private Reader reader;
        private LogConsole logConsole;
        private MainLogger MainLogger;

        public Engine()
        {
            this.reader = new Reader();
            this.logConsole = new LogConsole();
            this.MainLogger = new MainLogger();
            this.appenderFactory = new AppenderFactory();
            this.logFactory = new LogFactory();
        }

        public void Run()
        {
            try
            {
                int numberOfAppenders = int.Parse(this.reader.ReadLine());

                GetAppenders(numberOfAppenders);

                GetReports();

                this.logConsole.WriteLine("Logger info");

                this.logConsole.WriteLine(this.MainLogger.PrintInfo());
            }
            catch (ArgumentException e)
            {
                this.logConsole.WriteLine(e.Message);
            }
        }

        private void GetReports()
        {
            string text = String.Empty;

            while ((text = this.reader.ReadLine()) != "END")
            {
                string[] args = text.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);

                ILog log = logFactory.CreateLog(args);

                this.MainLogger.AddLog(log);
            }
        }

        private void GetAppenders(int numberOfAppenders)
        {
            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] appenderInfo = this.reader.ReadLine().Split();

                IAppender appender = appenderFactory.CreateAppender(appenderInfo);

                this.MainLogger.AddAppender(appender);
            }
        }
    }
}
