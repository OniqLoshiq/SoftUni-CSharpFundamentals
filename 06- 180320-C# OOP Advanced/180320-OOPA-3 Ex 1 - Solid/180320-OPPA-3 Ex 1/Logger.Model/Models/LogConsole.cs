using Logger.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Model.Models
{
    public class LogConsole : ILogConsole
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
