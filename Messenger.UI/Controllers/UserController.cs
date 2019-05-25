using Messenger.BusinessLogic.Interfaces;
using Messenger.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public UserController(IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            string currentUserName = HttpContext.User.Identity.Name;
            List<User> users = await _userService.GetAll(currentUserName);
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessageList(string senderId, string receiverId)
        {
            List<Message> messages = await _messageService.GetList(senderId, receiverId);
            return Ok(messages);
        }
    }
}