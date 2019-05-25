using Messenger.DataAccess.Interfaces;
using Messenger.Entity;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Messenger.BusinessLogic.Hubs
{
    public class MessengerHub : Hub
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public MessengerHub(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        public async Task SendMessage(string senderId, string receiverId, string text)
        {
            Message message = new Message();
            message.ReceiverId = receiverId;
            message.ReceiverName = await _userRepository.GetName(receiverId);
            message.SenderId = senderId;
            message.SenderName = await _userRepository.GetName(senderId);
            message.Text = text;

            await _messageRepository.Insert(message);
            await Clients.User(receiverId).SendAsync("ReceiveMessage", senderId, text);
        }
    }
}
