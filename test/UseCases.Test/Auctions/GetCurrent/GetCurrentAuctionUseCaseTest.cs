using CommonTestUtilities.Repositories;
using FluentAssertions;
using RocketAuction.Application.UseCases.Auctions.GetCurrent;

namespace UseCases.Test.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public async void Success()
    {
        var repository = new AuctionReadOnlyRepositoryBuilder().GetCurrent().Build();
        var useCase = new GetCurrentAuctionUseCase(repository);
        var auction = await useCase.Execute();

        auction.Should().NotBeNull();
        auction.Id.Should().BeGreaterThan(0);
    }
}
