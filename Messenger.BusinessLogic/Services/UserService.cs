using Messenger.BusinessLogic.Interfaces;
using Messenger.DataAccess.Interfaces;
using Messenger.Entity;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<List<User>> GetAll()
        {
            List<User> users = await _userRepository.GetAll();
            return users;
        }
    }
}
