using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSAB.PubSub.CanPerk.Common;

namespace MSAB.PubSub.CanPerk.Tests
{
    [TestClass]
    public class PubSubTest
    {
        [TestMethod]
        public void BroadcastMessagesTests()
        {
            var publisher = new Publisher();
            var subscriber1 = new Newspaper();
            var subscriber2 = new Radio();

            publisher.AddSubscriber(subscriber1);
            publisher.AddSubscriber(subscriber2);

            var message = new Message(MessageType.Announcement)
            {
                Title = "Test Message",
                Content = "Lorem ipsum dolor sit amelur..."
            };

            publisher.Publish(message);
            Assert.AreEqual(2, publisher.MessageCount);
        }
    }
}
