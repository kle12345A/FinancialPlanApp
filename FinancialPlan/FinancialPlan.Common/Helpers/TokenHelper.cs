using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Common.Helpers
{
    public class TokenHelper
    {
        public static async Task<string> GenerateAccessToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String("JWT:SecretKey");

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userId.ToString())
            });

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = "JWT:Issuer",
                Audience = "JWT:Audience",
                Expires = DateTime.Now.AddMinutes("JWT:Expires".GetIntFromString()),
                SigningCredentials = signingCredentials
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return await Task.Run(() => tokenHandler.WriteToken(securityToken));
        }

        public static async Task<string> GenerateRefreshToken()
        {
            var securityRandomBytes = new byte[32];

            using var randomNumberGenerator = RandomNumberGenerator.Create();

            await Task.Run(() => randomNumberGenerator.GetBytes(securityRandomBytes));

            var refreshToken = Convert.ToBase64String(securityRandomBytes);

            return refreshToken;
        }
    }
}
