using Dapper;
using Dapper.Contrib.Extensions;
using Messenger.DataAccess.Interfaces;
using Messenger.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public async Task<List<Message>> GetList(string senderId, string receiverId)
        {
            string sql = $@"select * from Message 
                            where (SenderId = '{senderId}' and ReceiverId = '{receiverId}') 
                            or (SenderId = '{receiverId}' and ReceiverId = '{senderId}')";

            try
            {
                List<Message> messageList = new List<Message>();

                using (var cnn = new SqliteConnection("Data Source=MessageDataBase.db"))
                {
                    messageList = (await cnn.QueryAsync<Message>(sql)).ToList();
                }

                return messageList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Insert(Message message)
        {
            try
            {
                using (var cnn = new SqliteConnection("Data Source=MessageDataBase.db"))
                {
                    await cnn.InsertAsync(message);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
