using GalaSoft.MvvmLight;
using MSAB.PubSub.CanPerk.Common;
using MSAB.PubSub.CanPerk.Common.Abstractions;
using System;
using System.Collections.ObjectModel;

namespace MSAB.PubSub.CanPerk.ViewModels
{
    public class NewsViewModel : ObservableObject, IMessage, IReusable
    {
        private string title;
        private string content;
        private string category;

        public NewsViewModel()
        {
            MessageType = MessageType.News;
        }
        public string Title { get => title; set => Set(ref title, value); }
        public string Content { get => content; set => Set(ref content, value); }
        public DateTime PublishDate { get; set; }
        public MessageType MessageType { get; set; }
        public string Category { get => category; set => Set(ref category, value); }
        public ObservableCollection<string> Categories => new ObservableCollection<string>
        {
            "Economy",
            "Politics",
            "Sport",
            "Travelling",
            "Business",
            "Technology"
        };

        public void Refresh()
        {
            Title = null;
            Content = null;
            Category = null;
        }
    }
}
