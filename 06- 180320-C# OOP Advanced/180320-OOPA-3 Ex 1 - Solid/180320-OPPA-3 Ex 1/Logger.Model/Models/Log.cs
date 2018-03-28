using Logger.Model.Interfaces;
using System;

namespace Logger.Model.Models
{
    public class Log : ILog
    {
        public DateTime Date { get; }
        public string Message { get; }
        public ReportLevel ReportLevel { get; }

        public Log(DateTime date, string message, ReportLevel reportLevel)
        {
            this.Date = date;
            this.Message = message;
            this.ReportLevel = reportLevel;
        }
    }
}
