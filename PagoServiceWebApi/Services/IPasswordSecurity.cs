using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPasswordSecurity
    {
        string GenerateSalt(int nSalt = 16);
        string HashPassword(string password, string salt, int nIterations = 10000, int nHash = 16);
        bool CheckPassword(string salt, string password, string passwordHashed);
    }
}
