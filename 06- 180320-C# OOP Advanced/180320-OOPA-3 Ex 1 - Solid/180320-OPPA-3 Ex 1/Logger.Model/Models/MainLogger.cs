using Logger.Model.Factories;
using Logger.Model.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Logger.Model.Models
{
    public class MainLogger : ILogger
    {
        private List<IAppender> appenders;

        public IReadOnlyCollection<IAppender> Appenders { get { return this.appenders.AsReadOnly(); } }

        public MainLogger()
        {
            this.appenders = new List<IAppender>();
        }

        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }

        public void AddLog(ILog log)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(log);
            }
        }

        public string PrintInfo()
        {
            var sb = new StringBuilder();

            foreach (var appender in this.appenders)
            {
                sb.AppendLine(appender.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
