using Logger.Model.Models;
using System.Collections.Generic;

namespace Logger.Model.Interfaces
{
    public interface IAppender
    {
        ReportLevel ReportLevelThreshold { get; }
        ILayout Layout { get; }
        IReadOnlyCollection<ILog> Logs { get; }
        void Append(ILog log);
        string GetInfo();
    }
}
