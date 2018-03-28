using Logger.Model.Models;
using System;

namespace Logger.Model.Interfaces
{
    public interface ILog
    {
        DateTime Date { get; }
        ReportLevel ReportLevel {get;}
        string Message { get; }
    }
}
