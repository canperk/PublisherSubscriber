using MSAB.PubSub.CanPerk.Common;
using MSAB.PubSub.CanPerk.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MSAB.PubSub.CanPerk.Pages
{
    /// <summary>
    /// Interaction logic for NewsWindow.xaml
    /// </summary>
    public partial class NewsWindow : Window
    {
        private readonly IPublisher publisher;

        public ISubscriber Subscriber { get; }
        public ObservableCollection<string> Messages { get; set; }

        public NewsWindow(IPublisher publisher)
        {
            InitializeComponent();
            Messages = new ObservableCollection<string>();
            Subscriber = new NewsSubscriber(Messages)
            {
                SubscriberType = SubscriberType.News
            };
            publisher.AddSubscriber(Subscriber);
            DataContext = this;
            this.publisher = publisher;
        }

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
