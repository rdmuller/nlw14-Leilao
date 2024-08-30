using RocketAuction.Domain.Entities;
using RocketAuction.Domain.Repositories.Offers;

namespace RocketAuction.Infra.DataAccess.Repositories;
internal class OfferRepository : IOfferWriteOnlyRepository
{
    private readonly RocketAuctionDbContext _dbContext;
    public OfferRepository(RocketAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Offer offer)
    {
        await _dbContext.Offers.AddAsync(offer);
    }
}
