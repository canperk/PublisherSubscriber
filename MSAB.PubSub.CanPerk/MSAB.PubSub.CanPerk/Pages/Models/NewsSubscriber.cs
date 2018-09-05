using MSAB.PubSub.CanPerk.Common;
using MSAB.PubSub.CanPerk.Common.Abstractions;
using MSAB.PubSub.CanPerk.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace MSAB.PubSub.CanPerk.Pages
{
    public class NewsSubscriber : ISubscriber
    {
        private readonly ObservableCollection<string> messages;

        public NewsSubscriber(ObservableCollection<string> messages)
        {
            this.messages = messages;
            UniqueKey = Guid.NewGuid();
        }
        public DateTime JoinDate { get; set; }
        public Guid UniqueKey { get; set; }
        public SubscriberType SubscriberType { get; set; }

        public void MessageRecieved(IMessage message)
        {
            var news = message as NewsViewModel;
            messages.Add(news.Title + " - " + news.Category);
        }
    }
}
