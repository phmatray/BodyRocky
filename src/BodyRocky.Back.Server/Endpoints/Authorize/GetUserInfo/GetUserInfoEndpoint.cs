using BodyRocky.Shared;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Authorize.GetUserInfo;

public class GetUserInfoEndpoint
    : EndpointWithoutRequest<UserInfo>
{
    public override void Configure()
    {
        Get("/authorize/user-info");
    } 
    
    public override async Task HandleAsync(
        CancellationToken ct)
    {
        //var user = await _userManager.GetUserAsync(HttpContext.User);
        var user = BuildUserInfo();
        await SendOkAsync(user, ct);
    }
    
    private UserInfo BuildUserInfo()
    {
        return new UserInfo
        {
            IsAuthenticated = User.Identity.IsAuthenticated,
            UserName = User.Identity.Name,
            ExposedClaims = User.Claims
                //Optionally: filter the claims you want to expose to the client
                //.Where(c => c.Type == "test-claim")
                .ToDictionary(c => c.Type, c => c.Value)
        };
    }
}