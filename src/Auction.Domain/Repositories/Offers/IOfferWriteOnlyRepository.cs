using RocketAuction.Domain.Entities;

namespace RocketAuction.Domain.Repositories.Offers;
public interface IOfferWriteOnlyRepository
{
    Task Add(Offer offer);
}
