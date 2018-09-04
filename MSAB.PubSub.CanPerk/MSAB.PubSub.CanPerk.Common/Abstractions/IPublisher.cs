using System.Collections.Generic;

namespace MSAB.PubSub.CanPerk.Common.Abstractions
{
    public interface IPublisher
    {
        int MessageCount { get; }
        event PublishHandler OnMessagePublished;
        void AddSubscriber(ISubscriber subscriber);
        void Publish(IMessage message);
        IReadOnlyCollection<IMessage> Messages { get; }
    }
}
