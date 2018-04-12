using System;
using System.Collections.Generic;
using System.Text;

namespace _04_WorkForce.Interfaces
{
    public delegate void GetStatusEventHandler();
    public delegate void GetUpdateEventHandler();

    public interface IOffice
    {
        event GetStatusEventHandler GetStatusEvent;
        event GetUpdateEventHandler GetUpdateEvent;
        IReadOnlyCollection<IEmployable> Employees { get; }
        IReadOnlyCollection<IJob> Tasks { get; }

        void AddTask(IJob task);
        void AddEmployee(IEmployable employee);
        void WeekPass();
        void Status();
        void OnJobDone(object sender);
    }
}
