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

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetList ()
    {
      List<User> users = await _userService.GetAll();
      return Ok(users);
    }
  }
}