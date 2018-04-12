using _04_WorkForce.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04_WorkForce.Models
{
    public class Job : IJob
    {
        public int RemainingHours { get; private set; }

        public string Name { get; }

        public IEmployable Employee { get; }

        public event JobDoneEnventHandler JobDoneEvent;

        public Job(int requiredHours, string name, IEmployable employee)
        {
            this.RemainingHours = requiredHours;
            this.Name = name;
            this.Employee = employee;
        }

        public void Update()
        {
            this.RemainingHours -= this.Employee.WorkHoursPerWeek;

            if (this.RemainingHours <= 0)
                this.JobDoneEvent?.Invoke(this);
        }

        public void GetStatus()
        {
            Console.WriteLine($"Job: {this.Name} Hours Remaining: {this.RemainingHours}");
        }
    }
}
