using _04_WorkForce.Factories;
using _04_WorkForce.Interfaces;
using _04_WorkForce.Models;
using System;

namespace _04_WorkForce
{
    class Program
    {
        static void Main(string[] args)
        {
            IOffice office = new Office();
            IEmployeeFactory employeeFactory = new EmployeeFactory();
            IJobFactory jobFactory = new JobFactory();

            IRunnable engine = new Engine(office, employeeFactory, jobFactory);
            engine.Run();
        }
    }
}
