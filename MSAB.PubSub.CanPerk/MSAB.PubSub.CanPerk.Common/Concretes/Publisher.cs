﻿using MSAB.PubSub.CanPerk.Common.Abstractions;
using System;
using System.Collections.Generic;

namespace MSAB.PubSub.CanPerk.Common.Concretes
{
    public class Publisher : IPublisher
    {
        public Publisher()
        {
            messages = new List<IMessage>();
        }
        private List<IMessage> messages;
        public IReadOnlyCollection<IMessage> Messages { get { return messages.AsReadOnly(); } }

        public int MessageCount { get; set; }

        public event PublishHandler OnMessagePublished;

        public void AddSubscriber(ISubscriber subscriber)
        {
            subscriber.JoinDate = DateTime.Now;
            OnMessagePublished += subscriber.MessageRecieved;
            MessageCount++;
        }

        public void Publish(IMessage message)
        {
            message.PublishDate = DateTime.Now;
            OnMessagePublished?.Invoke(message);
            messages.Add(message);
        }
    }
}
