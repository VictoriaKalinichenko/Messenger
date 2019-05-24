namespace Messenger.Entity
{
  public class Message
  {
    public string SenderId { get; set; }
    public string SenderName { get; set; }
    public string ReceiverId { get; set; }
    public string ReceiverName { get; set; }
    public string Text { get; set; }
  }
}