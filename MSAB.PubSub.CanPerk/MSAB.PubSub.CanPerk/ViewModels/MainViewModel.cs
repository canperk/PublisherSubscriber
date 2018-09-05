using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MSAB.PubSub.CanPerk.Common;
using MSAB.PubSub.CanPerk.Common.Concretes;
using MSAB.PubSub.CanPerk.Pages;
using System.Windows.Input;

namespace MSAB.PubSub.CanPerk.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private int messageCount;
        public MainViewModel()
        {
            Publisher = new Publisher();
            Announcement = new AnnouncementViewModel();
            News = new NewsViewModel();
            PublishAnnouncement = new RelayCommand(PublishAnnouncementCommand);
            PublishNews = new RelayCommand(PublishNewsCommand);
            AddNewsPaper = new RelayCommand(AddNewsPaperCommand);
            AddRadio = new RelayCommand(AddRadioCommand);
            AddMobileDevice = new RelayCommand(AddMobileDeviceCommand);
            AddInternet = new RelayCommand(AddInternetCommand);
        }
        public AnnouncementViewModel Announcement { get; set; }
        public NewsViewModel News { get; set; }
        public int MessageCount
        {
            get { return messageCount; }
            set { Set(ref messageCount, value); }
        }
        public Publisher Publisher { get; set; }

        #region Commands
        public ICommand PublishAnnouncement { get; private set; }
        public ICommand PublishNews { get; private set; }
        public ICommand AddNewsPaper { get; private set; } 
        public ICommand AddRadio { get; private set; } 
        public ICommand AddMobileDevice { get; private set; } 
        public ICommand AddInternet { get; private set; }
        #endregion
        #region Command Methods
        private void PublishAnnouncementCommand()
        {
            Publisher.Publish(Announcement);
            MessageCount = Publisher.MessageCount;
            Announcement.Refresh();
        }
        private void PublishNewsCommand()
        {
            Publisher.Publish(News);
            MessageCount = Publisher.MessageCount;
            News.Refresh();
        }

        private void AddNewsPaperCommand()
        {
            var subscriberWindow = new SubscriberWindow(Publisher, SubscriberType.Newspaper);
            subscriberWindow.Show();
            
        }
        private void AddRadioCommand()
        {
            MessageCount++;

        }
        private void AddMobileDeviceCommand()
        {
            MessageCount++;

        }
        private void AddInternetCommand()
        {
            MessageCount++;

        }
        #endregion
    }
}
