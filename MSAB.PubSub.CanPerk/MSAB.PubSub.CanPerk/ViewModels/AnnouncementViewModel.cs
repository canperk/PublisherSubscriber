using GalaSoft.MvvmLight;
using MSAB.PubSub.CanPerk.Common;
using MSAB.PubSub.CanPerk.Common.Abstractions;
using System;

namespace MSAB.PubSub.CanPerk.ViewModels
{
    public class AnnouncementViewModel : ObservableObject, IMessage, IReusable
    {
        private string title;
        private string content;
        public AnnouncementViewModel()
        {
            MessageType = MessageType.Announcement;
        }
        public string Title { get { return title; } set { Set(ref title, value); } }
        public string Content { get { return content; } set { Set(ref content, value); } }
        public DateTime PublishDate { get; set; }
        public MessageType MessageType { get; set; }

        public void Refresh()
        {
            Title = string.Empty;
            Content = string.Empty;
        }
    }
}
