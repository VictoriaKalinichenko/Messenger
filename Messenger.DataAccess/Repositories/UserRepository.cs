using Messenger.DataAccess.Interfaces;
using Messenger.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using System.Linq;
using System;
using Microsoft.Data.Sqlite;

namespace Messenger.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {


        public async Task<List<User>> GetAll()
        {
            try
            {
                List<User> users = new List<User>();

                using (var cnn = new SqliteConnection("Data Source=Messenger.UI.db"))
                {
                    users = (await cnn.QueryAsync<User>("select UserName, Id from AspNetUsers")).ToList();
                }

                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
