using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAB.PubSub.CanPerk.Abstractions
{
    public interface IPublisher
    {
        event PublishHandler OnMessagePublished;
        void AddSubscriber(ISubscriber subscriber);
        void Publish(IMessage message);
        IReadOnlyCollection<IMessage> Messages { get; set; }
    }

    public interface ISubscriber
    {
        SubscriberType Type { get; set; }
        DateTime JoinDate { get; set; }
        Guid UniqueKey { get; set; }
        void MessageRecieved(IMessage message);
    }

    public delegate void PublishHandler(IMessage message);
}
