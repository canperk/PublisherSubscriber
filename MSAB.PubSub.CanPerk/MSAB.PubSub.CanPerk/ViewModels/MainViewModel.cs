using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MSAB.PubSub.CanPerk.Common;
using MSAB.PubSub.CanPerk.Common.Abstractions;
using MSAB.PubSub.CanPerk.Pages;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MSAB.PubSub.CanPerk.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private int messageCount;
        private int subscriberCount;
        private bool isDialogOpen;
        private string notFoundMessage;
        public MainViewModel()
        {
            Publisher = new Publisher();
            Publisher.OnUnsubscribed += Publisher_OnUnsubscribed;
            Publisher.OnSubscribed += Publisher_OnSubscribed;
            Announcement = new AnnouncementViewModel();
            News = new NewsViewModel();
            PublishAnnouncement = new RelayCommand(PublishAnnouncementCommand, CanPublishAnnouncement, true);
            PublishNews = new RelayCommand(PublishNewsCommand, CanPublishNews);
            AddAnnouncementSubscriber = new RelayCommand(AddAnnouncementSubscriberCommand);
            AddNewsSubscriber = new RelayCommand(AddNewsSubscriberCommand);
            CloseDialog = new RelayCommand(CloseDialogCommand);
        }

        private bool CanPublishNews()
        {
            return !string.IsNullOrEmpty(News.Title) && !string.IsNullOrEmpty(News.Category);
        }

        private bool CanPublishAnnouncement()
        {
            return !string.IsNullOrEmpty(Announcement.Title);
        }

        public Publisher Publisher { get; set; }
        public AnnouncementViewModel Announcement { get; set; }
        public NewsViewModel News { get; set; }
        public int MessageCount
        {
            get => messageCount;
            set => Set(ref messageCount, value);
        }

        public int SubscriberCount
        {
            get => subscriberCount;
            set => Set(ref subscriberCount, value);
        }
        public string NotFoundMessage
        {
            get => notFoundMessage;
            set => Set(ref notFoundMessage, value);
        }
        public bool IsDialogOpen
        {
            get => isDialogOpen;
            set => Set(ref isDialogOpen, value);
        }

        #region Commands
        public ICommand PublishAnnouncement { get; private set; }
        public ICommand PublishNews { get; private set; }
        public ICommand AddAnnouncementSubscriber { get; private set; }
        public ICommand AddNewsSubscriber { get; private set; }
        public ICommand CloseDialog { get; private set; }

        #endregion

        #region Command Methods
        private void PublishAnnouncementCommand()
        {
            if (!Publisher.Subscribers.Any(i => i.SubscriberType == SubscriberType.Announcement))
            {
                IsDialogOpen = true;
                NotFoundMessage = "Any announcement subscriber not found";
                return;
            }

            Publisher.PublishAnnouncement(Announcement);
            MessageCount = Publisher.MessageCount;
            Announcement.Refresh();
        }
        private void PublishNewsCommand()
        {
            if (!Publisher.Subscribers.Any(i => i.SubscriberType == SubscriberType.News))
            {
                IsDialogOpen = true;
                NotFoundMessage = "Any news subscriber not found";
                return;
            }
         
            Publisher.PublishNews(News);
            MessageCount = Publisher.MessageCount;
            News.Refresh();
        }

        private void AddAnnouncementSubscriberCommand()
        {
            OpenNewSubscriber<AnnouncementWindow>();
        }
        private void AddNewsSubscriberCommand()
        {
            OpenNewSubscriber<NewsWindow>();
        }

        private void CloseDialogCommand()
        {
            IsDialogOpen = false;
        }
        #endregion

        private void OpenNewSubscriber<T>()
        {
            var subscriberWindow = Activator.CreateInstance(typeof(T), Publisher) as Window;
            subscriberWindow.Show();
        }

        private void Publisher_OnSubscribed(ISubscriber subscriber)
        {
            SubscriberCount++;
        }

        private void Publisher_OnUnsubscribed(ISubscriber subscriber)
        {
            SubscriberCount--;
        }
    }
}
