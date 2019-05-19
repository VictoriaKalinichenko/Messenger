using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Messenger.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Messenger.BusinessLogic.Interfaces;
using Messenger.Entity;

namespace Messenger.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController (IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            List<User> users = await _userService.GetAll();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
