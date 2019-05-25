using Messenger.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<string> GetIdByName(string userName);
        Task<string> GetName(string userId);
    }
}
