using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSAB.PubSub.CanPerk.Common;
using MSAB.PubSub.CanPerk.Common.Abstractions;
using System;

namespace MSAB.PubSub.CanPerk.Tests
{
    [TestClass]
    public class PubSubTest
    {
        [TestMethod]
        public void BroadcastMessagesTests()
        {
            var publisher = new Publisher();
            var subscriber1 = new News();
            var subscriber2 = new Announcement();

            publisher.AddSubscriber(subscriber1);
            publisher.AddSubscriber(subscriber2);

            var message = new Message(MessageType.Announcement)
            {
                Title = "Test Message",
                Content = "Lorem ipsum dolor sit amelur..."
            };

            publisher.PublishAnnouncement(message);
            Assert.AreEqual(1, publisher.MessageCount);
        }
    }

    public class News : ISubscriber
    {
        public News()
        {
            UniqueKey = Guid.NewGuid();
        }
        public DateTime JoinDate { get; set; }
        public Guid UniqueKey { get; set; }
        public SubscriberType SubscriberType { get; set; }

        public void MessageRecieved(IMessage message)
        {

        }
    }

    public class Announcement : ISubscriber
    {
        public Announcement()
        {
            UniqueKey = Guid.NewGuid();
        }
        public DateTime JoinDate { get; set; }
        public Guid UniqueKey { get; set; }
        public SubscriberType SubscriberType { get; set; }

        public void MessageRecieved(IMessage message)
        {

        }
    }
}
