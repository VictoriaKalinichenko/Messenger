using Messenger.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
    }
}
