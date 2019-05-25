using Messenger.BusinessLogic.Interfaces;
using Messenger.DataAccess.Interfaces;
using Messenger.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAll(string currentUserName)
        {
            List<User> users = await _userRepository.GetAll();
            users.Remove(users.Where(m => m.UserName == currentUserName).First());
            return users;
        }

        public async Task<string> GetIdByName(string name)
        {
            string userId = await _userRepository.GetIdByName(name);
            return userId;
        }

    }
}
