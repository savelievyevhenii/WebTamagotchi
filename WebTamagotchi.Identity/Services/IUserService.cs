using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetPlayers();
    
    Task<User> GetPlayer(string email);
    
    Task DeletePlayer(string email);
    
    Task<IEnumerable<User>> GetAdmins();
    
    Task<User> GetAdmin(string email);
    
    Task DeleteAdmin(string email);
    
    Task<User> ChangeRole(string email, Role role);
}