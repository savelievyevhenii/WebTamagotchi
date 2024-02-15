using WebTamagotchi.Dal.Entity;

namespace WebTamagotchi.Dal.Services;

public interface IUserService
{
    Task MakePlayer(User user);

    Task MakeAdministrator(User user);
}