using RocketAuction.Domain.Entities;

namespace RocketAuction.Domain.Security;
public interface ILoggedUser
{
    Task<User> User();
}
