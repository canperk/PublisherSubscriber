using System;

namespace MSAB.PubSub.CanPerk.Common.Abstractions
{
    public interface IMessage
    {
        string Title { get; set; }
        string Content { get; set; }
        DateTime PublishDate { get; set; }
    }
}
