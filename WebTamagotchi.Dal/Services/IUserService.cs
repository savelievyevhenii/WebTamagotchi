using WebTamagotchi.Dal.Entity;

namespace WebTamagotchi.Dal.Services;

public interface IUserService
{
    Task Insert(User user);
}