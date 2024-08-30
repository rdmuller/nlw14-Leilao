using CommonTestUtilities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Request;
using FluentAssertions;
using RocketAuction.Application.UseCases.Offers.CreateOffer;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        var request = RequestCreateOfferJsonBuilder.Build();
        var useCase = CreateUseCase();

        var act = async () => await useCase.Execute(itemId, request);

        var rresult = act.Should().NotThrowAsync();
    }

    private CreateOfferUseCase CreateUseCase()
    {
        var offerRepository = OfferWriteOnlyRepositoryBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var loggedUser = new LoggedUserBuilder().User().Build();

        return new CreateOfferUseCase(loggedUser, offerRepository, unitOfWork);
    }
}
