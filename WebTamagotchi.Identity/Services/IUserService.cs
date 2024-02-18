using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    
    Task<User> GetUser(string email);
    
    Task DeleteUser(string email);
    
    Task<User> ChangeRole(string email, Role role);
}