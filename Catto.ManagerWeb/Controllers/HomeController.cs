using Catto.ManagerWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Catto.DataLib.Models;
using Catto.Auth.Controllers;
using Catto.Auth.Services;
using Catto.DataLib.Data;
using Microsoft.Extensions.Options;


namespace Catto.ManagerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AuthorizationService authService;

        public HomeController(AtomContextDB contextDB, IOptions<AuthOptions> authOptions, ILogger<HomeController> logger)
        {
            authService = new(authOptions, contextDB);
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string Login(Account account)
        {
            var user = authService.AuthenticateUser(account.Login, account.Password);
            if (user != null)
            {
                var token = authService.GenerateJWT(user);
                HttpContext.Response.Headers.Add("Authorization", "Bearer" + token);
            }
            return "Авторизован";
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
