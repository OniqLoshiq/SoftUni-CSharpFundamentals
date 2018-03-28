using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Model.Interfaces
{
    public interface ILogFile
    {
        long Size { get; }
        void Write(string text);
    }
}
