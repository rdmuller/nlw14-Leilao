using Microsoft.EntityFrameworkCore;
using RocketAuction.Domain.Entities;
using RocketAuction.Domain.Repositories.Users;

namespace RocketAuction.Infra.DataAccess.Repositories;
internal class UserRepository : IUserReadOnlyRepository
{
    private readonly RocketAuctionDbContext _dbContext;

    public UserRepository(RocketAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> ExistUserWithEmail(string email)
    {
        return await _dbContext.Users.AsNoTracking().AnyAsync(u => u.Email.Equals(email));
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _dbContext.Users.AsNoTracking().FirstAsync(u => u.Email.Equals(email));
    }
}
