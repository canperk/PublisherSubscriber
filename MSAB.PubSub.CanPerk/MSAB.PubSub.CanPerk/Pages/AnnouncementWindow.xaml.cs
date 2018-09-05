using MSAB.PubSub.CanPerk.Common;
using MSAB.PubSub.CanPerk.Common.Abstractions;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MSAB.PubSub.CanPerk.Pages
{
    public partial class AnnouncementWindow : Window
    {
        private readonly IPublisher publisher;

        public ISubscriber Subscriber { get; }

        public AnnouncementWindow(IPublisher publisher)
        {
            InitializeComponent();
            Messages = new ObservableCollection<string>();
            Subscriber = new AnnouncementSubscriber(Messages)
            {
                SubscriberType = SubscriberType.Announcement
            };
            publisher.AddSubscriber(Subscriber);
            DataContext = this;
            this.publisher = publisher;
        }
        public ObservableCollection<string> Messages { get; set; }
        private void Subscriber_MessageRecieved(IMessage message)
        {
            Messages.Add(message.Title);
        }

        private void CloseForm(object sender, RoutedEventArgs e)
        {
            publisher.RemoveSubscriber(Subscriber);
            Close();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        
    }
}
