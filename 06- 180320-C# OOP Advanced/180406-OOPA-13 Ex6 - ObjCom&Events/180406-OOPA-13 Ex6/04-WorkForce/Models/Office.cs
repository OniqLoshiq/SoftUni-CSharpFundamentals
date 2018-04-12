using _04_WorkForce.Interfaces;
using System;
using System.Collections.Generic;

namespace _04_WorkForce.Models
{
    public class Office : IOffice
    {
        private ICollection<IEmployable> employees;
        private ICollection<IJob> tasks;

        public event GetStatusEventHandler GetStatusEvent;
        public event GetUpdateEventHandler GetUpdateEvent;

        public IReadOnlyCollection<IEmployable> Employees => (IReadOnlyCollection<IEmployable>)this.employees;

        public IReadOnlyCollection<IJob> Tasks => (IReadOnlyCollection<IJob>)this.tasks;

        public Office()
        {
            this.employees = new List<IEmployable>();
            this.tasks = new List<IJob>();
        }

        public void AddEmployee(IEmployable employee)
        {
            this.employees.Add(employee);
        }

        public void AddTask(IJob task)
        {
            this.tasks.Add(task);
            this.GetStatusEvent += task.GetStatus;
            task.JobDoneEvent += this.OnJobDone;
            this.GetUpdateEvent += task.Update;
        }

        public void WeekPass()
        {
            this.GetUpdateEvent?.Invoke();
        }

        public void Status()
        {
            this.GetStatusEvent?.Invoke();
        }

        public void OnJobDone(object sender)
        {
            this.GetStatusEvent -= ((IJob)sender).GetStatus;
            this.GetUpdateEvent -= ((IJob)sender).Update;
            this.tasks.Remove((IJob)sender);
            Console.WriteLine($"Job {((IJob)sender).Name} done!");
        }
    }
}
