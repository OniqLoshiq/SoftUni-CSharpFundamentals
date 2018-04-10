using _06_Twitter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Twitter.Models
{
    public class MicrowaveOven : IClient
    {
        private IWriter writer;
        private IRepository repostory;

        public MicrowaveOven(IWriter writer, IRepository repostory)
        {
            this.writer = writer;
            this.repostory = repostory;
        }

        public void ArchiveMessageInServer(string msg)
        {
            this.repostory.ArchiveMessage(msg);
        }

        public void WriteMessage(string msg)
        {
            this.writer.WriteLine(msg);
        }
    }
}
