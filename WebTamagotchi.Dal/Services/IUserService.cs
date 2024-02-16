using WebTamagotchi.Dal.Entity;

namespace WebTamagotchi.Dal.Services;

public interface IUserService
{
    Task UpdateUserRole(User user, string fromRole ,string toRole);
}