﻿using RocketAuction.Domain.Security.Tokens;

namespace RocketAuction.API.Token;

public class HttpContextTokenValue : ITokenProvider
{
    private readonly IHttpContextAccessor _contextAccessor;
    public HttpContextTokenValue(IHttpContextAccessor httpContextAccessor)
    {
        _contextAccessor = httpContextAccessor;
    }

    public string TokenOnRequest()
    {
        var authorization = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authorization))
            throw new Exception("Token is missing");

        return authorization["Bearer ".Length..].Trim();
    }
}
