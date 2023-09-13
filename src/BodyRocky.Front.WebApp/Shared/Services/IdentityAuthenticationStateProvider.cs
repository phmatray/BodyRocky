using System.Security.Claims;
using BodyRocky.Shared;
using BodyRocky.Shared.Forms;
using Microsoft.AspNetCore.Components.Authorization;

namespace BodyRocky.Front.WebApp.Shared.Services;

public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
{
    private UserInfoResponse? _userInfoCache;
    private readonly IAuthorizeApi _authorizeApi;
    private readonly ILogger<IdentityAuthenticationStateProvider> _logger;

    public IdentityAuthenticationStateProvider(
        IAuthorizeApi authorizeApi,
        ILogger<IdentityAuthenticationStateProvider> logger)
    {
        _authorizeApi = authorizeApi;
        _logger = logger;
    }

    public async Task Login(LoginParameters loginParameters)
    {
        await _authorizeApi.Login(loginParameters);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task Register(RegisterParameters registerParameters)
    {
        await _authorizeApi.Register(registerParameters);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task Logout()
    {
        await _authorizeApi.Logout();
        _userInfoCache = null;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private async Task<UserInfoResponse> GetUserInfo()
    {
        if (_userInfoCache is { IsAuthenticated: true })
        {
            return _userInfoCache;
        }

        _userInfoCache = await _authorizeApi.GetUserInfo();
        return _userInfoCache;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        try
        {
            var userInfo = await GetUserInfo();
            if (userInfo.IsAuthenticated)
            {
                var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, userInfo.UserName)
                    }
                    .Concat(userInfo.ExposedClaims.Select(c => new Claim(c.Key, c.Value)));
                
                identity = new ClaimsIdentity(claims, "Server authentication");
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Request failed");
        }

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
}