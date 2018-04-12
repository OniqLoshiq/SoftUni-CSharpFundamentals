using _04_WorkForce.Interfaces;
using System;
using System.Linq;

namespace _04_WorkForce
{
    public class Engine : IRunnable
    {
        private IOffice office;
        private IEmployeeFactory employeeFactory;
        private IJobFactory jobFactory;

        public Engine(IOffice office, IEmployeeFactory employeeFactory, IJobFactory jobFactory)
        {
            this.office = office;
            this.employeeFactory = employeeFactory;
            this.jobFactory = jobFactory;
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string cmd = tokens[0];

                try
                {
                    if (cmd.EndsWith("Employee"))
                    {
                        IEmployable employee = this.employeeFactory.CreateEmployee(tokens);
                        this.office.AddEmployee(employee);
                    }
                    else if (cmd == "Job")
                    {
                        string employeeName = tokens[3];
                        IEmployable employee = this.office.Employees.First(e => e.Name == employeeName);

                        IJob task = this.jobFactory.CreateJob(tokens, employee);

                        this.office.AddTask(task);
                    }
                    else if (cmd == "Pass")
                    {
                        this.office.WeekPass();
                    }
                    else if (cmd == "Status")
                    {
                        this.office.Status();
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
