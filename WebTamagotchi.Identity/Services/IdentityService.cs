using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Dal;
using WebTamagotchi.Dal.Entity;
using WebTamagotchi.Identity.Exceptions;
using WebTamagotchi.Identity.Extensions;
using WebTamagotchi.Identity.Interfaces;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly WebTamagotchiDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public IdentityService(ITokenService tokenService, WebTamagotchiDbContext context,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _context = context;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        public async Task<AuthResponse> Authenticate(AuthRequest request)
        {
            var managedUser = await _userManager.FindByEmailAsync(request.Email)
                              ?? throw new UserNotFoundException(request.Email);

            if (!await _userManager.CheckPasswordAsync(managedUser, request.Password))
            {
                throw new PasswordValidationException();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email)
                       ?? throw new UnauthorizedAccessException();

            var roleIds = await _context.UserRoles
                .Where(r => r.UserId == user.Id)
                .Select(x => x.RoleId)
                .ToListAsync();

            var roles = _context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();

            var accessToken = _tokenService.CreateToken(user, roles);

            user.RefreshToken = _configuration.GenerateRefreshToken();
            user.RefreshTokenExpiryTime =
                DateTime.UtcNow.AddDays(_configuration.GetValue<int>("Jwt:RefreshTokenValidityInDays"));

            await _context.SaveChangesAsync();

            return new AuthResponse
            {
                Username = user.UserName!,
                Email = user.Email!,
                Token = accessToken,
                RefreshToken = user.RefreshToken
            };
        }

        public async Task<AuthRequest> Register(RegistrationRequest request)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email)
                           ?? throw new UserNotFoundException(request.Email);

            await _userManager.AddToRoleAsync(findUser, RolesConstants.Player);

            return new AuthRequest
            {
                Email = request.Email,
                Password = request.Password
            };
        }

        public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
        {
            if (tokenModel is null)
            {
                throw new Exception("Invalid client request");
            }

            var accessToken = tokenModel.AccessToken;
            var refreshToken = tokenModel.RefreshToken;

            var principal = _configuration.GetPrincipalFromExpiredToken(accessToken)
                            ?? throw new Exception("Invalid access token or refresh token");

            var username = principal.Identity!.Name;
            var user = await _userManager.FindByNameAsync(username!)
                       ?? throw new Exception("Invalid access token or refresh token");

            if (user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new Exception("Invalid access token or refresh token");
            }

            var newAccessToken = _configuration.CreateToken(principal.Claims.ToList());
            var newRefreshToken = _configuration.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            var result = new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            };

            return new ObjectResult(result);
        }

        public async Task Revoke(string username)
        {
            var user = await _userManager.FindByNameAsync(username)
                       ?? throw new Exception("Invalid user name");

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
        }

        public async Task RevokeAll()
        {
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }
        }
    }
}