using Microsoft.EntityFrameworkCore;
using RocketAuction.Domain.Entities;
using RocketAuction.Domain.Repositories.Auctions;
using RocketAuction.Infra.DataAccess;

namespace RocketAuction.Application.UseCases.Auctions.GetCurrent;
public class GetCurrentAuctionUseCase : IGetCurrentAuctionUseCase
{
    private readonly IAuctionReadOnlyRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Auction?> Execute()
    {
        return await _repository.GetCurrent();
    }
}
