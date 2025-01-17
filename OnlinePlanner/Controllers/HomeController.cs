﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlinePlanner.Models;

using Microsoft.Extensions.Configuration;

namespace OnlinePlanner.Controllers
{
    public class HomeController : Controller
    {
        //private static readonly IConfiguration _configuration;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index_LoggedIn()
        {
            return View();
        }

        public IActionResult Tasks()
        {
            return View();
        }

        public IActionResult Classes()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        //public ActionResult Login(SignIn user)
        //{
        //    Console.WriteLine(user);
        //    return 0;
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
