using System;

namespace MSAB.PubSub.CanPerk.Common.Abstractions
{
    public interface ISubscriber
    {
        DateTime JoinDate { get; set; }
        Guid UniqueKey { get; set; }
        void MessageRecieved(IMessage message);
    }
}
