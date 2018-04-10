using _06_Twitter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Twitter.Repository
{
    public class TweetRepo : IRepository
    {
        private List<string> storage;

        public IReadOnlyCollection<string> Storage => this.storage.AsReadOnly();

        private int msgCounter;

        public TweetRepo()
        {
            this.storage = new List<string>();
            this.msgCounter = 0;
        }

        public void ArchiveMessage(string msg)
        {
            msgCounter++;
            string tweetToAdd = $"{msgCounter:f2}. {msg}";
            this.storage.Add(tweetToAdd);
        }
    }
}
