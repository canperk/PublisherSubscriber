using MSAB.PubSub.CanPerk.Common;
using MSAB.PubSub.CanPerk.Common.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MSAB.PubSub.CanPerk.Pages
{
    public partial class SubscriberWindow : Window
    {
        public ISubscriber Subscriber { get; }
        public SubscriberType SubscriberType { get; }

        public SubscriberWindow(IPublisher publisher, SubscriberType subscriberType)
        {
            InitializeComponent();
            Messages = new ObservableCollection<string>();
            SubscriberType = subscriberType;
            Subscriber = new ClientSubscriber(Messages);
            publisher.AddSubscriber(Subscriber);
            DataContext = this;
        }
        public ObservableCollection<string> Messages { get; set; }
        private void Subscriber_MessageRecieved(IMessage message)
        {
            Messages.Add(message.Title);
        }

        private void ExitApp(object sender, RoutedEventArgs e)
        {
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

        class ClientSubscriber : ISubscriber
        {
            private readonly ObservableCollection<string> messages;

            public ClientSubscriber(ObservableCollection<string> messages)
            {
                this.messages = messages;
                UniqueKey = Guid.NewGuid();
            }
            public DateTime JoinDate { get; set; }
            public Guid UniqueKey { get; set; }

            public void MessageRecieved(IMessage message)
            {
                messages.Add(message.Title);
            }
        }
    }
}
