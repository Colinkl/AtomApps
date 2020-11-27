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

namespace Catto.Auth.Controllers
{
    [Route("auth/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AtomContextDB db;
        private readonly ILogger<AuthController> logger;

        public AuthController( AtomContextDB contextDB, IOptions<AuthOptions> authOptions, ILogger<AuthController> logger)
        {
            db = contextDB;
            _authOptions = authOptions;
            this.logger = logger;
        }

        private IOptions<AuthOptions> _authOptions { get; }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(Credentials request)
        {
            logger.LogDebug($"Auth attempted {request.Login}");
            var user = AuthenticateUser(request.Login, request.Password);
            if (user != null)
            {
                var token = GenerateJWT(user);
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

        private  Account AuthenticateUser(string login, string password)
        {
            return db.Accounts.SingleOrDefault(u => u.Login == login && u.Password == password);
        }

        private string GenerateJWT(Account user)
        {
            var authParams = _authOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.EmployeeId.ToString()),
                new Claim(ClaimTypes.Role, db.Employees.Find(user.EmployeeId).Role.ToString())
            };

            var token = new JwtSecurityToken(authParams.Issuer, 
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
