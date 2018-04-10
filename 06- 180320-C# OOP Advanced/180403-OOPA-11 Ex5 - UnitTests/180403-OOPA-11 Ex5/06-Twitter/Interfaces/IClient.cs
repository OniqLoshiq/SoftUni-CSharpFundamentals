using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Twitter.Interfaces
{
    public interface IClient
    {
        void WriteMessage(string msg);
        void ArchiveMessageInServer(string msg);
    }
}
