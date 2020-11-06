using Cassete_API.Models.User;
using Cassete_API.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Cassete_API.Repository.Services
{
    public class AccountService : IAccountService
    {
        private ApplicationContext _context;

        public AccountService(ApplicationContext context)
        {
            _context = context;
        }

        public ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(user => user.Login == username && user.Password == password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("name", user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };

                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
