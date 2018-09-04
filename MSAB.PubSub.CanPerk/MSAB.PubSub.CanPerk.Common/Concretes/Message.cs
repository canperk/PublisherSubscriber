using MSAB.PubSub.CanPerk.Common.Abstractions;
using System;

namespace MSAB.PubSub.CanPerk.Common
{
    public class Message : IMessage
    {
        public Message(MessageType messageType)
        {
            MessageType = messageType;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public MessageType MessageType { get; set; }
    }
}
