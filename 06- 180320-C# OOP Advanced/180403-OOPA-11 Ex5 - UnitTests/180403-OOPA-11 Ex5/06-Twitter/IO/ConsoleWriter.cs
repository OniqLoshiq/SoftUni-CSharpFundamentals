using _06_Twitter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Twitter.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
