using RocketAuction.Domain.Entities;

namespace RocketAuction.Domain.Repositories.Auctions;
public interface IAuctionReadOnlyRepository
{
    Task<Auction?> GetCurrent();
}
