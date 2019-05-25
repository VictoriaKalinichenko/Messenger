using Messenger.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll(string currentUserName);
        Task<string> GetIdByName(string name);
    }
}
