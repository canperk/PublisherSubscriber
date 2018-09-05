using MSAB.PubSub.CanPerk.Common;
using MSAB.PubSub.CanPerk.Common.Abstractions;
using MSAB.PubSub.CanPerk.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace MSAB.PubSub.CanPerk.Pages
{
    public class AnnouncementSubscriber : ISubscriber
    {
        private readonly ObservableCollection<string> messages;

        public AnnouncementSubscriber(ObservableCollection<string> messages)
        {
            this.messages = messages;
            UniqueKey = Guid.NewGuid();
        }
        public DateTime JoinDate { get; set; }
        public Guid UniqueKey { get; set; }
        public SubscriberType SubscriberType { get; set; }

        public void MessageRecieved(IMessage message)
        {
            var announcement = message as AnnouncementViewModel;
            messages.Add(announcement.Title);
        }
    }
}
