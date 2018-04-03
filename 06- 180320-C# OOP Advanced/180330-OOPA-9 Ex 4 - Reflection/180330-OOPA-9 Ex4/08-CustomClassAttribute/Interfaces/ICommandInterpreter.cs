using System;
using System.Collections.Generic;
using System.Text;

namespace _07_InfernoInfinity.Interfaces
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretateCommand(string[] data);
    }
}
