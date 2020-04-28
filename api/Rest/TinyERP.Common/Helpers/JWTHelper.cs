namespace TinyERP.Common.Helpers
{
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    public static class JWTHelper
    {
        public static string CreateTokenWithSercetKey(string userName, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            ClaimsIdentity subject = new ClaimsIdentity("AuthorizationCode", "GrandType", "admin");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName, "", "", "", subject)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                Audience= "http://localhost:3000",
                Issuer= "http://testlocalhost.api/api",
                IssuedAt = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
