using MSAB.PubSub.CanPerk.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAB.PubSub.CanPerk.Concretes
{
    public class Message : IMessage
    {
        public string Title { get; set; }
        public string Content { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime PublishDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
