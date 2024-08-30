using CommonTestUtilities.Entities;
using Moq;
using RocketAuction.Domain.Security;

namespace CommonTestUtilities;
public class LoggedUserBuilder
{
    private readonly Mock<ILoggedUser> _loggedUser;

    public LoggedUserBuilder()
    {
        _loggedUser = new Mock<ILoggedUser>();
    }

    public LoggedUserBuilder User()
    {
        _loggedUser.Setup(l => l.User()).ReturnsAsync(UserBuilder.Build());

        return this;
    }

    public ILoggedUser Build() => _loggedUser.Object;
}
