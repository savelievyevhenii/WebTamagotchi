﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services.Impl
{
    public class TokenService : ITokenService
    {
        private const int ExpirationMinutes = 30;
        private const int ExpirationDays = 90;
        private readonly IConfiguration _configuration;
        private readonly ILogger<TokenService> _logger;

        public TokenService(IConfiguration configuration, ILogger<TokenService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string CreateToken(ApplicationUser user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);
            var token = CreateJwtToken(CreateClaims(user), CreateSigningCredentials(), expiration);
            var tokenHandler = new JwtSecurityTokenHandler();

            _logger.LogInformation("JWT Token created");

            return tokenHandler.WriteToken(token);
        }
        
        public string GenerateRefreshToken(ApplicationUser user)
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            
            user.RefreshToken = Convert.ToBase64String(randomNumber);
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(ExpirationDays);

            _logger.LogInformation("Refresh Token created");

            return user.RefreshToken;
        }

        private JwtSecurityToken CreateJwtToken(IEnumerable<Claim> claims, SigningCredentials credentials, DateTime expiration)
        {
            var validIssuer = _configuration.GetValue<string>("JwtTokenSettings:ValidIssuer");
            var validAudience = _configuration.GetValue<string>("JwtTokenSettings:ValidAudience");

            return new JwtSecurityToken(
                validIssuer,
                validAudience,
                claims,
                expires: expiration,
                signingCredentials: credentials
            );
        }

        private IEnumerable<Claim> CreateClaims(ApplicationUser user)
        {
            var jwtSub = _configuration.GetValue<string>("JwtTokenSettings:JwtRegisteredClaimNamesSub");

            return new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, jwtSub ?? string.Empty),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.UserName ?? string.Empty),
                new(ClaimTypes.Email, user.Email ?? string.Empty),
                new(ClaimTypes.Role, user.Role.ToString())
            };
        }

        private SigningCredentials CreateSigningCredentials()
        {
            var symmetricSecurityKey = _configuration.GetValue<string>("JwtTokenSettings:SymmetricSecurityKey");

            return new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symmetricSecurityKey ?? string.Empty)),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}
