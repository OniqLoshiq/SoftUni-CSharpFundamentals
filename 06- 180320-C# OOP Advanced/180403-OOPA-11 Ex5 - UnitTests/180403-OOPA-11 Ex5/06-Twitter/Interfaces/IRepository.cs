using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Twitter.Interfaces
{
    public interface IRepository
    {
        IReadOnlyCollection<string> Storage { get; }
        void ArchiveMessage(string msg);
    }
}
