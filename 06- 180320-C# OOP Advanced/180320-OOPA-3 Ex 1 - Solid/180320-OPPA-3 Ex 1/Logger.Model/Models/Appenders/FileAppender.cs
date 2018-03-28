using Logger.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Model.Models.Appenders
{
    public class FileAppender : IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevelThreshold { get; }

        private ILogFile File { get; }

        private List<ILog> logs;

        public IReadOnlyCollection<ILog> Logs
        {
            get { return this.logs.AsReadOnly(); }
        }

        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevelThreshold = 0;
            this.logs = new List<ILog>();
            this.File = new LogFile();
        }

        public FileAppender(ILayout layout, ReportLevel reportLevelThreshold) : this(layout)
        {
            this.ReportLevelThreshold = reportLevelThreshold;
        }

        public void Append(ILog log)
        {
            if (CheckLoggerThreshold(log))
            {
                this.logs.Add(log);
                string logText = this.Layout.GetLayoutOutput(log);

                this.File.Write(logText);
            }
        }

        private bool CheckLoggerThreshold(ILog log)
        {
            if (this.ReportLevelThreshold <= log.ReportLevel)
            {
                return true;
            }

            return false;
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.Append($"Appender type: {this.GetType().Name}, " +
                $"Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.ReportLevelThreshold}, " +
                $"Messages appended: {this.Logs.Count} , " +
                $"File size: {this.File.Size}" + Environment.NewLine +
                $"-==  The log file is generated with an unique name and is located at your desktop  ==-");

            return sb.ToString().TrimEnd();
        }

    }
}
