using Microsoft.EntityFrameworkCore;
using RocketAuction.Domain.Entities;
using RocketAuction.Domain.Repositories.Auctions;

namespace RocketAuction.Infra.DataAccess.Repositories;
internal class AuctionRepository : IAuctionReadOnlyRepository
{
    private readonly RocketAuctionDbContext _dbContext;

    public AuctionRepository(RocketAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Auction?> GetCurrent()
    {
        var today = DateTime.Now;

        return await _dbContext.Auctions.AsNoTracking()
            .Include(auction => auction.Items)
            .FirstOrDefaultAsync(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
