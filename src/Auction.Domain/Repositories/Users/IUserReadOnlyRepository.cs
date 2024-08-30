using RocketAuction.Domain.Entities;

namespace RocketAuction.Domain.Repositories.Users;
public interface IUserReadOnlyRepository
{
    Task<User> GetUserByEmail(string email);

    Task<bool> ExistUserWithEmail(string email);
}
