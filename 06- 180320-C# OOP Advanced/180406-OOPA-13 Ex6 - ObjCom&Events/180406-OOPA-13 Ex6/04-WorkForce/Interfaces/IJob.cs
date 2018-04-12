using System;
using System.Collections.Generic;
using System.Text;

namespace _04_WorkForce.Interfaces
{
    public delegate void JobDoneEnventHandler(object sender);

    public interface IJob : INamable
    {
        event JobDoneEnventHandler JobDoneEvent;
        int RemainingHours { get; }
        void Update();
        IEmployable Employee { get; }
        void GetStatus();
    }
}
