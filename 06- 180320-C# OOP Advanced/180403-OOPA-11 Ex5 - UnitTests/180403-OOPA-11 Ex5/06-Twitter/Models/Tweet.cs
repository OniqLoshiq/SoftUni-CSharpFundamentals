using _06_Twitter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Twitter.Models
{
    public class Tweet : ITweet
    {
        private IClient client;

        public Tweet(IClient client)
        {
            this.client = client;
        }

        public void RetrieveMessage(string msg)
        {
            this.client.WriteMessage(msg);
            this.client.ArchiveMessageInServer(msg);
        }
    }
}
