using RocketAuction.Domain.Repositories;

namespace RocketAuction.Infra.DataAccess;
public class UnitOfWork : IUnitOfWork
{
    private readonly RocketAuctionDbContext _dbContext;

    public UnitOfWork(RocketAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
