using CommonTestUtilities.Entities;
using Moq;
using RocketAuction.Domain.Repositories.Auctions;

namespace CommonTestUtilities.Repositories;
public class AuctionReadOnlyRepositoryBuilder
{
    private readonly Mock<IAuctionReadOnlyRepository> _repository;
    public AuctionReadOnlyRepositoryBuilder()
    {
        _repository = new Mock<IAuctionReadOnlyRepository>();
    }

    public AuctionReadOnlyRepositoryBuilder GetCurrent()
    {
        _repository.Setup(r => r.GetCurrent()).ReturnsAsync(AuctionBuilder.Build());

        return this;
    }

    public IAuctionReadOnlyRepository Build() => _repository.Object;
}
