using RocketAuction.Domain.Entities;
using RocketAuction.Domain.Repositories.Users;
using RocketAuction.Domain.Security;
using RocketAuction.Domain.Security.Tokens;

namespace RocketAuction.Infra.Services.LoggedUser;
public class LoggedUser : ILoggedUser
{
    private readonly ITokenProvider _tokenProvider;
    private readonly IUserReadOnlyRepository _userRepository;

    public LoggedUser(ITokenProvider tokenProvider, IUserReadOnlyRepository userRepository)
    {
        _tokenProvider = tokenProvider;
        _userRepository = userRepository;
    }

    public async Task<User> User()
    {
        var token = _tokenProvider.TokenOnRequest();
        var email = FromBase64String(token);
        var user = await _userRepository.GetUserByEmail(email);

        return user;
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
