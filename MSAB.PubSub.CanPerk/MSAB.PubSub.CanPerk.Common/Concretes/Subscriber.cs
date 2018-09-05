using MSAB.PubSub.CanPerk.Common.Abstractions;
using System;

namespace MSAB.PubSub.CanPerk.Common.Concretes
{
    public class Subscriber : ISubscriber
    {
        public Subscriber()
        {
            UniqueKey = Guid.NewGuid();
        }
        public DateTime JoinDate { get; set; }
        public Guid UniqueKey { get; set; }
        public SubscriberType SubscriberType { get; set; }

        public void MessageRecieved(IMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
