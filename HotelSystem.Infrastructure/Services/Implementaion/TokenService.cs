using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HotelSystem.Infrastructure.Services.Implementaion
{
    public class TokenService(IOptions<JwtSetting> jwtSetting) : ITokenService
    {
        public string GenerateAccessToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            foreach (var userRole in user.UserRoles)
            {
                if (!string.IsNullOrEmpty(userRole.Role?.Name))
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Value.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: jwtSetting.Value.Issuer,
                audience: jwtSetting.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSetting.Value.ExpireMinutes),
                signingCredentials: creds
           );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }



    }
}
