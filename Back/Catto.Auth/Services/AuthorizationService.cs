using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catto.DataLib.Models;
using Catto.DataLib.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Catto.Auth.Services
{
    public class AuthorizationService
    {
        private IOptions<AuthOptions> authOptions;
        private AtomContextDB db;

        public AuthorizationService(IOptions<AuthOptions> authOptions, AtomContextDB databaseContext)
        {
            this.authOptions = authOptions;
            this.db = databaseContext;
        }

        public Account AuthenticateUser(string login, string password)
        {
            return db.Accounts.SingleOrDefault(u => u.Login == login && u.Password == password);
        }

        public string GenerateJWT(Account user)
        {
            var authParams = authOptions.Value;
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
