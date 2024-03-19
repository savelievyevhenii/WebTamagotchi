using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Dal.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);

    Task<User?> Get(string email, string password, CancellationToken cancellationToken);

    Task<User> Find(string email, CancellationToken cancellationToken);

    Task Update(User user, CancellationToken cancellationToken);
}