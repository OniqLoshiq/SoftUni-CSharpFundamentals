using _06_Twitter.Interfaces;
using _06_Twitter.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class TwitterTest
    {
        private const string Msg = "Proba";

        [Test]
        public void TestMicrowaveOven_ArchiveMessageMethod()
        {
            Mock<IWriter> writer = new Mock<IWriter>();
            Mock<IRepository> repo = new Mock<IRepository>();

            IClient microwave = new MicrowaveOven(writer.Object, repo.Object);

            microwave.ArchiveMessageInServer(Msg);

            repo.Verify(x => x.ArchiveMessage(It.Is<string>(s => s == Msg)), Times.Once, "The given message was not stored in the repository");
        }

        [Test]
        public void TestMicrowaveOven_WriteMessageMethod()
        {
            Mock<IWriter> writer = new Mock<IWriter>();
            Mock<IRepository> repo = new Mock<IRepository>();

            IClient microwave = new MicrowaveOven(writer.Object, repo.Object);

            microwave.WriteMessage(Msg);

            writer.Verify(w => w.WriteLine(It.Is<string>(s => s == Msg)), Times.Once, "Message hasn't been sent!");
        }

        [Test]
        public void TestTweet_ReceiveMessageMethod()
        {
            Mock<IClient> client = new Mock<IClient>();

            Tweet tweet = new Tweet(client.Object);

            tweet.RetrieveMessage(Msg);

            client.Verify(c => c.ArchiveMessageInServer(It.Is<string>(s => s == Msg)), Times.Once, "Tweet doesn't invoke client's archive method");
            client.Verify(c => c.WriteMessage(It.Is<string>(s => s == Msg)), Times.Once, "Tweet doesn't invoke client's write methid");
        }
    }
}
