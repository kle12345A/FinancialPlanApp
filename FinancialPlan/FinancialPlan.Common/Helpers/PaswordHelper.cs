using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Common.Helpers
{
    public class PasswordHelper
    {
        public static byte[] GetSecuritySalt()
        {
            return RandomNumberGenerator.GetBytes(32);
        }

        public static string HashUsingPbkdf2(string password, byte[] salt)
        {
            byte[] derivedKey = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, iterationCount: 500000, 32);

            return Convert.ToBase64String(derivedKey);
        }
    }
}
