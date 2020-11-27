using Catto.Auth.Models;
using Catto.DataLib.Data;
using Catto.DataLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Catto.Auth.Services;

namespace Catto.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> logger;
        private AuthorizationService authService;

        public AuthController(AtomContextDB contextDB, IOptions<AuthOptions> authOptions, ILogger<AuthController> logger)
        {
            this.logger = logger;
            authService = new (authOptions, contextDB);
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(Credentials request)
        {
            logger.LogDebug($"Auth attempted {request.Login}");
            var user = authService.AuthenticateUser(request.Login, request.Password);
            if (user != null)
            {
                var token = authService.GenerateJWT(user);
                return Ok(new
                {
                    access_token = token
                });
            }
            return Ok(new
            {
                meow = "meooow"
            });
        }
    }
}
