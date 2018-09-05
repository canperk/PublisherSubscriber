namespace MSAB.PubSub.CanPerk.Common.Abstractions
{
    public delegate void PublishHandler(IMessage message);
    public delegate void SubscriberHandler(ISubscriber subscriber);
}
