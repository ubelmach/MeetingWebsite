using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MeetingWebsite.BLL.Builders
{
    public class JwtSecurityTokenBuilder
    {
        private readonly SecurityTokenDescriptor _tokenDescriptor;
        private readonly string _claimType = "UserID";

        public JwtSecurityTokenBuilder()
        {
            _tokenDescriptor = new SecurityTokenDescriptor();
        }

        public JwtSecurityTokenBuilder Subject(string userId)
        {
            _tokenDescriptor.Subject = new ClaimsIdentity(new[]
            {
                new Claim(_claimType, userId)
            });
            return this;
        }

        public JwtSecurityTokenBuilder ExpiresInOneDay()
        {
            _tokenDescriptor.Expires = DateTime.UtcNow.AddDays(1);
            return this;
        }

        public JwtSecurityTokenBuilder SigningCredentials(string securityKey)
        {
            _tokenDescriptor.SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)), SecurityAlgorithms.HmacSha256Signature);
            return this;
        }

        public string Build()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(_tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}