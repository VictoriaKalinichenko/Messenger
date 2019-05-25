using Messenger.BusinessLogic.Interfaces;
using Messenger.DataAccess.Interfaces;
using Messenger.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.BusinessLogic.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<List<Message>> GetList(string senderId, string receiverId)
        {
            List<Message> messages = await _messageRepository.GetList(senderId, receiverId);
            return messages;
        }
    }
}
