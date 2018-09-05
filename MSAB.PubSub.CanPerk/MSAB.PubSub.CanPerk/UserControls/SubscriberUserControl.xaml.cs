using MSAB.PubSub.CanPerk.Common;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MSAB.PubSub.CanPerk.UserControls
{
    public partial class SubscriberUserControl : UserControl
    {
        public SubscriberUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(SubscriberUserControl), new FrameworkPropertyMetadata(string.Empty));

        public string Title
        {
            get { return GetValue(TitleProperty).ToString(); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(SubscriberUserControl), new FrameworkPropertyMetadata(string.Empty));

        public string Message
        {
            get { return GetValue(MessageProperty).ToString(); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(SubscriberUserControl), new UIPropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    }
}