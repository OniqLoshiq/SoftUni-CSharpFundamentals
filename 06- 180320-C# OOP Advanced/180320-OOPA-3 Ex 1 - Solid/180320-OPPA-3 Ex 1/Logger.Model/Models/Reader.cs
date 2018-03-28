using Logger.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Model.Models
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
