using System.Collections.Generic;

namespace MSAB.PubSub.CanPerk.Common.Abstractions
{
    public interface IPublisher
    {
        int MessageCount { get; set; }
        event PublishHandler OnAnnouncementPublished;
        event PublishHandler OnNewsPublished;
        event SubscriberHandler OnUnsubscribed;
        event SubscriberHandler OnSubscribed;
        void AddSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);
        void PublishAnnouncement(IMessage message);
        void PublishNews(IMessage message);
        IReadOnlyCollection<ISubscriber> Subscribers { get; }
    }
}
