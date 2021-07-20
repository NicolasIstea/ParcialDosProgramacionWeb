using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class PasswordSecurity : IPasswordSecurity
    {
        public bool CheckPassword(string salt, string password, string passwordHashed)
        {

            string hash = HashPassword(password, salt);

            if(hash == passwordHashed)
            {
                return true;
            }

            return false;
        }

        public string GenerateSalt(int nSalt = 16)
        {
            var saltBytes = new byte[nSalt];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public string HashPassword(string password, string salt, int nIterations = 10000, int nHash = 16)
        {
            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }
        }
    }
}
