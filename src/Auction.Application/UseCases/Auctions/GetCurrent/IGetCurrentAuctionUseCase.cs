using RocketAuction.Domain.Entities;

namespace RocketAuction.Application.UseCases.Auctions.GetCurrent;
public interface IGetCurrentAuctionUseCase
{
    Task<Auction?> Execute();
}
