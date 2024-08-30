namespace RocketAuction.Domain.Security.Tokens;
public interface ITokenProvider
{
    string TokenOnRequest();
}
