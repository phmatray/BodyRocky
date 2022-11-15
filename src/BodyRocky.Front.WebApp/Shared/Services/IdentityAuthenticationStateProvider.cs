using System.Security.Claims;
using BodyRocky.Shared;
using BodyRocky.Shared.Forms;
using Microsoft.AspNetCore.Components.Authorization;

namespace BodyRocky.Front.WebApp.Shared.Services;

public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
{
    private UserInfo? _userInfoCache;
    private readonly IBodyRockyApi _bodyRockyApi;

    public IdentityAuthenticationStateProvider(IBodyRockyApi bodyRockyApi)
    {
        _bodyRockyApi = bodyRockyApi;
    }

    public async Task Login(LoginParameters loginParameters)
    {
        await _bodyRockyApi.LoginAsync(loginParameters);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task Register(RegisterParameters registerParameters)
    {
        await _bodyRockyApi.RegisterAsync(registerParameters);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task Logout()
    {
        await _bodyRockyApi.LogoutAsync();
        _userInfoCache = null;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private async Task<UserInfo> GetUserInfo()
    {
        if (_userInfoCache is { IsAuthenticated: true })
        {
            return _userInfoCache;
        }

        try
        {
            _userInfoCache = await _bodyRockyApi.GetUserInfoAsync();
            return _userInfoCache;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        try
        {
            var userInfo = await GetUserInfo();
            if (userInfo.IsAuthenticated)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, userInfo.UserName) }
                    .Concat(userInfo.ExposedClaims.Select(c => new Claim(c.Key, c.Value)));
                
                identity = new ClaimsIdentity(claims, "Server authentication");
            }
        }
        catch (Refit.ApiException ex)
        {
            Console.WriteLine($"Request failed:{ex}");
        }

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
}