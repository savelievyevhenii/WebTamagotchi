using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.Identity.Exceptions;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Dal.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WebTamagotchiDbContext _context;

    public UserRepository(WebTamagotchiDbContext context)
    {
        _context = context;
    }

    public Task<User?> Get(string email, string password, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<User> Find(string email, CancellationToken cancellationToken)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email)!;
    }

    public async Task Update(User user, CancellationToken cancellationToken)
    {
        _context.Users.Update(user);
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}