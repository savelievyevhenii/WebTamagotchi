using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Dal.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<User?> Get(string email, string password, CancellationToken cancellationToken);

    public Task<User> Find(string email, CancellationToken cancellationToken);

    public Task Update(User user, CancellationToken cancellationToken);
}