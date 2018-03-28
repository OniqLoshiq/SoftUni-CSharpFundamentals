using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Model.Interfaces
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }
        void AddAppender(IAppender appender);
        void AddLog(ILog log);
        string PrintInfo();
    }
}
