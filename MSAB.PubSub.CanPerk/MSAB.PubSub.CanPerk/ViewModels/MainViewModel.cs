using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MSAB.PubSub.CanPerk.Common;
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
        }
        public AnnouncementViewModel Announcement { get; set; }
        public NewsViewModel News { get; set; }
        public int MessageCount
        {
            get { return messageCount; }
            set { Set(ref messageCount, value); }
        }

        public ICommand PublishAnnouncement { get; private set; }
        public ICommand PublishNews { get; private set; }
        public Publisher Publisher { get; set; }

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
    }
}
