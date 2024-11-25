using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Models;
using School.Domain.ModelsDb;

namespace School.Domain.Helpers
{
    public static class AuthenticateUserHelper
    {
        public static ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
                new Claim("AvatarPatch", user.PathImage),
            };
            return new ClaimsIdentity(claims, "AplicationCookie",
                ClaimTypes.Email, ClaimsIdentity.DefaultRoleClaimType);
        }

        public static ClaimsIdentity Authenticate(UserDb userdb)
        {
            throw new NotImplementedException();
        }
    }
}
