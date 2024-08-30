using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketAuction.Application.UseCases.Users;
using RocketAuction.Domain.Repositories.Users;
using RocketAuction.Domain.Security.Tokens;

namespace RocketAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly ITokenProvider _tokenProvider;
    private readonly IUserReadOnlyRepository _userRepository;

    public AuthenticationUserAttribute(ITokenProvider tokenProvider, IUserReadOnlyRepository userRepository)
    {
        _tokenProvider = tokenProvider;
        _userRepository = userRepository;
    }

    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = _tokenProvider.TokenOnRequest();
            var email = FromBase64String(token);

            var exists = await _userRepository.ExistUserWithEmail(email);

            if (!exists)
                context.Result = new UnauthorizedObjectResult("Invalid token");
        }
        catch (Exception ex) 
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
