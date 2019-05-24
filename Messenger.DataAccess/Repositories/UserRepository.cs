using Dapper;
using Messenger.DataAccess.Interfaces;
using Messenger.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    public async Task<string> GetIdByName(string userName)
    {
      try
      {
        string id = string.Empty;

        using (var cnn = new SqliteConnection("Data Source=Messenger.UI.db"))
        {
          id = (await cnn.QueryAsync<string>($"select Id from AspNetUsers where userName = '{userName}'")).FirstOrDefault();
        }

        return id;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}
