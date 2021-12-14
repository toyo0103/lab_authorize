using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lab_authorize.Models;
using lab_authorize.Policies;
using Microsoft.AspNetCore.Authorization;

namespace lab_authorize.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [PortalAuthorize(action: "bbs:list.posts",forAccountToken:ValidationMode.Basic, forUserToken:ValidationMode.Fully)]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Default()
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
