using System;
using System.Collections.Generic;
using System.Text;

namespace _04_WorkForce.Interfaces
{
    public interface IEmployeeFactory
    {
        IEmployable CreateEmployee(string[] data);
    }
}
