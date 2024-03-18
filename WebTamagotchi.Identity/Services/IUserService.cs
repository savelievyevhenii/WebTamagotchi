using CSharpFunctionalExtensions;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services;

public interface IUserService
{
    Task<Result<User>> GetPlayer(string email);
    
    Task<Result> DeletePlayer(string email);
    
    Task<Result<User>> GetAdmin(string email);
    
    Task<Result> DeleteAdmin(string email);
    
    Task<Result<User>> ChangeRole(string email, Role role);
}