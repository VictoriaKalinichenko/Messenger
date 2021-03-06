﻿using Messenger.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetList(string senderId, string receiverId);
        Task Insert(Message message);
    }
}
