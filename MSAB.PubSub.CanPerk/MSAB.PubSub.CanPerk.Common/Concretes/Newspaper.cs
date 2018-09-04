using MSAB.PubSub.CanPerk.Common.Abstractions;
using System;

namespace MSAB.PubSub.CanPerk.Common
{
    public class Newspaper : ISubscriber
    {
        public Newspaper()
        {
            UniqueKey = Guid.NewGuid();
        }
        public DateTime JoinDate { get; set; }
        public Guid UniqueKey { get; set; }

        public void MessageRecieved(IMessage message)
        {
            
        }
    }

    public class Radio : ISubscriber
    {
        public Radio()
        {
            UniqueKey = Guid.NewGuid();
        }
        public DateTime JoinDate { get; set; }
        public Guid UniqueKey { get; set; }

        public void MessageRecieved(IMessage message)
        {
            
        }
    }
}
