using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Entity
{
    [Table("Message")]
    public class Message
    {
        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string Text { get; set; }
    }
}