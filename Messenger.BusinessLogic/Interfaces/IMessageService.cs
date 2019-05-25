using Messenger.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.BusinessLogic.Interfaces
{
    public interface IMessageService
    {
        Task<List<Message>> GetList(string senderId, string receiverId);
    }
}
