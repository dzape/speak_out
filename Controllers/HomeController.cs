using System.Diagnostics;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using speak_out.Models;

namespace speak_out.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Users> _userManager;
       // private Task<Users> GetCurrentUserAsync() => _manager.GetUserAsync(HttpContext.User);
       
        public HomeController(ILogger<HomeController> logger/*, UserManager<Users> manager*/)
        {
            _logger = logger;
           //_userManager = manager;
        }

    //[HttpGet]
    //public async Task<string> GetCurrentUser()
    //{
    //    Users usr = await GetCurrentUserAsync();
    //    return usr?.UserName;
    //}

    //public HomeController(IHttpContextAccessor httpContextAccessor)
    //{
    //    var user = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
    //}

    //private async Task<Users> GetCurrentUser()
    //{
    //    return await _manager.GetUserAsync(HttpContext.User);
    //}

    //public async Task<IActionResult> IndexAsync()
    //    {
    //        ViewBag.UserID = _userManager.GetUserId(HttpContext.User);
    //            var user = await _userManager;
    //        return View();
    //    }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Messenger()
        {
            return View();
        }

        public IActionResult Home()
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
