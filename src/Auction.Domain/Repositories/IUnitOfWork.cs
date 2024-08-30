namespace RocketAuction.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}
