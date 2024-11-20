using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Helpers
{
    public static class HashPasswordHelper
    {
        public static string HashPassword(string paswword)
        {
            using (var sha256 = SHA256.Create())
            {
                var hasedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(paswword));
                var hash = BitConverter.ToString(hasedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
