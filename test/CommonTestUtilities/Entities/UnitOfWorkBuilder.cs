using Moq;
using RocketAuction.Domain.Repositories;

namespace CommonTestUtilities.Entities;
public class UnitOfWorkBuilder
{
    public static IUnitOfWork Build()
    {
        var mock = new Mock<IUnitOfWork>();

        return mock.Object;
    }
}
