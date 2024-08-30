using Moq;
using RocketAuction.Domain.Repositories.Offers;

namespace CommonTestUtilities.Repositories;
public class OfferWriteOnlyRepositoryBuilder
{
    public static IOfferWriteOnlyRepository Build()
    {
        var mock = new Mock<IOfferWriteOnlyRepository>();

        return mock.Object;
    }
}
