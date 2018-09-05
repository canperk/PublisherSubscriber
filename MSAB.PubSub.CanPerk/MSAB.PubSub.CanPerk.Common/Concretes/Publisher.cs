using MSAB.PubSub.CanPerk.Common.Abstractions;
using System;
using System.Collections.Generic;

namespace MSAB.PubSub.CanPerk.Common
{
    public class Publisher : IPublisher
    {
        private List<ISubscriber> subscribers = new List<ISubscriber>();

        public int MessageCount { get; set; }

        public IReadOnlyCollection<ISubscriber> Subscribers => subscribers.AsReadOnly();

        public event PublishHandler OnAnnouncementPublished;
        public event PublishHandler OnNewsPublished;
        public event SubscriberHandler OnUnsubscribed;
        public event SubscriberHandler OnSubscribed;

        public void AddSubscriber(ISubscriber subscriber)
        {
            subscriber.JoinDate = DateTime.Now;
            subscribers.Add(subscriber);
            switch (subscriber.SubscriberType)
            {
                case SubscriberType.Announcement:
                    OnAnnouncementPublished += subscriber.MessageRecieved;
                    break;
                case SubscriberType.News:
                    OnNewsPublished += subscriber.MessageRecieved;
                    break;
            }
            OnSubscribed?.Invoke(subscriber);
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
            switch (subscriber.SubscriberType)
            {
                case SubscriberType.Announcement:
                    OnAnnouncementPublished -= subscriber.MessageRecieved;
                    break;
                case SubscriberType.News:
                    OnNewsPublished -= subscriber.MessageRecieved;
                    break;
            }
            OnUnsubscribed?.Invoke(subscriber);
        }

        public void PublishAnnouncement(IMessage message)
        {
            if (message.MessageType != MessageType.Announcement)
            {
                return;
            }
            message.PublishDate = DateTime.Now;
            OnAnnouncementPublished?.Invoke(message);
            MessageCount++;
        }

        public void PublishNews(IMessage message)
        {
            if (message.MessageType != MessageType.News)
            {
                return;
            }
            message.PublishDate = DateTime.Now;
            OnNewsPublished?.Invoke(message);
            MessageCount++;
        }
    }
}
