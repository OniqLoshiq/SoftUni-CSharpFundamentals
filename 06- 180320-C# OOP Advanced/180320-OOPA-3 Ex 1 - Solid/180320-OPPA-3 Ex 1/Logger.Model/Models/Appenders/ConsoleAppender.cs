using Logger.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Model.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILogConsole logConsole;

        public ILayout Layout { get; }

        public ReportLevel ReportLevelThreshold { get; }

        private List<ILog> logs;

        public IReadOnlyCollection<ILog> Logs
        {
            get { return this.logs.AsReadOnly(); }
        }

        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevelThreshold = 0;
            this.logs = new List<ILog>();
            this.logConsole = new LogConsole();
        }

        public ConsoleAppender(ILayout layout, ReportLevel reportLevelThreshold) : this(layout)
        {
            this.ReportLevelThreshold = reportLevelThreshold;
        }

        public void Append(ILog log)
        {
            if(CheckLoggerThreshold(log))
            {
                this.logs.Add(log);
                this.logConsole.WriteLine(this.Layout.GetLayoutOutput(log));
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.Append($"Appender type: {this.GetType().Name}, " +
                $"Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.ReportLevelThreshold}, " +
                $"Messages appended: {this.Logs.Count}");

            return sb.ToString().TrimEnd();
        }

        private bool CheckLoggerThreshold(ILog log)
        {
            if (this.ReportLevelThreshold <= log.ReportLevel)
            {
                return true;
            }

            return false;
        }
    }
}
